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

        Movie movie = new Movie { Title = "title", Id = 1 };
        Customer customer = new Customer { FirstName = "Karl", Id = 1 };

        protected override void Seed(MovieStoreDbContext context)
        {
            Order order = new Order { Id = 1, Date = DateTime.Now, Movie = movie, Customer = customer };
            context.Movies.Add(movie);
            context.Customers.Add(customer);
            context.Orders.Add(order); 
            base.Seed(context); 
        }
    }
}
