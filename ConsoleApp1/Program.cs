using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        static void imt()
        {
            Console.Write("введите вес:(в кг)");
            decimal ves = Convert.ToDecimal(Console.ReadLine());
            Console.Write("введите рост:(в см)");
            decimal rost = Convert.ToDecimal(Console.ReadLine());
            decimal imt = ves / (rost / 100 * rost / 100);
            Console.Write("ваш ИМТ:(округленное)");
            Console.WriteLine(Convert.ToInt64(imt));
            


        }

        static void den()
        {
            Console.Write("введите день:");
            string den = Console.ReadLine();
            Console.Write("введите месяц:");
            int mes = Convert.ToInt32(Console.ReadLine());
            Console.Write("введите год:");
            string god = Console.ReadLine();
            int den1 = Convert.ToInt32(den);
            bool god1 = Convert.ToInt32(god) % 4==0;

            switch (mes)
            {
                case 1:
                    if (den1  <= 31)
                    {
                        Console.Write(den);
                    }else
                    {
                        Console.Write("стоко дней нет");
                        break;
                    }
                    Console.Write(" январь ");
                    Console.Write("20"+god);

                    break;
                case 2:
                   if (god1 = true)
                    {
                        if(den1 <= 29)
                        {
                            Console.Write(den);
                        }
                    }
                    else
                    {
                        if (den1 <= 28)
                        {
                            Console.Write(den);
                        }
                    }
                    Console.Write(" февраль ");
                    Console.Write("20" + god);
                    break;
                case 3:
                    Console.Write(den);
                    Console.Write(" март ");
                    Console.Write("20" + god);

                    break;
                case 4:
                    Console.Write(den);
                    Console.Write(" апрель ");
                    Console.Write("20" + god);
                    break;
                case 5:
                    Console.Write(den);
                    Console.Write(" май ");
                    Console.Write("20" + god);

                    break;
                case 6:
                    Console.Write(den);
                    Console.Write(" июнь ");
                    Console.Write("20" + god);

                    break;
                case 7:
                    Console.Write(den);
                    Console.Write(" июль ");
                    Console.Write("20" + god);

                    break;
                case 8:
                    Console.Write(den);
                    Console.Write(" август ");
                    Console.Write("20" + god);

                    break;
                case 9:
                    Console.Write(den);
                    Console.Write(" сентябрь ");
                    Console.Write("20" + god);

                    break;
                case 10:
                    Console.Write(den);
                    Console.Write(" октябрь ");
                    Console.Write("20" + god);

                    break;
                case 11:
                    Console.Write(den);
                    Console.Write(" ноябрь ");
                    Console.Write("20" + god);

                    break;
                case 12:
                    Console.Write(den);
                    Console.Write(" декабрь ");
                    Console.Write("20" + god);

                    break;
            }


        }

        static void Main(string[] args)
        {
            //imt();
            den();



        }
    }
}
