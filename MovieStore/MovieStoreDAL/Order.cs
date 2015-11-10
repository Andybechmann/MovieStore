using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreDAL.Infrastructure;

namespace MovieStoreDAL
{
   public class Order : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }

       public double GetOrderSum()
       {
           return OrderLines.Sum(orderLine => orderLine.GetOrdeLineSum());
       }
    }
}
