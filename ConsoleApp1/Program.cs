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

        public Product()
        {
            List<Product> products = new List<Product>() { 
                new Product { ProductID=0, Name="макароны", Price=152, Quantity=2 }, 
                new Product { ProductID=1 ,Name="пельмени",Price = 67, Quantity = 3 },
                new Product{ProductID=2, Name="сигареты",Price=298 , Quantity = 8 } };




        }


    }




    internal class Program
    {
        


        static void Main(string[] args)
        {
            Product product = new Product();

            product.PrintInfo();


        }
    }
}
