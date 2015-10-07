using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreDAL
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required]
        public Address Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //[Compare("Email")]
        
        public string EmailConfirm { get; set; }

        /*public virtual List<Order> orders { get; set; }*/

    }
}
