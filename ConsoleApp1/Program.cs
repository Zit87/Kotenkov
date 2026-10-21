using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1 - Открыть файл");
            Console.WriteLine("2 - Изменить файл");
            Console.WriteLine("3 - Создать файл");
            Console.WriteLine("0 - Выход");
            Console.Write("Выбор: ");

            switch (Console.ReadLine())
            {
                case "1": 
                    OpenFile();
                    break;
                case "2": 
                    EditFile();
                    break;
                case "3": 
                    CreateFile(); 
                    break;
                case "0":
                    return;
                default: Console.WriteLine("Неверный пункт"); break;
            }
        }
    }

    static void OpenFile()
    {
        Console.Write("Путь к файлу: ");
        string path = Console.ReadLine();
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден");
            return;
        }
        Console.WriteLine("--- Содержимое ---");
        Console.WriteLine(File.ReadAllText(path));
    }

    static void EditFile()
    {
        Console.Write("Путь к файлу: ");
        string path = Console.ReadLine();
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден");
            return;
        }

        Console.WriteLine("--- Текущий текст ---");
        Console.WriteLine(File.ReadAllText(path));

        Console.WriteLine("Введите новый текст (пустая строка - конец ввода):");
        string text = ReadMultiline();
        File.WriteAllText(path, text);

        Console.Write("Новое имя файла (Enter - оставить): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            string newPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(path)), newName);
            File.Move(path, newPath);
            path = newPath;
        }

        Console.Write("Новая папка (Enter - оставить): ");
        string newDir = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newDir))
        {
            Directory.CreateDirectory(newDir);
            string newPath = Path.Combine(newDir, Path.GetFileName(path));
            File.Move(path, newPath);
            path = newPath;
        }

        Console.WriteLine("Сохранено: " + Path.GetFullPath(path));
    }

    static void CreateFile()
    {
        Console.Write("Имя файла (например, note.txt): ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Имя не может быть пустым");
            return;
        }

        string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name);

        Console.WriteLine("Введите текст (пустая строка - конец ввода):");
        string text = ReadMultiline();

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(text);
        }
        Console.WriteLine("Файл создан: " + path);
    }

    static string ReadMultiline()
    {
        string result = "";
        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            result += line + Environment.NewLine;
        }
        return result;
    }
}