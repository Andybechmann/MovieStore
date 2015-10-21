using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MovieStoreDAL
{
    public class DALFacade
    {

        //System.Data.Entity.SqlServer.SqlProviderServices
        //    ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public IRepository<Order> _orderRepository { get; private set; }
        public IRepository<Movie> _moviesRepository { get; private set; }
        public IRepository<Customer> _customersRepository { get; private set; }

        public DALFacade()
        {
            _customersRepository = new CustomerRepository();
            _moviesRepository = new MovieRepository();
            _orderRepository = new OrderRepository();
        }


    }
}
