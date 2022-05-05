
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
try
{
    // создание новой директории
    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\new folder 1");
    if (!dirInfo.Exists)
        dirInfo.Create();
    // dirInfo.CreateSubdirectory("new folder 2");
    Console.WriteLine($"создана папка: {dirInfo.CreateSubdirectory("new folder 3")}");
    Console.WriteLine($"Название каталога: {dirInfo.Name}");
    Console.WriteLine($"Полное название (путь) каталога: {dirInfo.FullName}");
    Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
    Console.WriteLine($"Корневой каталог: {dirInfo.Root}");

    string newPath = @"C:\test\";
    if (dirInfo.Exists && Directory.Exists(newPath))
        dirInfo.MoveTo(newPath);
    else
        

    Console.ReadKey();
    dirInfo.Delete(true);
    Console.WriteLine($"Каталог: {dirInfo.FullName} удален со всем содержимым");
}
catch (Exception ex)
{ Console.WriteLine(ex.Message); }



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

        // 8.2.1 посчитать сумму элементов (папки + файлы) в директории
        int sum = dirs.GetLength(0) + files.GetLength(0);
        Console.WriteLine($"Всего элементов: {sum}");
    }
}



