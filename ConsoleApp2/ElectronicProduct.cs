using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ElectronicProduct:Product, IWarranty, ISellable
    {
        private int warranty;

        public int Warranty
        {
            get { return warranty; }
            set { warranty = value; }
        }

        public ElectronicProduct(string name, int quantity, double price, int id, int warranty):base(name, quantity, price, id)
        {
            this.warranty = warranty;
        }

        public override double CalculateDiscount()
        {
            if (warranty < 12)
                return price * 0.1;
            return 0;
        }
        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Warrany: {warranty} mon.";
        }
        public void CheckWarranty()
        {
            Console.WriteLine($"This product's warranty is maintained for {warranty} more mon.");
        }

        public void GetWarrantyInfo()
        {
            Console.WriteLine($"Warranty maintanance of product {Name}: {warranty} mon.");
        }
        public double CalculateFinalPrice()
        {
            return price - CalculateDiscount();
        }
    }
}
