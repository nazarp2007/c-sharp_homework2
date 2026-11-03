using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class FoodProduct:Product, ISellable
    {
        private DateTime expirationDate;

        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public FoodProduct(string name, int quantity, double price, int id, DateTime expirationDate) : base(name, quantity, price, id)
        {
            this.expirationDate = expirationDate;
        }

        public override double CalculateDiscount()
        {
            if ((expirationDate - DateTime.Now).TotalDays <= 3)
                return price * 0.2;
            return 0;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Expiring date: {expirationDate.ToShortDateString()}";
        }

        public void CheckExp()
        {
            if(DateTime.Now> expirationDate)
            {
                Console.WriteLine("Safe to consume");
            }
            else
            {
                Console.WriteLine("Unsafe to consume");
            }
        }

        public double CalculateFinalPrice()
        {
            return price - CalculateDiscount();
        }
    }
}
