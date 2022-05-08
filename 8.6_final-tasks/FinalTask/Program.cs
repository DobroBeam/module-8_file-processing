using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string linkSource = @"Students.dat"; // ссылка на файл для считывания данных
            const string linkCast = @"C:\Users\Dmitry Lazarenko\Desktop\Students"; // ссылка на папку для сохранения данных
            Binary file = new Binary(linkSource);
            Directory.CreateDirectory(linkCast);
            foreach (Student student in file.Read())
            {
                string GroupFile = linkCast + @"\" + student.Group + ".txt"; // типовая ссылка на текстовый файл с номером группы
                using (StreamWriter sw = File.AppendText(GroupFile)) // запись в файл данных из массива Student[]
                {
                    sw.WriteLine($"{student.Name}, {student.DateOfBirth}");
                }                    
            }
            Console.WriteLine($"\nФайлы созданы в папке: {linkCast}") ;
        }       
    }

    class Binary
    {
        string filepath;

        public Binary(string path)
        {
            filepath = path;
        }

        public Student[] Read()
        {
            if (File.Exists(filepath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Console.WriteLine($"Чтение файла: {filepath}");
                using (var fs = new FileStream(filepath, FileMode.Open))
                {
                    //десириализуем из файла данные в виде массива Student[]
                    Student[] newStudents = (Student[])formatter.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");
                    foreach (Student student in newStudents)
                    {
                        Console.WriteLine($"Имя: {student.Name} --- Группа: {student.Group} --- Дата рождения: {student.DateOfBirth}");
                    }
                    return newStudents;
                }
            }
            else
            {
                Console.WriteLine($"Файл не найден:{filepath}");
                return null;
            }
        }        
    }
    
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public Student(string name, string group, DateTime dateofbirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
        }
    }
}
