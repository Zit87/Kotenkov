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
    class Lampa
    {
        public static int ID = -1;
        public string sost { get; private set; }

        public int yar;

        public int temp;

        public string regim { get; private set; }

        public Lampa(string sost, int yar, int temp)
        {
            ID++;
            if (sost == "on" || sost == "off")
            {
                this.sost = sost;

            }
            else
            {
                Environment.Exit(1);
            }

            if (yar < 0 || yar > 100)
            {
                Console.WriteLine("от 0 до 100 только!!!");
                Environment.Exit(1);

            }
            else
            {
                this.yar = yar;
            }
            if (temp < 2700 || temp > 6500)
            {
                Console.WriteLine("от 2700 до 6500 только!!!");
                Environment.Exit(1);

            }
            else
            {
                this.temp = temp;
            }

            if (temp <= 3000)
            {
                regim = "Ночь";
                
            }
            else if (temp > 3000 || temp <= 5000)
            {
                regim = "Чтение";
            }
            else if (temp > 5000)
            {
                regim = "День";
            }




        }
        public void PrintInfo()
        {
            Console.WriteLine($"ID лампы: {ID} состояние: {sost} яркость: {yar} температура: {temp} режим: {regim}");
        }


        public void onoff()
        {
            if(sost == "on")
            {
                sost = "off";
            }
            else
            {
                sost = "on";
            }
        }
        public void yarkost()
        {
            Console.WriteLine("Введите желаемую яркость:");
            int b = Convert.ToInt32(Console.ReadLine());
            if (b < 0 || b > 100)
            {
                Console.WriteLine("от 0 до 100 только!!!");
                return;

            }
            else
            {
                yar = b;
            }
        }

        public void tempa()
        {
            Console.WriteLine("Введите желаемую температуру:");
            int с = Convert.ToInt32(Console.ReadLine());
            if (с < 2700 || с > 6500)
            {
                Console.WriteLine("от 2700 до 6500 только!!!");
                return;

            }
            else
            {
               temp = с;
            }

            if (temp <= 3000)
            {
                regim = "Ночь";

            }
            else if (temp > 3000 && temp <= 5000)
            {
                regim = "Чтение";
            }
            else if (temp > 5000)
            {
                regim = "День";
            }


        }

        public void regimi()
        {
            Console.WriteLine("Введите желаемый режим:");
            string b = Console.ReadLine();
            string d = b.ToLower();
            if (d == "ночь")
            {
                temp = 2000;

            } else if(d == "чтение")
            {
                temp = 4000;
            }
            else if (d == "день")
            {
                temp = 6000;
            }
            else
            {
                Console.WriteLine("Такого режима нет!!!");
                return;
            }
            if (temp <= 3000)
            {
                regim = "Ночь";

            }
            else if (temp > 3000 && temp <= 5000)
            {
                regim = "Чтение";
            }
            else if (temp > 5000)
            {
                regim = "День";
            }




        }



    }


    internal class Program
    {



        static void Main(string[] args)
        {
            Lampa lampa = new Lampa("off", 20, 2800);
            
            while (true)
            {
                
                lampa.PrintInfo();
                Console.WriteLine("1. Вкл/Выкл");
                Console.WriteLine("2. Изменить яркость");
                Console.WriteLine("3. Изменить температуру");
                Console.WriteLine("4. Изменить режим");
                Console.WriteLine("0. Выход");
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        lampa.onoff();
                        break;
                    case 2:
                        lampa.yarkost();
                            break;
                    case 3:
                        lampa.tempa();
                        break;
                    case 4:
                        lampa.regimi();
                        break;
                    case 0:
                        return;
                    default:
                        return;
                }

                


            }
        }
    }
    
}
