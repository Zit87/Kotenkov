using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Product
    {
        
        public int ProductID;
        public string Name;

        public double Price;

        public int Quantity;

        public void PrintInfo()
        {
            Console.WriteLine($"ID товара {ProductID} название {Name} цена {Price} кол-во {Quantity}");
        }

        public Product(int productID, string name, double price, int quantity)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            Quantity = quantity;
        }


    }




    internal class Program
    {



        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(0, "макароны", 152, 2));
            products.Add(new Product(1, "пельмени", 67, 3));
            products.Add(new Product(2, "сигареты", 298, 8));
            while (true)
            {


                Console.WriteLine("____________Список продуктиков_____________");
                Console.WriteLine("1. Показать список товаров");
                Console.WriteLine("2. Добавить товар");
                Console.WriteLine("3. Удалить товар");
                Console.WriteLine("0. Выход");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        foreach (Product product in products)
                        {
                            product.PrintInfo();
                        }
                        break;
                    case 2:
                        Console.WriteLine("добавить товар:");
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Название: ");
                        string name = Console.ReadLine();
                        Console.Write("Цена: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.Write("Количество: ");
                        int quantity = int.Parse(Console.ReadLine());
                        products.Add(new Product(id, name, price, quantity));
                        break;
                    case 3:
                        Console.WriteLine("Удаление товара:");
                        Console.WriteLine("1. по ID");
                        Console.WriteLine("2. по названию");
                        int b = int.Parse(Console.ReadLine());
                        switch (b)
                        {
                            case 1:
                                Console.Write("Введите ID товара для удаления: ");
                                int deleteId = int.Parse(Console.ReadLine());
                                products.RemoveAll(p => p.ProductID == deleteId);
                                break;
                            case 2:
                                Console.Write("Введите название товара для удаления: ");
                                string deleteName = Console.ReadLine();
                                products.RemoveAll(p => p.Name.Equals(deleteName, StringComparison.OrdinalIgnoreCase));
                                break;
                            default:
                                Console.WriteLine("Неверный выбор. Попробуйте снова.");
                                break;
                        }
                        
                        break;
                    case 0:
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;

                }
            }
        }
    }
}
