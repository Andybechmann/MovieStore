using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieStoreDAL
{
    public class MovieStoreDbInitializer : DropCreateDatabaseAlways<MovieStoreDbContext>
    {

       
        protected override void Seed(MovieStoreDbContext context)
        {

            
            Movie movie1 = new Movie { Title = "title2", Year = DateTime.Now, Price = 10.0};
            Movie movie = new Movie { Title = "title",Year=DateTime.Now,Price = 18.00};
            OrderLine orderline = new OrderLine() { Movie = movie1, Amount = 4 };
            OrderLine orderline1 = new OrderLine() { Movie = movie, Amount = 12 };
            Customer customer = new Customer { FirstName = "Karl", LastName = "Karlsen",
                Address = new Address{ Streetname = "ostegade",City = "Esbjerg",ZipCode = 6700} };
            Order order = new Order { Date = DateTime.Now, OrderLines = new List<OrderLine>() {orderline,orderline1 }, Customer = customer };
            context.Movies.Add(movie);
            context.Customers.Add(customer);
            context.Orders.Add(order); 
            base.Seed(context);
        }
    }
}
