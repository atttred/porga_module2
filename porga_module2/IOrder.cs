namespace porga_module2
{
/*    Створення інтерфейсу IOrder, який містить методи для додавання товарів, видалення товарів та отримання загальної вартості замовлення.
*/  internal interface IOrder<T>
    {
        void AddProduct(T product);
        void RemoveProduct(string name);
        double GetTotalPrice();
    }
}
