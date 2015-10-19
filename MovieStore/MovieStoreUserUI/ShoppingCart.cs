using MovieStoreDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStoreAdminUI
{
    public class ShoppingCart
    {
       private List<OrderLine> orderLines { get; set;  }
        public ShoppingCart()
        {
            orderLines = new List<OrderLine>();
        }

       public void AddOrderLine(OrderLine orderLine)
        {
            orderLines.Add(orderLine);
        } 
        public void RemoveOrderLine(OrderLine orderLine)
        {
            orderLines.Remove(orderLine);
        }
        public List<OrderLine> GetOrderLines()
        {
            return orderLines;
        }
    }
}