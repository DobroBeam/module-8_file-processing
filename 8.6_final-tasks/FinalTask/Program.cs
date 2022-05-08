using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string link = @"Students.dat";
            Binary file = new Binary(link);
            file.Read();
        }
        public static string[] GetList(Student[] objArray)
        {
            string[] Groups = new string[objArray.Length];
            

            for (int i = 0; i<objArray.Length; i++)
            {                
                {
                    Groups[i] = objArray[i].Group;
                    continue;
                }           
            }
            return Groups; 
        }
    }

    class Binary
    {

        string filepath;

        public Binary(string path)
        {
            filepath = path;
        }

        public void Read()
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
                    Program.GetList(newStudents);
                }
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
