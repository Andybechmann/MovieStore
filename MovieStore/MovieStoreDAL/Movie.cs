using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MovieStoreDAL.Infrastructure;

namespace MovieStoreDAL
{
    public class Movie : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }
      
        public string Genre { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }

    }
}
