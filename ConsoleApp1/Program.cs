using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
   
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pokupki> pokupki = core.Context.Pokupki.ToList();
            Pokupki remove = pokupki.First(Pokupki => Pokupki.Name.Contains("Саша"));
            core.Context.Pokupki.Remove(remove);
            core.Context.SaveChanges();

            foreach (Pokupki p in pokupki)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Price);
                Console.WriteLine(p.Count);
            }
        }
    }
}