using System;

namespace porga_module2
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Add product to order");
                Console.WriteLine("2. Remove product from order");
                Console.WriteLine("3. Get total price");
                Console.WriteLine("4. Confirm order");
                Console.WriteLine("5. Cancel order");
                Console.WriteLine("6. Ship order");
                Console.WriteLine("7. Clear order");
                Console.WriteLine("8. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                Order<Product> order = new();
                order.StatusChanged += (status) => Console.WriteLine($"Order status: {status}");

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter product name:");
                        string name = Console.ReadLine() ?? "default_name1";
                        Console.WriteLine("Enter product price:");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter product quantity:");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Product product = new(name, price, quantity);
                        order.AddProduct(product);
                        break;
                    case 2:
                        Console.WriteLine("Enter product name:");
                        string name1 = Console.ReadLine() ?? "default_name1";
                        order.RemoveProduct(name1);
                        break;
                    case 3:
                        Console.WriteLine($"Total price: {order.GetTotalPrice()}");
                        break;
                    case 4:
                        order.Confirm();
                        break;
                    case 5:
                        order.Cancel();
                        break;
                    case 6:
                        order.Ship();
                        break;
                    case 7:
                        order.Dispose();
                        break;
                    case 8:
                        return;
                }
            }

        }
    }
}