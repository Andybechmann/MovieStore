using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreDAL.Infrastructure;

namespace MovieStoreDAL
{
   public  class Address : IEntity
    {
        public int Id { get; set; }

        public string Streetname { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

    }
}
