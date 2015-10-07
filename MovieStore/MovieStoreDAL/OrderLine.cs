using System;
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
        public Movie Movie { get; set; }
    }
}