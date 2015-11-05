using MovieStoreDAL.Abstarct;

namespace MovieStoreDAL.Concrete
{
    public class SampleService : ServiceGroup<MovieStoreDbContext>
    {
        public SampleService()
        {
            this.Context = new MovieStoreDbContext();
        }

        private Service<MovieStoreDbContext, Customer> _customers;

        public Service<MovieStoreDbContext, Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new Service<MovieStoreDbContext, Customer>(Context);
                }
                return _customers;
            }
        }

        private Service<MovieStoreDbContext, Movie> movies;

        public Service<MovieStoreDbContext, Movie> Movies
        {
            get
            {
                if (movies == null)
                {
                    movies = new Service<MovieStoreDbContext, Movie>(Context);
                }
                return movies;
            }
        }
        private Service<MovieStoreDbContext, Order> orders;

        public Service<MovieStoreDbContext, Order> Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = new Service<MovieStoreDbContext, Order>(Context);
                }
                return orders;
            }
        }
        private Service<MovieStoreDbContext, Address> addresses;

        public Service<MovieStoreDbContext, Address> Addresses
        {
            get
            {
                if (addresses == null)
                {
                    addresses = new Service<MovieStoreDbContext, Address>(Context);
                }
                return addresses;
            }
        }

    }
}
