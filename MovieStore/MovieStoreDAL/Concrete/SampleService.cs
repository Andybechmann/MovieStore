using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreDAL.Abstarct;

namespace MovieStoreDAL.Concrete
{
    public class SampleService : ServiceGroup<MovieStoreDbContext>
    {
        public SampleService()
        {
            this.context = new MovieStoreDbContext();
        }

        private Service<MovieStoreDbContext, Customer> customers;

        public Service<MovieStoreDbContext, Customer> Customers
        {
            get
            {
                if (customers == null)
                {
                    customers = new Service<MovieStoreDbContext, Customer>(context);
                }
                return customers;
            }
        }

        private Service<MovieStoreDbContext, Movie> movies;

        public Service<MovieStoreDbContext, Movie> Movies
        {
            get
            {
                if (movies == null)
                {
                    movies = new Service<MovieStoreDbContext, Movie>(context);
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
                    orders = new Service<MovieStoreDbContext, Order>(context);
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
                    addresses = new Service<MovieStoreDbContext, Address>(context);
                }
                return addresses;
            }
        }

    }
}
