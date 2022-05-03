// 8.1.4. Придумайте простой класс, который будет предоставлять информацию об установленном в системе диске. 

//Нужны свойства, чтобы хранить: имя диска, объём, свободное место. Свойства инициализируются при создании нового объекта в методе-конструкторе.

class Disk
{
    public string name { get; }
    public long volume { get;  }
    public long freeSpace { get; }
    public Disk (string Name, long Volume, long FreeSpace)
    {
        name = Name;
        volume = Volume;
        freeSpace = FreeSpace;
    }

}
// 8.1.5.
//Сейчас пользователь видит, что у  вас на диске все файлы лежат в одной куче.

//Нужно создать папки (директории) для сортировки файлов. 

//Добавьте метод для создания новой директории на диске. Подумайте, какую коллекцию использовать для хранения созданных директорий.

//Пусть директория (папка) будет представлена классом: 

public class Folder
{
    public List<string> Files { get; set; } = new List<string>();
    Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();
    public void CreateFolder(string name)
    {
        Folders.Add(name, new Folder());
    }
}


