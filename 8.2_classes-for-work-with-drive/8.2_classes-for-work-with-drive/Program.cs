
// получим системные диски в виде массива типов DriveInfo
DriveInfo[] drives = DriveInfo.GetDrives();

//выведем на консоль информацию о каждом диске 
foreach (DriveInfo drive in drives)
{
    Console.WriteLine($"Название: {drive.Name}");
    Console.WriteLine($"Тип: {drive.DriveType}");
    if (drive.IsReady)
    {
        Console.WriteLine($"Объем: {drive.TotalSize}");
        Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
        Console.WriteLine($"Метка: {drive.VolumeLabel}");
    }
}
GetCatalogs();

static void GetCatalogs()
{
    string dirName = @"C:\"; // Прописываем путь к корневой директории Windows
    if (Directory.Exists(dirName)) // Проверим, что директория существует
    {
        Console.WriteLine("Папки:");
        string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

        foreach (string d in dirs) // Выведем их все
            Console.WriteLine(d);

        Console.WriteLine();
        Console.WriteLine("Файлы:");
        string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

        foreach (string s in files)   // Выведем их все
            Console.WriteLine(s);
    }
}

