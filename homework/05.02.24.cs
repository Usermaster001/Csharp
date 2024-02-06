using System;

public class Manager{
    private string path;
    private DirectoryInfo directory;

    public Manager(string _path){
        path = _path;
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        directory = directoryInfo;
    }

    public void printPath(){System.Console.WriteLine($"Path:{directory.FullName}");}

    public void dirs(){
        if (directory.Exists)
        {
            Console.WriteLine("Directory:");
            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                Console.WriteLine(dir.FullName);
            }
        } else {
            System.Console.WriteLine("Error!");
        }
        System.Console.WriteLine("\n");
    }

    public void files(){
        if(directory.Exists){
            System.Console.WriteLine("Files:");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files){
                System.Console.WriteLine(file.FullName);
            }
        } else {
            System.Console.WriteLine("Error!");
        }
        System.Console.WriteLine("\n");
    }

    public void move(string newPath){
        DirectoryInfo tmp = new DirectoryInfo(newPath);
        if(directory.Exists && tmp.Exists){
            directory = tmp;
            System.Console.WriteLine("done");
        }
        else{
            System.Console.WriteLine("Error!");
        }
    }

    public void back(){
        if(directory.FullName != "/"){
            var tmp = directory.Parent;
            directory = tmp;
        }
        else{
            System.Console.WriteLine("Error!");
        }
    }

}

public class HelloWorld
{
    public static void Main(string[] args){
        System.Console.WriteLine("Giv the peth(/.../.../...):");
        string path = Console.ReadLine();
        bool check = true;
        Manager manager = new Manager(path);
        

        while(check == true){
            System.Console.WriteLine("command:");
            string command = Console.ReadLine();
            switch (command)
            {
                case "help":
                    System.Console.WriteLine("1)вывод всех директорий по команде - dirs");
                    System.Console.WriteLine("2)вывод всех файлов по команде - files");
                    System.Console.WriteLine("3)перемещение назад по директориям по команде - back");
                    System.Console.WriteLine("4)перемещение по директориям на выбор - move");
                    System.Console.WriteLine("5)вывод - path");
                    break;
                case "path":
                    manager.printPath();
                    break;
                case "dirs":
                    manager.dirs();
                    break;
                case "files":
                    manager.files();
                    break;
                case "back":
                    manager.back();
                    break;
                case "move":
                    System.Console.WriteLine("New path:");
                    string newPath = Console.ReadLine();
                    manager.move(newPath);
                    break;
                default:
                    System.Console.WriteLine("Error\nall command - help");
                    break;
            }
        }
    }
}