using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("введите вес:(в кг)");
            decimal ves = Convert.ToDecimal(Console.ReadLine());
            Console.Write("введите рост:(в см)");
            decimal rost = Convert.ToDecimal(Console.ReadLine());
            decimal imt = ves / (rost/100 * rost/100);
            Console.Write("ваш ИМТ:(округленное)");
            Console.WriteLine(Convert.ToInt64(imt));



        }
    }
}
