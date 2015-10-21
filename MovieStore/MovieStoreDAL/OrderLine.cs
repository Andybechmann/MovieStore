using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreDAL

{
    public class OrderLine
    {
        private int amount;
        public OrderLine()
        {
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Amount must be above 1");
                }
                amount = value;

            }

        }
        [Column(Order = 0), Key, ForeignKey("Movie")]
        public int Movie_Id { get; set; }

        public virtual Movie Movie { get; set; }

        [Column(Order = 1), Key, ForeignKey("Order")]
        public int Order_Id { get; set; }

        public virtual Order Order { get; set; }

        public double GetOrdeLineSum()
        {
            return amount*Movie.Price;
        }
    }
}