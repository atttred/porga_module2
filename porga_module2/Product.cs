using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace porga_module2
{
/*    Побудова ієрархії класів для товарів: базовий клас Product, який містить загальні властивості, та похідні класи, наприклад, FoodProduct, ElectronicProduct тощо.
*/  internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    internal class FoodProduct : Product
    {
        public DateTime ExpirationDate { get; set; }
        public FoodProduct(string name, double price, int quantity, DateTime expirationDate) : base(name, price, quantity)
        {
            ExpirationDate = expirationDate;
        }
    }

    internal class ElectronicProduct : Product
    {
        public string Warranty { get; set; }
        public ElectronicProduct(string name, double price, int quantity, string warranty) : base(name, price, quantity)
        {
            Warranty = warranty;
        }
    }
}
