using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

const string link = @"Students.dat";
Binary file = new Binary(link);
file.Read();

class Binary
{

    string filepath;

    public Binary (string path)
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
                //десириализуем из файла данные в виде объекта Pet
                var newStudent = (Student)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newStudent.Name} --- Группа: {newStudent.Group}");
            }

        }
    }

    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student (string name, string group, DateTime dateofbirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
        }
    }
}