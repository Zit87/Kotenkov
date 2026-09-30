
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class User
    {
        public string FullName { get; set; }
        public string Login { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> Hobbies { get; set; }

        public User(string fullName, string login, DateTime dateOfBirth, List<string> hobbies)
        {
            FullName = fullName;
            Login = login;
            DateOfBirth = dateOfBirth;
            Hobbies = hobbies;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User("Иванов Иван Иванович", "ivanovii",
                    new DateTime(1990, 5, 18),
                    new List<string> { "Чтение", "Путешествия", "Программирование" }),

                new User("Петров Петр Петрович", "petrovpp",
                    new DateTime(1985, 10, 2),
                    new List<string> { "Футбол", "Кулинария" }),

                new User("Сидорова Анна Михайловна", "sidorovana",
                    new DateTime(2000, 3, 15),
                    new List<string> { "Рисование", "Программирование" }),

                new User("Смирнов Алексей Николаевич", "smirnovan",
                    new DateTime(1995, 7, 30),
                    new List<string> { "Хоккей", "Фотография" }),

                new User("Кузнецова Ольга Валерьевна", "kuznetsovao",
                    new DateTime(1992, 12, 12),
                    new List<string> { "Йога", "Путешествия" })
            };


        
            Console.WriteLine("1. Пользователи старше 30 лет:");

            var older30 = users.Where(u =>
                DateTime.Now.Year - u.DateOfBirth.Year -
                (DateTime.Now < u.DateOfBirth.AddYears(
                    DateTime.Now.Year - u.DateOfBirth.Year) ? 1 : 0) > 30);

            foreach (var user in older30)
                Console.WriteLine(user.FullName);

  


          
            Console.WriteLine("2. Логины по алфавиту:");

            var logins = users
                .Select(u => u.Login)
                .OrderBy(login => login);

            foreach (var login in logins)
                Console.WriteLine(login);


       
            Console.WriteLine("3. Пользователи с хобби Программирование:");

            var programmers = users
                .Where(u => u.Hobbies.Contains("Программирование"));

            foreach (var user in programmers)
                Console.WriteLine(user.FullName);




        
            Console.WriteLine("4. Группировка по году рождения:");

            var groupsByYear = users
                .GroupBy(u => u.DateOfBirth.Year)
                .OrderBy(g => g.Key);

            foreach (var group in groupsByYear)
                Console.WriteLine($"{group.Key} -> {group.Count()}");

         


          
            Console.WriteLine("5. Словарь login -> FullName:");

            Dictionary<string, string> userDictionary = users
                .ToDictionary(u => u.Login, u => u.FullName);

            foreach (var item in userDictionary)
                Console.WriteLine($"{item.Key} -> {item.Value}");

 


   
            Console.WriteLine("6. Самый молодой и самый старый:");

            var youngest = users
                .OrderByDescending(u => u.DateOfBirth)
                .First();

            var oldest = users
                .OrderBy(u => u.DateOfBirth)
                .First();

            Console.WriteLine( $"Самый молодой: {youngest.FullName}, " + $"дата рождения: {youngest.DateOfBirth:dd.MM.yyyy}");

            Console.WriteLine($"Самый старый: {oldest.FullName}, " + $"дата рождения: {oldest.DateOfBirth:dd.MM.yyyy}");



      
            Console.WriteLine("7. Уникальные хобби:");

            var hobbies = users
                .SelectMany(u => u.Hobbies)
                .Distinct()
                .OrderBy(h => h);

            foreach (var hobby in hobbies)
                Console.WriteLine(hobby);




            Console.WriteLine("8. Количество пользователей с хобби Путешествия:");

            int travelers = users
                .Count(u => u.Hobbies.Contains("Путешествия"));

            Console.WriteLine(travelers);

            Console.WriteLine();


     
            Console.WriteLine("9. Пользователи на букву С:");

            var letterC = users
                .Where(u => u.FullName.StartsWith("С"));

            foreach (var user in letterC)
                Console.WriteLine(user.FullName);

            Console.WriteLine();


 
            Console.WriteLine("10. Два пользователя с наибольшим количеством хобби:");

            var topTwo = users
                .OrderByDescending(u => u.Hobbies.Count)
                .ThenBy(u => u.Login)
                .Take(2);

            foreach (var user in topTwo)
            {
                Console.WriteLine( $"{user.FullName} ({user.Login}) - " + $"хобби: {user.Hobbies.Count}");
            }
        }
    }
}