//ЗАДАНИЕ 3
//Доработайте программу из задания 1, используя ваш метод из задания 2.

//При запуске программа должна:
// 1. Показать, сколько весит папка до очистки. Использовать метод из задания 2. 
// 2. Выполнить очистку.
// 3. Показать сколько файлов удалено и сколько места освобождено.
// 4. Показать, сколько папка весит после очистки.

string link = @"C:\test\";
Folder folder = new Folder(link);
folder.FolderClean30min(folder.path);


public class Folder
{
    public string path;
    public Folder(string path)
    {
        this.path = path;
    }

    // очищает файлы по заданному пути и в подпапках, не изменявшихся последние 30 минут
    public void FolderClean30min(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (dir.Exists)
        {
            int deletedFilesNumber = 0;
            long memoryCleaned = 0;
            Console.WriteLine($"Папка: {dir.FullName}\t Размер до очистки: {GetLenght(dir.FullName)} байт");
            // имеем ли доступ к директории?
            try
            {
                // проверяем все файлы
                foreach (FileInfo file in dir.GetFiles())
                {
                    if ((DateTime.Now - file.LastWriteTime) > TimeSpan.FromMinutes(30))
                    {
                        deletedFilesNumber++;
                        memoryCleaned += file.Length;
                        file.Delete();
                        Console.WriteLine($"Файл: {file.FullName} - удален");
                    }
                    else
                    {
                        Console.WriteLine($"Файл: {file.FullName} - не удален");
                        continue;
                    }
                }

                // проверяем все подпапки и ищем в них файлы для очистки
                foreach (DirectoryInfo directory in dir.GetDirectories())
                {
                    FolderClean30min(directory.FullName, ref deletedFilesNumber, ref memoryCleaned);                   
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось выполнить: {e.Message}");
            }
            Console.WriteLine($"Удалено: {deletedFilesNumber} файлов \t Памяти освобождено: {memoryCleaned} байт");
            Console.WriteLine($"Папка: {dir.FullName}\t Размер после очистки: {GetLenght(dir.FullName)} байт");
        }

        else
        {
            Console.WriteLine($"Папка: {path}\t не существует");
        }
    }
    // перегрузка метода для подсчета удаленных файлов и размера освобожденной памяти (рекурсивный)
    public void FolderClean30min(string path, ref int deletedFilesNumber, ref long memoryCleaned)
    {
        DirectoryInfo subdir = new DirectoryInfo(path);
        try
        {
            // проверяем все файлы
            foreach (FileInfo file in subdir.GetFiles())
            {
                if ((DateTime.Now - file.LastWriteTime) > TimeSpan.FromMinutes(30))
                {
                    deletedFilesNumber++;
                    memoryCleaned += file.Length;
                    file.Delete();
                    Console.WriteLine($"Файл: {file.FullName} - удален");
                }
                else
                {
                    Console.WriteLine($"Файл: {file.FullName} - не удален");
                    continue;
                }
            }

            // проверяем все подпапки и ищем в них файлы для очистки
            foreach (DirectoryInfo directory in subdir.GetDirectories())
            {
                FolderClean30min(directory.FullName, ref deletedFilesNumber, ref memoryCleaned);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Не удалось выполнить: {e.Message}");
        }
    }
    static long GetLenght(string path)
    {


        DirectoryInfo folder = new DirectoryInfo(path);

        long sum = 0;
        try
        {
            foreach (FileInfo file in folder.GetFiles())
            {
                sum += file.Length;
            }
            foreach (DirectoryInfo directory in folder.GetDirectories())
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
}


