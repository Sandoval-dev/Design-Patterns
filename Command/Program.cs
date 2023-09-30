using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {

        }

    }

    class Stock
    {
        private string _name = "Laptop";
        private int _quantity = 0;

        public void Buy()
        {
            Console.WriteLine("Buy");
        }

        public void Sell()
        {
            Console.WriteLine("Sell");
        }
    }

    interface IOrder
    {
        void Execute();
    }
    class BuyStock : IOrder
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    class SellStock : IOrder
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
