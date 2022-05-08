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




//Задание 8.4.3
//Дан класс.Доработайте его и сериализуйте в бинарный формат.
// объект для сериализации
var contact = new Contact("John", 1234567890, "test@mail.com");
Console.WriteLine("Объект создан");
// создаем объект куда будем помещать объект для сериализации/десериализации
BinaryFormatter formatter2 = new BinaryFormatter();

// получаем поток, куда будем записывать сериализованный объект
using (var fs = new FileStream("myContacts.dat", FileMode.OpenOrCreate))
{
    // указываем объекту formatter куда и что будем сериализовывать
    formatter2.Serialize(fs, contact);
    Console.WriteLine("Объект сериализован");
}

[Serializable]
class Contact
{
    public string Name { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, long phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}

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