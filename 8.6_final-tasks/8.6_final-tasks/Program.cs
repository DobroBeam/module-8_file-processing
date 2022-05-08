//ЗАДАНИЕ 1
//Напишите программу, которая чистит нужную нам папку от файлов  и папок, которые не использовались более 30 минут 
string link = @"C:\test\";
//FolderClean(link);

//ЗАДАНИЕ 2
//Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами). На вход метод принимает URL директории, в ответ — размер в байтах.
DirectoryInfo dir = new DirectoryInfo(link);
if (dir.Exists)
{
    Console.WriteLine($"Папка: {link}\t Размер: {GetLenght(link)} байт");
}
else
{
    Console.WriteLine($"Папка: {link}\t не существует");
}



// Задание 1
static void FolderClean (string path)
{
    // имеем ли доступ к директории?
    try
    {
        DirectoryInfo folder = new DirectoryInfo(path);
        // существует ли данная директория?
        if (folder.Exists)
        {
            // проверяем все файлы
            foreach (FileInfo file in folder.GetFiles())
            {
                if ((DateTime.Now - file.LastWriteTime) > TimeSpan.FromMinutes(30))
                {
                    file.Delete();
                    Console.WriteLine($"Файл: {file.FullName} - удален");
                }
                else
                {
                    Console.WriteLine($"Файл: {file.FullName} - не удален");
                    continue;
                }
            }

            // проверяем все папки
            foreach (DirectoryInfo directory in folder.GetDirectories())
            {
                if ((DateTime.Now - directory.LastWriteTime) > TimeSpan.FromMinutes(30))
                {
                    directory.Delete(true);
                    Console.WriteLine($"Директория: {directory.FullName} - удалена");
                }
                else
                {
                    Console.WriteLine($"Директория: {directory.FullName} - не удалена");
                    continue;
                }
            }
        }
        else
            Console.WriteLine("Директории по данной ссылке не существует");
    }
    catch(Exception e)
    {
        Console.WriteLine($"Не удалось выполнить: {e.Message}");
    }
}
// Задание 2
static long GetLenght (string path)
{
    
    
    DirectoryInfo folder = new DirectoryInfo(path);

    long sum = 0;
    try
    {
        foreach (FileInfo file in folder.GetFiles())
        {
            sum += file.Length;
        }
        foreach(DirectoryInfo directory in folder.GetDirectories())
        {
            sum += GetLenght(directory.FullName);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Не удалось рассчитать: {e.Message}");
    }
    
    return sum;
}