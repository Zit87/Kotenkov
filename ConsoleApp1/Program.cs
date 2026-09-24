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


    internal class Program
    {
        class Metodi
        {
            public double Area(double a)
            {
                return a * a;
            }

            public double Perimeter(double a)
            {
                return a * 4;
            }

            public double Area(double a, double b)
            {
                return a * b;
            }
            public double Perimeter(double a, double b)
            {
                return (a + b) * 2;
            }

            public double Area(double a, double b, double c)
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - c));
            }
            public double Perimeter(double a, double b, double c)
            {
                return a + b + c;
            }
            public double Area(double r, bool d)
            {
                if (d)
                {
                    return Math.PI * r * r;
                }
                else
                {
                    return 0;
                }

            }


            public double Perimeter(double r, bool d)
            {
                if (d)
                {
                    return Math.PI * r * 2;
                }
                else
                {
                    return 0;
                }
            }

            public double Area(double[] x, double[] y)
            {
                double sum = 0;

                for (int i = 0; i < x.Length; i++)
                {
                    int next = (i + 1) % x.Length;

                    sum += x[i] * y[next] - y[i] * x[next];
                }

                return Math.Abs(sum) / 2;
            }

            public double Perimeter(double[] x, double[] y)
            {
                double sum = 0;

                for (int i = 0; i < x.Length; i++)
                {
                    int next = (i + 1) % x.Length;

                    sum += Math.Sqrt(
                        Math.Pow(x[next] - x[i], 2) +
                        Math.Pow(y[next] - y[i], 2)
                    );
                }

                return sum;
            }

        }

            static void Main(string[] args)
            {
            
            Metodi metodi = new Metodi();
            Console.WriteLine(metodi.Area(5));
            Console.WriteLine(metodi.Perimeter(5));
            Console.WriteLine(metodi.Area(2,4));
            Console.WriteLine(metodi.Perimeter(2,4));
            Console.WriteLine(metodi.Area(3,4,5));
            Console.WriteLine(metodi.Perimeter(3,4,5));
            Console.WriteLine(metodi.Area(5, true));
            Console.WriteLine(metodi.Perimeter(5, true));
        }

    }
}

