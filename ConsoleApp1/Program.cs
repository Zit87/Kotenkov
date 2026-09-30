using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Kolvo { get; set; }

        public Product(string Name, decimal Price, int Kolvo)
        {
            this.Name = Name;
            this.Price = Price;
            this.Kolvo = Kolvo;
        }
    }


    public static class ListExtensions
    {
        public static List<T> Filter<T>(this List<T> list, Predicate<T> condition)
        {
            List<T> result = new List<T>();

            foreach (T item in list)
            {
                if (condition(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }

   
    delegate decimal PriceModifier(decimal price);

    internal class Program
    {
      
        static void ChangePrice(Product product, PriceModifier modifier)
        {
            product.Price = modifier(product.Price);
        }

        
        static decimal Discount10(decimal price)
        {
            return price * 0.9m;
        }

       
        static decimal Markup20(decimal price)
        {
            return price * 1.2m;
        }

       
        static void ShowProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(
                    $"Название: {product.Name}, Цена: {product.Price}, Количество: {product.Kolvo}");
            }

        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            products.Add(new Product("пельмени", 152, 67));
            products.Add(new Product("щавель", 134, 69));
            products.Add(new Product("печенье", 1567, 68));

            List<Product> cheapProducts = products.Filter(
                p => p.Price < 1000
            );

            Console.WriteLine("Товары дешевле 1000 рублей:");
            ShowProducts(cheapProducts);

            List<Product> inStock = products.Filter(
                p => p.Kolvo > 0
            );

            Console.WriteLine("Товары, которые есть на складе:");
            ShowProducts(inStock);

            List<Product> moreThanFive = products.Filter(
                p => p.Kolvo > 5
            );

            Console.WriteLine("Товары, количество которых больше 5:");
            ShowProducts(moreThanFive);

            Console.Write("Введите название для поиска: ");
            string search = Console.ReadLine();

            List<Product> foundProducts = products.Filter(
                p => p.Name.ToLower().Contains(search.ToLower())
            );

            Console.WriteLine("Найденные товары:");
            ShowProducts(foundProducts);

            Console.WriteLine("Цены до изменения:");
            ShowProducts(products);

            ChangePrice(products[0], Discount10);

            ChangePrice(products[1], Markup20);

            Console.WriteLine("Цены после изменения:");
            ShowProducts(products);
        }
    }
}