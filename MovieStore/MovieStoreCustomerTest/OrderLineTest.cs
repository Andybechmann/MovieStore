using MovieStoreDAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreCustomerTest
{
    [TestFixture]
    public class OrderLineTest
    {

        [Test]
        public void Order_line_properties_set_ok()
        {
            OrderLine orderLine = new OrderLine();
            Movie movie = new Movie() { Id = 1, Title = "Buller" };
            orderLine.Movie = movie;
            orderLine.Amount = 10;

            Assert.AreEqual(movie, orderLine.Movie);
            Assert.AreEqual(10, orderLine.Amount);
        }

        [Test]
        [ExpectedException(typeof(ArgIterator))]
        public void OrderLine_amount_less_then_one_fails_test()
        {
            OrderLine orderLine = new OrderLine();
            orderLine.Amount = 0;
        }


    }
}
