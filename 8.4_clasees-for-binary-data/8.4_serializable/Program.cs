using System.Runtime.Serialization.Formatters.Binary;

// объект для сериализации
var person = new Pet("Rex", 2);
Console.WriteLine("Объект создан");
// создаем объект куда будем помещать объект для сериализации/десериализации
BinaryFormatter formatter = new BinaryFormatter();

// получаем поток, куда будем записывать сериализованный объект
using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
{
    // указываем объекту formatter куда и что будем сериализовывать
    formatter.Serialize(fs, person);
    Console.WriteLine("Объект сериализован");
}
// десериализация
using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
{
    //десириализуем из файла данные в виде объекта Pet
    var newPet = (Pet)formatter.Deserialize(fs);
    Console.WriteLine("Объект десериализован");
    Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}");
}
Console.ReadLine();


[Serializable]
class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Pet(string name, int age)
    {
        Name = name;
        Age = age;
    }
}