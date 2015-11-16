using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using MovieStoreDAL.Infrastructure;

namespace MovieStoreDAL.Bll.MovieDto
{
    [DataContract(IsReference = true)]
    public class MovieDto:IEntity
    {
        
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime Year { get; set; }

        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        [Display(Name = "Price USD")]
        public decimal USDPrice { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string TrailerUrl { get; set; }

        [DataMember]    
        public string Genre { get; set; }

    }
}
