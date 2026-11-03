using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Product
    {
        private string name;
        protected int quantity;
        internal double price;
        public int id;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        internal double Price
        {
            get { return price; }
            set {  price = value; }
        } 
        public int Id
        {
            get { return id; }
            set { Id = value; }
        }

        public Product()
        {
            name = "";
            quantity = 0;
            price = 0; 
            id = 0;
        }

        public Product( string name, int quantity, double price, int id)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.id = id;
        }

        public void printInfo()
        {
            Console.WriteLine($"Name: {name}\nQuantity: {quantity}\nPrice: {price}\nId: {id}\n");
        }

        public virtual double CalculateDiscount()
        {
            return 0;
        }

        public virtual string GetDescription()
        {
            return $"Product: {Name}, Price: {Price}";
        }
    }
}

