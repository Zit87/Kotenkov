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
    class Transport {
        public int mosch;

        public int kolkol;
        public int maxsp;

        public Transport(int mosch, int kolkol, int maxsp)
        {
            this.kolkol = kolkol;
            this.mosch = mosch;
            this.maxsp = maxsp;
        }
    
        public virtual void Print()
        {
            Console.WriteLine($"Мощность двигателя {mosch} количество колес {kolkol} макс скорость {maxsp}");
        }

    }
    class Mashina : Transport{
        public string brend;
        public Mashina(int mosch, int kolkol, int maxsp, string brend) : base(mosch, kolkol, maxsp)
        {
            this.brend = brend;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Бренд {brend} ");
        }

    }
    class Skuter : Transport {
        public string tipdv;
        public Skuter(int mosch, int kolkol, int maxsp, string tipdv) : base(mosch, kolkol, maxsp)
        {
            this.tipdv = tipdv;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Тип двигателя {tipdv} ");
        }
    }
    class Elektrosamokat : Transport {
        public int oba;
        public Elektrosamokat(int mosch, int kolkol, int maxsp, int oba) : base(mosch, kolkol, maxsp)
        {
            this.oba = oba;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Обьем аккамулятора  {oba} ");
        }
    }

 


    internal class Program
    {



        static void Main(string[] args)
        {
            var transportall = new List<Transport>{
                new Mashina(1500, 4 , 320, "mesedes"),
                new Skuter(50,2,60,"2такта"),
                new Elektrosamokat(250,2,55,50000),
            };

            foreach (var t in transportall)
            {
                t.Print();
            }

        }
    }
    
}
