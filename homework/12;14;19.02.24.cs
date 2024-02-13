using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net;
using System.Collections;


public class Test : IComparer{

    public int Compare(object x, object y)
    {
        int obj1 = (int)x;
        int obj2 = (int)y;
        if(obj1 > obj2){
            return 1;
        }
        return 0;
    }
}


public class ExceptionFileEmpty : Exception {
    public ExceptionFileEmpty(string message) : base(message){}
}


public class Manager : Test{
    private DirectoryInfo directory;

    public string GetPath(){
        return directory.FullName;
    }

    public Manager(string path){
        DirectoryInfo checkDirectory = new DirectoryInfo(path);
        if(checkDirectory.Exists){
            directory = checkDirectory;
            System.Console.WriteLine("done;\n");
        }
        else{
            System.Console.WriteLine("Error!There is no such directory.\nYour path:");
            DirectoryInfo homeDirectory = new DirectoryInfo("/home/user");
            directory = homeDirectory;
            Path();
            System.Console.WriteLine("\n");
        }
    }


    public void Path(){
        System.Console.WriteLine(GetPath());
    }


    public void Dirs(){
        Console.WriteLine("Directory:");
        DirectoryInfo[] dirs = directory.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            Console.WriteLine(dir.FullName);
        }
        System.Console.WriteLine("\n");
    }


    public void Files(){
        System.Console.WriteLine("Files:");
        FileInfo[] files = directory.GetFiles();
        foreach (FileInfo file in files){
            System.Console.WriteLine(file.FullName);
        }
        System.Console.WriteLine("\n");
    }


    public void Move(){
        System.Console.WriteLine("new path:");
        string? newPath = Console.ReadLine();
        if(newPath.Length == 0){
            throw new ExceptionFileEmpty("Exception!File name not entered.\n");
        }
        else{
            DirectoryInfo newDirectory = new DirectoryInfo(newPath);
            if(newDirectory.Exists){
                directory = newDirectory;
                System.Console.WriteLine("done;\n");
            }
            else{
                System.Console.WriteLine("Error!There is no such directory.\n");
            }
        }
    }


    public void Back(){
        if(directory.FullName != "/"){
            DirectoryInfo? backDirectory = directory.Parent;
            directory = backDirectory;
        }
        else{
            System.Console.WriteLine("Error!Root directory.");
        }
    }


    public void Cd(){
        System.Console.WriteLine("subdirectory in your directory:");
        string? newSubDir = Console.ReadLine();
        DirectoryInfo checkDirectory = new DirectoryInfo(directory.FullName + "/" + newSubDir);
        if(checkDirectory.Exists){
            directory = checkDirectory;
            System.Console.WriteLine("done;\n");
        }
        else{
            System.Console.WriteLine("Error!There is no such directory.\n");
        }
    }


    public void CreateFile(){
        System.Console.WriteLine("name file:");
        string? inputFile = Console.ReadLine();
        if(inputFile.Length == 0){
            throw new ExceptionFileEmpty("Exception!File name not entered.\n");
        }
        else{
            string checkInputFile = @"^[^0-9а-яА-Я]{1,15}.txt$";
            if(Regex.IsMatch(inputFile, checkInputFile)){
                if(!File.Exists(directory.FullName + "/" + inputFile)){
                    File.Create(directory.FullName + "/" + inputFile);
                    System.Console.WriteLine("done;\n");
                }
                else{
                    System.Console.WriteLine("Error!Such a file already exists.\n");
                }
            }
            else{
                System.Console.WriteLine("Error!Your file is not a template format.\n");
            }
        }
    }


    public void Mkdir(){
        System.Console.WriteLine("Name dir:");
        string? inputSubDir = Console.ReadLine();
        if(inputSubDir.Length == 0){
            throw new ExceptionFileEmpty("Exception!Subdir name not entered.\n");
        }
        else{
            string checkInputSubDir = @"^[^0-9а-яА-Я]{1,15}";
            if(Regex.IsMatch(inputSubDir,checkInputSubDir)){
                DirectoryInfo createDir = new DirectoryInfo(directory + "/" + inputSubDir);
                if(!createDir.Exists){
                    createDir.Create();
                    System.Console.WriteLine("done;\n");
                }
                else{
                    System.Console.WriteLine("Error!Such a subdirectory already exists.\n");
                }
            }
            else{
                System.Console.WriteLine("Error!Your file is not a template format.\n");
            }
        }
    }


    private bool CheckResponse(string nameCheck, string what){
        System.Console.WriteLine($"your {nameCheck} will be deleted: {what}\nare you sure(yes/no)?:");
        string? check = Console.ReadLine();
        if(check == "yes"){
            return true;
        }
        return false;
    }


    private void RmdirTemplate(){
        if(CheckResponse("subdirectory", directory.FullName) == true){
            DirectoryInfo newDirectory = new DirectoryInfo(directory.FullName);
            newDirectory.Delete(true);
            System.Console.WriteLine("done;\n");
            Back();
        }
        else{
            System.Console.WriteLine("ok.\n");
        }
    }


    public void Rmdir(){
        System.Console.WriteLine("1)actual subdirectory\n2)othet directory\nn(number):");
        string n = Console.ReadLine();
        if(n == "1"){
            RmdirTemplate();
        }
        else if(n == "2"){
            Move();
            RmdirTemplate();
        }
        else{
            System.Console.WriteLine("Error!");
        }
    }

    
    public void DeleteFile(){
        System.Console.WriteLine("the path to the file:");
        string pathFile = Console.ReadLine();
        if(pathFile.Length == 0){
            throw new ExceptionFileEmpty("Exception!File name not entered.\n");
        }
        else{
            if(File.Exists(pathFile)){
                if(CheckResponse("file", pathFile) == true){
                    File.Delete(pathFile);
                    System.Console.WriteLine("done;\n");
                }
                else{
                    System.Console.WriteLine("ok.\n");
                }
            }   
            else{
                System.Console.WriteLine("Error!There is no such file.\n");
            }
        }
    }


    public async void Cat(){
        System.Console.WriteLine("path:");
        string pathForCat = Console.ReadLine();
        System.Console.WriteLine("text:");
        string text = Console.ReadLine();

        if(File.Exists(pathForCat)){
            System.Console.WriteLine("1)Restart cat\n2)Continue cat in file\nn(number):");
            string check = Console.ReadLine();
            if(check == "2"){
                using(StreamWriter writer = new StreamWriter(pathForCat, true)){
                    await writer.WriteLineAsync(text);
                }
                System.Console.WriteLine("done;\n");
            }
            else if(check == "1"){
                using(StreamWriter writer = new StreamWriter(pathForCat, false)){
                    await writer.WriteLineAsync(text);
                }
                System.Console.WriteLine("done;");
            }
        }
        else{
            System.Console.WriteLine("Error!There is no such file.\n");
        }
    }


    public void Read(){
        System.Console.WriteLine("path:");
        string pathForCat = Console.ReadLine();
        if(File.Exists(pathForCat)){
            using(StreamReader reader = new StreamReader(pathForCat)){
                string text = reader.ReadToEnd();
                System.Console.WriteLine(text);
                reader.Close();
            }
        }
        else{
            System.Console.WriteLine("Error!There is no such file.\n");
        }
    }

    
    public int ChetElement(string path){
        int result = 0;
 
        using (StreamReader reader = new StreamReader(path))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach(string word in line.Split(new char[]{' '})){
                    result++;
                }
            }
        }
        return result;
    }

    public void ManagerCompare(){
        Test test = new Test();
        System.Console.WriteLine("first file path:");
        string pathFileFirst = Console.ReadLine();
        System.Console.WriteLine("second file path:");
        string pathFileSecond = Console.ReadLine();

        if(File.Exists(pathFileFirst) && File.Exists(pathFileSecond)){
            int firstFileElement = ChetElement(pathFileFirst);
            int secondFileElement = ChetElement(pathFileSecond);
            
            if(test.Compare(firstFileElement, secondFileElement) == 1){
                System.Console.WriteLine("firstFile > secondFile");
            }
            else{
                System.Console.WriteLine("firstFile < secondFile");
            }
        }
        else{
            System.Console.WriteLine("Error!There is no such file.\n");
        }
    }
}

public class Program
{
    public static void MyConsole(){
        System.Console.WriteLine("Giv the peth(/.../.../...):");
        string? path = Console.ReadLine();
        Manager manager = new Manager(path);
        bool check = true;

        while(check == true){
            try{
                string pathUser = manager.GetPath();
                System.Console.WriteLine($"command: {pathUser}");
                string? command = Console.ReadLine();
                switch (command)
                {
                    case "help":
                        System.Console.WriteLine("1)вывод всех директорий по команде - dirs");
                        System.Console.WriteLine("2)вывод всех файлов по команде - files");
                        System.Console.WriteLine("3)перемещение назад по директориям по команде - back");
                        System.Console.WriteLine("4)перемещение по директориям на выбор - move");
                        System.Console.WriteLine("5)перемещение в следущий каталог - cd");
                        System.Console.WriteLine("6)выход - exit");
                        System.Console.WriteLine("7)вывод - path");
                        System.Console.WriteLine("8)создание файла - createFile");
                        System.Console.WriteLine("9)создание каталога - mkdir");
                        System.Console.WriteLine("10)удаление каталога - rmdir");
                        System.Console.WriteLine("11)удаление file - deleteFile");
                        System.Console.WriteLine("12)open file - openFile");
                        System.Console.WriteLine("13)cat in file - cat");
                        System.Console.WriteLine("14)read file - read");
                        System.Console.WriteLine("15)file comparison - compare");
                        break;
                    case "compare":
                        manager.ManagerCompare();
                        break;
                    case "read":
                        manager.Read();
                        break;
                    case "cat":
                        manager.Cat();
                        break;
                    case "deleteFile":
                        manager.DeleteFile();
                        break;
                    case "rmdir":
                        manager.Rmdir();
                        break;
                    case "mkdir":
                        manager.Mkdir();
                        break;
                    case "createFile":
                        manager.CreateFile();
                        break;
                    case "path":
                        manager.Path();
                        break;
                    case "dirs":
                        manager.Dirs();
                        break;
                    case "files":
                        manager.Files();
                        break;
                    case "back":
                        manager.Back();
                        break;
                    case "cd":
                        manager.Cd();
                        break;
                    case "move":
                        manager.Move();
                        break;
                    case "exit":
                        check = false;
                        break;
                    default:
                        System.Console.WriteLine("Error!All command - help");
                        break;
                }
            }
            catch(ExceptionFileEmpty ex){
                System.Console.WriteLine(ex.Message);
            }
        }
    }

    public static void Main(string[] args){
        MyConsole();
    }
}