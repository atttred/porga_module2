using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace porga_module2
{
/*    Створення класу Order, який реалізує інтерфейс IOrder та містить методи для роботи з замовленнями.
    Використання конструкторів для ініціалізації об'єктів класів та деструкторів для звільнення ресурсів.
    Визначення події для сповіщення про зміну статусу замовлення та організація взаємодії об'єктів через цю подію.
    Реалізація узагальненого класу для зберігання списку товарів у замовленні.
    Створення класів винятків для обробки помилок під час роботи з замовленнями.*/

    internal class Order : IOrder
    {
        private List<Product> products = new List<Product>();
        public event Action<string> StatusChanged;
        public string Status { get; private set; }
        public Order()
        {
            Status = "New";
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
            Status = "In progress";
            StatusChanged?.Invoke(Status);
        }
        public void RemoveProduct(Product product)
        {
            if (products.Contains(product))
            {
                products.Remove(product);
                Status = "In progress";
                StatusChanged?.Invoke(Status);
            }
            else
            {
                throw new ProductNotFoundException("Product not found in order");
            }
        }
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (Product product in products)
            {
                totalPrice += product.Price * product.Quantity;
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
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price} - {product.Quantity}");
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
