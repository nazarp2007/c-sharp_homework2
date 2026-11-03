//using ConsoleApp2;

//static void ShowProductInfor(Product product)
//{
//    product.printInfo();
//}

//static void ProcessProducts(Product[] products, ProductAction act)
//{
//    foreach (Product prod in products)
//        act(prod);
//}

//static void main(string[] args)
//{
//    Product[] products = new Product[5];

//    products[0] = new Product("Paper", 50, 150.0, 1);
//    products[1] = new FoodProduct("Milk", 60, 63.0, 2, new DateTime(2026, 12, 31));
//    products[2] = new ElectronicProduct("iPhone", 15, 40000.0, 3, 13);
//    products[3] = new FoodProduct("Bread", 30, 25.0, 4, new DateTime(2026, 11, 1));
//    products[4] = new ElectronicProduct("Headphones", 40, 3000.0, 5, 6);

//    Console.WriteLine("--- Info about all products ---");
//    foreach (Product p in products)
//    {
//        p.printInfo();
//        Console.WriteLine($"Preview: {p.GetDescription()}");
//        Console.WriteLine($"Discount: {p.CalculateDiscount()} uah\n");
//    }

//}

using System;
using ConsoleApp2;

internal class Program
{
    static void ShowProductInfor(Product product)
    {
        product.printInfo();
    }

    static void ProcessProducts(Product[] products, ProductAction act)
    {
        foreach (Product prod in products)
            act(prod);
    }

    static void Main(string[] args)
    {
        Product[] products = new Product[5];

        products[0] = new Product("Paper", 50, 150.0, 1);
        products[1] = new FoodProduct("Milk", 60, 63.0, 2, new DateTime(2026, 12, 31));
        products[2] = new ElectronicProduct("iPhone", 15, 40000.0, 3, 13);
        products[3] = new FoodProduct("Bread", 30, 25.0, 4, new DateTime(2026, 11, 1));
        products[4] = new ElectronicProduct("Headphones", 40, 3000.0, 5, 6);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=== MAIN MENU ===");
            Console.WriteLine("1. Show information about all products");
            Console.WriteLine("2. Calculate discount and final price");
            Console.WriteLine("3. Check warranty or expiration date");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Info about all products ---");
                    ProcessProducts(products, ShowProductInfor);
                    break;

                case "2":
                    Console.WriteLine("\n--- Price Calculation ---");
                    foreach (Product p in products)
                    {
                        p.printInfo();
                        Console.WriteLine($"Description: {p.GetDescription()}");
                        Console.WriteLine($"Discount: {p.CalculateDiscount()} uah");

                        if (p is ISellable sellable)
                        {
                            Console.WriteLine($"Final price: {sellable.CalculateFinalPrice()} uah");
                        }
                        Console.WriteLine();
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Specific Checks ---");
                    foreach (Product p in products)
                    {
                        if (p is FoodProduct fp)
                        {
                            fp.CheckExp();
                        }
                        else if (p is ElectronicProduct ep)
                        {
                            ep.CheckWarranty();
                            if (ep is IWarranty warrantyItem)
                            {
                                warrantyItem.GetWarrantyInfo();
                            }
                        }
                    }
                    break;

                case "0":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}