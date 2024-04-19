using System;

namespace porga_module2
{
    class Program
    {
        static void Main()
        {
            Order order = new Order();
            Product product1 = new Product("Milk", 1.5, 2);
            Product product2 = new Product("Bread", 0.8, 1);
            ElectronicProduct product3 = new ElectronicProduct("Phone", 500, 1, "1 year");
            order.AddProduct(product1);
            order.AddProduct(product2);
            order.AddProduct(product3);
            Console.WriteLine($"Total price: {order.GetTotalPrice()}");
            order.RemoveProduct(product1);
            Console.WriteLine($"Total price: {order.GetTotalPrice()}");
            order.ShowOrder();
            order.Confirm();
            order.Ship();
            order.Cancel();

        }
    }
}