using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreDAL
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }
            
        public string Genre { get; set; }

        public virtual List<Order> Orders { get; set; }


    }
}
