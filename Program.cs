using System;
using System.IO;

namespace FileSearchTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке, в которой нужно искать файлы:"); 
            string path = Console.ReadLine();


            Console.WriteLine("Введите расширение файлов (например, txt):");
            string extension = Console.ReadLine();

            Console.WriteLine("Введите текст, который должен содержаться в файле:");
            string searchText = Console.ReadLine();

            SearchFiles(path, extension, searchText);
        }

        static void SearchFiles(string path, string extension, string searchText)
        {
            try
            {
                string[] files = Directory.GetFiles(path, $"*.{extension}", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    if (File.ReadAllText(file).Contains(searchText))
                    {
                        Console.WriteLine($"Файл '{file}' содержит текст '{searchText}'");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}