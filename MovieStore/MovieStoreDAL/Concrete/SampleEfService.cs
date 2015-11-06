using MovieStoreDAL.Abstarct;

namespace MovieStoreDAL.Concrete
{
    public class SampleEFService : EFServiceContainer<MovieStoreDbContext>
    {
        public SampleEFService()
        {
            this.Context = new MovieStoreDbContext();
        }

        private EFService<MovieStoreDbContext, Customer> _customers;
        private EFService<MovieStoreDbContext, Movie> _movies;
        private EFService<MovieStoreDbContext, Order> _orders;
        private EFService<MovieStoreDbContext, Address> _addresses;

        public EFService<MovieStoreDbContext, Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new EFService<MovieStoreDbContext, Customer>(Context);
                }
                return _customers;
            }
        }

        

        public EFService<MovieStoreDbContext, Movie> Movies
        {
            get
            {
                if (_movies == null)
                {
                    _movies = new EFService<MovieStoreDbContext, Movie>(Context);
                }
                return _movies;
            }
        }
        

        public EFService<MovieStoreDbContext, Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new EFService<MovieStoreDbContext, Order>(Context);
                }
                return _orders;
            }
        }
        

        public EFService<MovieStoreDbContext, Address> Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new EFService<MovieStoreDbContext, Address>(Context);
                }
                return _addresses;
            }
        }

    }
}
