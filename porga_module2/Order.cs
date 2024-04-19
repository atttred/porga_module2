using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace porga_module2
{
/*    Реалізація узагальненого класу для зберігання списку товарів у замовленні.*/
    
    

    internal class Order<T> : IOrder<T>
    {
        private readonly List<T> products = [];
        public event Action<string> StatusChanged;
        public string Status { get; private set; }
        public Order()
        {
            Status = "New";
        }
        public void AddProduct(T product)
        {
            products.Add(product);
            Status = "In progress";
            StatusChanged?.Invoke(Status);
        }
        public void RemoveProduct(string name)
        {
            T product = products.Find(p => p.GetType().GetProperty("Name").GetValue(p).ToString() == name) ?? throw new ProductNotFoundException("Product not found");
            products.Remove(product);
        }
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (T product in products)
            {
                totalPrice += Convert.ToDouble(product.GetType().GetProperty("Price").GetValue(product)) * Convert.ToInt32(product.GetType().GetProperty("Quantity").GetValue(product));
            }
            return totalPrice;
        }
        public void Confirm()
        {
            Status = "Confirmed";
            StatusChanged?.Invoke(Status);
            Console.WriteLine("Order confirmed.");
        }
        public void Cancel()
        {
            Status = "Canceled";
            StatusChanged?.Invoke(Status);
            Console.WriteLine("Order canceled.");
        }
        public void Ship()
        {
            Status = "Shipped";
            StatusChanged?.Invoke(Status);
            Console.WriteLine("Order shipped");
        }
        public void Deliver()
        {
            Status = "Delivered";
            StatusChanged?.Invoke(Status);
            Console.WriteLine("Order delivered");
        }
        public void Close()
        {
            Status = "Closed";
            StatusChanged?.Invoke(Status);
            Console.WriteLine("Order closed");
        }
        public void Dispose()
        {
            products.Clear();
        }

        public void ShowOrder()
        {
            Console.WriteLine("Order:");
            foreach (T product in products)
            {
                Console.WriteLine($"{product.GetType().GetProperty("Name").GetValue(product)} - {product.GetType().GetProperty("Price").GetValue(product)} - {product.GetType().GetProperty("Quantity").GetValue(product)}");
            }
        }
    }

    internal class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
