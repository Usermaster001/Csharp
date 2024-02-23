using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;

public class Game{
    private List<Player> listPlayers = new List<Player>();
    private List<Karta> listKarta = new List<Karta>();

    public int IntToString(string str){
        if(str == "туз"){
            return 14;
        }
        else if(str == "король"){
            return 13;
        }
        else if(str == "дама"){
            return 12;
        }
        else if(str == "валет"){
            return 11;
        }
        return Convert.ToInt16(str);
    }

    public void GameGame(){
        bool check = false;
        while(check == false){
            System.Console.WriteLine($"Player {listPlayers[0].GetName()}");
            System.Console.WriteLine("Выберите карту:(number)");
            listPlayers[0].PrintCard();
            int indexPlayer1 = Convert.ToInt32(Console.ReadLine());
            string numberKartaPlayer1 = listPlayers[0].GetNumberKarta(indexPlayer1);
            
            System.Console.WriteLine("\n");
            
            System.Console.WriteLine($"Player {listPlayers[1].GetName()}");
            System.Console.WriteLine("Выберите карту:(number)");
            listPlayers[1].PrintCard();
            int indexPlayer2 = Convert.ToInt32(Console.ReadLine());
            string numberKartaPlayer2 = listPlayers[1].GetNumberKarta(indexPlayer2);

            int response1 = IntToString(numberKartaPlayer1);
            int response2 = IntToString(numberKartaPlayer2);

            if(response1 > response2){
                System.Console.WriteLine($"\nPlayer {listPlayers[0].GetName()} win\n");
                listPlayers[0].AddKarta(listPlayers[1].GetKarta(indexPlayer2));
                listPlayers[1].DeleteKarta(indexPlayer2);
            }
            else{
                System.Console.WriteLine($"\nPlayer {listPlayers[1].GetName()} win\n");
                listPlayers[1].AddKarta(listPlayers[0].GetKarta(indexPlayer2));
                listPlayers[0].DeleteKarta(indexPlayer2);
            }

            if(listPlayers[0].GetCountKarts() <= 0){
                System.Console.WriteLine($"\nPlayer {listPlayers[0].GetName()} win\n");
                check = true;
            }
            if(listPlayers[1].GetCountKarts() <= 0){
                System.Console.WriteLine($"\nPlayer {listPlayers[1].GetName()} win\n");
                check = true;
            }
        }
    }

    private void CreateListPlayers(int countPlayers){
        for(int i = 0;i < countPlayers;i++){
            System.Console.WriteLine($"Name player {i + 1}:");
            string? name = Console.ReadLine();
            Player player = new Player(name);
            listPlayers.Add(player);
        }
    }
    private void CreateListKarta(){
        string[] colors = ["черви", "крести", "буби", "пики"];
        for(int i = 6;i < 15;i++){
            foreach(string color in colors){
                Karta newKarta = new Karta(color, i.ToString());
                listKarta.Add(newKarta);
            }
        }
        MoveKarts();
    }

    private void MoveKarts(){
        List<Karta> result = new List<Karta>();
        List<Karta> test = listKarta;
        Random rnd = new Random();
        while(test.Count != 0){
            int random = rnd.Next(0,test.Count);
            result.Add(test[random]);
            test.RemoveAt(random);
        }
        listKarta = result;
    }

    private void Dealingkarts(){
        int delKarta = 36 / listPlayers.Count;
        foreach(Player player in listPlayers){
            for(int i = 0;i < delKarta;i++){
                player.AddKarta(listKarta[i]);
            }
            listKarta.RemoveRange(0,delKarta);
        }
    }

    public Game(int countPlayers){
        CreateListKarta();
        CreateListPlayers(countPlayers);
        Dealingkarts();
    }

    public void PrintListKart(){
        for(int i = 0;i < listKarta.Count;i++){
            listKarta[i].PrintTypeColor(i + 1);
        }
        System.Console.WriteLine(listKarta.Count);
    }
    
    public void PrintListPlayers(){
        for(int i = 0;i < listPlayers.Count;i++){
            System.Console.WriteLine($"Player {listPlayers[i].GetName()}:");
            listPlayers[i].PrintCard();
            System.Console.WriteLine("\n");
        }
    }

}

public class Player{
    private List<Karta> kartPlayer = new List<Karta>();
    private string name = "default";

    public Player(string _name){
        name = _name;
    }

    public void DeleteKarta(int index){
        kartPlayer.RemoveAt(index - 1);
    }

    public Karta GetKarta(int index){
        return kartPlayer[index - 1];
    }

    public string GetNumberKarta(int index){
        return kartPlayer[index - 1].GetNumber();
    }

    public int GetCountKarts(){
        return kartPlayer.Count;
    }

    public string GetName(){
        return name;
    }

    public void AddKarta(Karta karta){
        kartPlayer.Add(karta);
    }

    public void PrintCard(){
        for(int i = 0;i < kartPlayer.Count;i++){
            kartPlayer[i].PrintTypeColor(i + 1);
        }
        System.Console.WriteLine($"Count kart:{kartPlayer.Count}");
    }
}

public class Karta{
    private string type = "default";
    private string number = "default";

    public Karta(string _type, string _number){
        type = _type;
        if(_number == "11"){
            number = "туз";
        }
        else if(_number == "12"){
            number = "король";
        }
        else if(_number == "13"){
            number = "дама";
        }
        else if(_number == "14"){
            number = "валет";
        }
        else{
            number = _number;
        }
    }

    public string GetNumber(){

        return number;
    }

    public void PrintTypeColor(int i){
        System.Console.WriteLine($"{i})Karta<{type}:{number}>");
    }
}

public class Program{
    public static void Main(){
        System.Console.WriteLine("Hello");
        System.Console.WriteLine("How math player?(2,3,4, работает пока только с двумя игроками(  ");
        int countPlayer = Convert.ToInt32(Console.ReadLine());
        while(countPlayer != 2){
            System.Console.WriteLine("Error");
            System.Console.WriteLine("How math player?(2,3,4)");
            countPlayer = Convert.ToInt32(Console.ReadLine());
        }
        Game game = new Game(countPlayer);
        //game.PrintListPlayers();
        System.Console.WriteLine("Okey!Let`s go\n");
        game.GameGame();
    }
}