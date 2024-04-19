using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace porga_module2
{
/*    Створення інтерфейсу IOrder, який містить методи для додавання товарів, видалення товарів та отримання загальної вартості замовлення.
*/  internal interface IOrder
    {
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        double GetTotalPrice();
    }
}
