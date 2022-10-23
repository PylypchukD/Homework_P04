using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Создайте текстовый файл-чек по типу «Наименование товара – 0.00(цена)грн.» с определенным количеством наименований товаров и датой совершения покупки. 
             * Выведите на экран информацию из чека в формате текущей локали пользователя и в формате локали en-US. 
             */

            List<Order> orders = new List<Order>();
            orders.Add(new Order("Apple MacBook M1", 1299.99));
            orders.Add(new Order("Mouse A4", 99.99));
            orders.Add(new Order("Keyboard RAPOO", 299.59));

            var file = new FileStream("Homework.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var writer = new StreamWriter(file, Encoding.GetEncoding(1251));

            foreach (var item in orders)
            {
                writer.WriteLine($"{item.Name} - {item.Price.ToString("C", new CultureInfo("en-US"))}"); 
            }
            writer.Close();

            Console.ReadKey();
        }
    }

    class Order
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Order(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
