using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            Console.Write("Введите день: ");
            int den = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите месяц: ");
            int mes = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите год: ");
            string god = Console.ReadLine();

           
            int polniyGod = Convert.ToInt32("20" + god);

            bool visokosniy = polniyGod % 4 == 0;

            string nazvanieMesyaca = "";
            int kolvoDney = 0;

            switch (mes)
            {
                case 1:
                    nazvanieMesyaca = "январь";
                    kolvoDney = 31;
                    break;

                case 2:
                    nazvanieMesyaca = "февраль";

                    if (visokosniy)
                    {
                        kolvoDney = 29;
                    }
                    else
                    {
                        kolvoDney = 28;
                    }

                    break;

                case 3:
                    nazvanieMesyaca = "март";
                    kolvoDney = 31;
                    break;

                case 4:
                    nazvanieMesyaca = "апрель";
                    kolvoDney = 30;
                    break;

                case 5:
                    nazvanieMesyaca = "май";
                    kolvoDney = 31;
                    break;

                case 6:
                    nazvanieMesyaca = "июнь";
                    kolvoDney = 30;
                    break;

                case 7:
                    nazvanieMesyaca = "июль";
                    kolvoDney = 31;
                    break;

                case 8:
                    nazvanieMesyaca = "август";
                    kolvoDney = 31;
                    break;

                case 9:
                    nazvanieMesyaca = "сентябрь";
                    kolvoDney = 30;
                    break;

                case 10:
                    nazvanieMesyaca = "октябрь";
                    kolvoDney = 31;
                    break;

                case 11:
                    nazvanieMesyaca = "ноябрь";
                    kolvoDney = 30;
                    break;

                case 12:
                    nazvanieMesyaca = "декабрь";
                    kolvoDney = 31;
                    break;
            }

            if (den >= 1 && den <= kolvoDney)
            {
                Console.WriteLine(den + " " + nazvanieMesyaca + " 20" + god);
            }
            else
            {
                Console.WriteLine("В этом месяце столько дней нет!");
            }
        }

        static void chisla()
        {
            Console.WriteLine("Введите выражение(сложение):");
            string chisla1 = Console.ReadLine();
            string[] chisla2 = chisla1.Split(new char[] { ' ' });
            int a;
            bool result = int.TryParse(chisla2[0], out a);

            if (result == true)
                Console.WriteLine($"Преобразование успешно. Число: {a}");
            else
                Console.WriteLine("Преобразование неудачно");
            int b;
            bool result1 = int.TryParse(chisla2[2], out b);

            if (result == true)
                Console.WriteLine($"Преобразование успешно. Число: {b}");
            else
                Console.WriteLine("Преобразование неудачно");
           if (chisla2[1] == "+")
            {
                Console.Write("Результат сложения: ");
                Console.WriteLine(a+b);
            }


        }

        static void invent()
        {
            string[] popa = { "клавиатура", "мышь", "наушники", "", "", "" };


        }
        
        static void Main(string[] args)
        {
            imt();
            den();
            chisla();


        }
    }
}
