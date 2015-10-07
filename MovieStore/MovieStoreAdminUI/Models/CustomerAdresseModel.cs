using MovieStoreDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreUI.Models
{
    public class CustomerAdresseModel
    {
        public Customer Customer { get; set; }

        public Address Address { get; set; }


    }
}