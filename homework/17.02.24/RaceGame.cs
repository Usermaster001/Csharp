using System;


public class Game{
    public delegate void GameDelegate(string message);
    public event GameDelegate? Notify; 

    public void Race(){
        Notify?.Invoke("Гонка начинается");
        SportCar sport = new SportCar("insaf", "green", 100000, 100);
        Notify.Invoke()

        
        Notify?.Invoke("Гонка закончилвсь");
    }


}


public abstract class Car{
    private string name;
    private string color;
    private int price;
    private int speed;

    public Car(string _name, string _color, int _price, int _speed){
        name = _name;
        color = _color;
        price = _price;
        speed = _speed;
    }

    
    public virtual string Start(){
        return $"Start {name}";
    }

    public virtual string Finish(){
        return $"Finish {name}";
    }

}


public class SportCar : Car
{
    public SportCar(string _name, string _color, int _price, int _speed) : base(_name, _color, _price, _speed)
    {
    }
    
}


public class Bus : Car
{
    public Bus(string _name, string _color, int _price, int _speed) : base(_name, _color, _price, _speed)
    {
    }
}

public class OrdinaryCar : Car
{
    public OrdinaryCar(string _name, string _color, int _price, int _speed) : base(_name, _color, _price, _speed)
    {
    }
}

public class Program{
    public static void DisplayMessage(string message) => Console.WriteLine(message);

    public static void Main(string[] args){
        Game test = new Game();
        test.Notify += DisplayMessage;
        test.Race();
    }
}