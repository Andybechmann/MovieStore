using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreDAL
{
    class DALFacade
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Movie> _moviesRepository;
        private IRepository<Customer> _customersRepository;

        public DALFacade()
        {
            _customersRepository = new CustomerRepository();
            _moviesRepository = new MovieRepository();
            _orderRepository = new OrderRepository();
        }
    }
}
