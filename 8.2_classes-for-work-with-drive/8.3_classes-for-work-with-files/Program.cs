// Допустим, нам нужно создать файл и записать в него информацию, в коде выполним следующие действия: 
// * Проверим существование файла
// * Если не существует, создадим его и запишем строку.
// * Откроем файл и прочитаем ранее записанную строку.

string filePath = @"C:\test\text.txt"; // Укажем путь 

if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
{
    //   Если не существует - создаём и записываем в строку
    using (StreamWriter sw = File.CreateText(filePath))  // Конструкция Using (будет рассмотрена в последующих юнитах)
    {
        sw.WriteLine("Олег");
        sw.WriteLine("Дмитрий");
        sw.WriteLine("Иван");
    }
}
// Откроем файл и прочитаем его содержимое
using (StreamReader sr = File.OpenText(filePath))
{
    string str = "";
    while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
    {
        Console.WriteLine(str);
    }
}

//Задание 8.3.1
//Исходный код программы — ещё один отличный пример текстового файла. 
//Напишите программу, которая выводит свой собственный исходный код в консоль.

string codePath = @"C:\Users\Dmitry Lazarenko\source\repos\module-8\8.2_classes-for-work-with-drive\8.3_classes-for-work-with-files\Program.cs";

using (StreamReader sr = File.OpenText(codePath))
{
    string str = "";
    while ((str = sr.ReadLine()) != null)
    {
        Console.WriteLine(str);
    }
}
//Задание 8.3.2
//Сделайте так, чтобы ваша программа из задания 8.3.1 при каждом запуске добавляла в свой исходный код
//комментарий о времени последнего запуска. 
FileInfo code = new FileInfo(codePath);
using (StreamWriter sw = code.AppendText())
{
    sw.WriteLine();
    sw.WriteLine($"// Последний запуск программы: {DateTime.Now}");
}

// Последний запуск программы: 06.05.2022 13:19:38

// Последний запуск программы: 06.05.2022 13:19:56
