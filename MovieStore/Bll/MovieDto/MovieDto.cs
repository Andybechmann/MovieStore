using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bll.MovieDto
{
    [DataContract(IsReference = true)]
    public class MovieDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

            [DataMember]
        public DateTime Year { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string TrailerUrl { get; set; }

        [DataMember]    
        public string Genre { get; set; }

       
    }
}
