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

        class Person
        {
            
            public string jopa;

            public Person(string jopa) { 
            this.jopa = jopa;

            }
            virtual public void PrintInfo()
            {
                
            }
        }

        class Student : Person
        {
            public int Id { get; set; }
            public string jopa2;

            public Student(int Id, string jopa2, string jopa) : base (jopa)
            {
                this.Id = Id;
                this.jopa2 = jopa2;
            }
            override public void PrintInfo()
            {
                Console.WriteLine($"{Id}  {jopa2} {jopa}");
            }
        }

        class Teacher : Person
        {
            public string jopa3;
            public int mani;

            public Teacher(int mani, string jopa3, string jopa) : base(jopa)
            {
                this.jopa3 = jopa3;
                this.mani = mani;
            }
            override public void PrintInfo()
            {
                Console.WriteLine($"{jopa3}  {mani} {jopa}");
            }
        }


        class Guest : Person
        {
            public int skebob;
            public string jopa4;


            public Guest(int skebob, string jopa4, string jopa) : base(jopa)
            {
                this.jopa4 = jopa4;
                this.skebob = skebob;
            }

            override public void PrintInfo()
            {
                Console.WriteLine($"{skebob}  {jopa4} {jopa}");
            }
        }

        static void Main(string[] args)
        {
            List<Person> person = new List<Person>();
            



            person.Add(new Student(1,"жопа2", "жопа"));
            person.Add(new Teacher(67,"жопа3", "жопа"));
            person.Add(new Guest(52,"жопа4", "жопа"));


            foreach (Person p in person)
            {

                if (p is Student stud)
                {
                    stud.PrintInfo();
                    continue;
                }
               else if (p is Teacher tech)
                {
                    tech.PrintInfo();
                    continue;
                }else if (p is Guest gus)
                {
                    gus.PrintInfo();
                    continue;
                }
                else
                {
                    Console.WriteLine("Преобразование не допустимо");
                }







            }
        }

    }
}
