using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Order
    {
        private static int nextID = 0;
        public int ID;
        public string Name { get; set; }
        private double price;

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("Цена должна быть больше 0");
                }
            }
        }
        private double discount;

        public double Discount
        {
            get
            {
                return discount;
            }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    discount = value;
                }
                else
                {
                    Console.WriteLine("Скидка должна быть от 0 до 50");
                }
            }
        }
        private int kolvo;
        public int Kolvo
        {
            get
            {
                return kolvo;
            }
            set
            {
                if (value > 0)
                {
                    kolvo = value;
                }
                else
                {
                    Console.WriteLine("Количество должно быть больше 0");
                }
            }
        }
        public double TotalPrice    
        {
            get
            {
                return Price * Kolvo * (1 - Discount / 100);
            }
        }

        public Order(string Name, double Price, double Discount, int Kolvo)
        {
            ID = ++nextID;
            this.Name = Name;
            this.Price = Price;
            this.Discount = Discount;
            this.Kolvo = Kolvo;
        }


        public void PrintInfo()
        {
            Console.WriteLine($"ID: {ID} Name: {Name} Price: {Price} Discount: {Discount} Kolvo: {Kolvo} TotalPrice: {TotalPrice}");
        }



    }


    internal class Program
    {



        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order("Товар 1", 100, 10, 2));
            orders.Add(new Order("Товар 2", 200, 20, 3));
            orders.Add(new Order("Товар 3", 300, 30, 4));
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("0 - Вывод");
            Console.WriteLine("1 - Добавить заказ");
            Console.WriteLine("2 - Удалить заказ");
            Console.WriteLine("3 - Изменить заказ");
            Console.WriteLine("4 - Вывести все заказы");
            Console.WriteLine("5 - Вывести заказы с ценой больше заданной");
            Console.WriteLine("6 - Вывести заказы с ценой меньше заданной");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 0:
                    foreach(Order d in orders)
                    {
                        d.PrintInfo();

                    }
                    break;
                case 1:
                    Console.WriteLine("Введите название товара: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите цену товара: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите скидку на товар: ");
                    double discount = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите количество товара: ");
                    int kolvo = Convert.ToInt32(Console.ReadLine());
                    orders.Add(new Order(name, price, discount, kolvo));
                    break;
                    case 2:
                    Console.WriteLine("Введите ID заказа, который хотите удалить: ");
                    int idToRemove = Convert.ToInt32(Console.ReadLine());
                    Order orderToRemove = orders.FirstOrDefault(o => o.ID == idToRemove);
                    Console.WriteLine("Удалено");

                    break;
            }

        }
    }
    
}
