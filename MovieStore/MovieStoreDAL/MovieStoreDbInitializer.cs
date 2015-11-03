using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieStoreDAL
{
    public class MovieStoreDbInitializer : DropCreateDatabaseIfModelChanges<MovieStoreDbContext>
    {
        protected override void Seed(MovieStoreDbContext context)
        {
            Movie movie1 = new Movie { Title = "Star Wars", Year = DateTime.Now, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTkwNzAwNDA4N15BMl5BanBnXkFtZTgwMTA2MDcwNzE@._V1__SX1857_SY903_.jpg", TrailerUrl = "https://www.youtube.com/embed/sGbxmsDFVnE", Price = 100 };
            Movie movie = new Movie { Title = "Batman", Year=DateTime.Now, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BNTM3OTc0MzM2OV5BMl5BanBnXkFtZTYwNzUwMTI3._V1__SX1857_SY903_.jpg", TrailerUrl = "https://www.youtube.com/embed/neY2xVmOfUM", Price = 250 };
            OrderLine orderline = new OrderLine() { Movie = movie1, Amount = 4 };
            OrderLine orderline1 = new OrderLine() { Movie = movie, Amount = 12 };
            Customer customer = new Customer
            {
                FirstName = "Karl", LastName = "Karlsen", Address = new Address() { Streetname = "Østergade"  },
                Email = "andy@andy"
            };
            Order order = new Order { Date = DateTime.Now, OrderLines = new List<OrderLine>() {orderline,orderline1 }, Customer = customer };
            context.Movies.Add(movie);
            context.Customers.Add(customer);
            context.Orders.Add(order); 
            base.Seed(context);
        }
    }
}
