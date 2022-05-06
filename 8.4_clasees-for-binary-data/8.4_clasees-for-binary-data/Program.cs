class BinaryExperiment
{
    const string path = @"C:\Users\Dmitry Lazarenko\Desktop\BinaryFile.bin";

    static void Main()
    {
        
        // Считываем
        ReadValues();
        // Пишем
        WriteValues();
        // Снова считытваем
        ReadValues();
    }

    static void WriteValues()
    {
        // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
        {
            // записываем данные в строковом формате
            writer.Write($"Файл изменен {DateTime.Now} на компьютере Windows 10\n");
        }
    }

    static void ReadValues()
    {
        string StringValue;
        
        if (File.Exists(path))
        {
            Console.WriteLine("Из файла считано:");
            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                // Применяем специализированные методы Read для считывания соответствующего типа данных.
                try
                {
                    while ((StringValue = reader.ReadString()) != null)
                    {
                        Console.WriteLine("Строка: " + StringValue);
                    }
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Чтение завершено: {e.Message}");
                }      
            }
        }
    }
}