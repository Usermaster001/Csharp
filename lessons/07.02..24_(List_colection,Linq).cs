using System;
using System.Collections.Generic;
using System.Linq;

public class Car{
    public Car(string _name, string _country, int _year){
        Name = _name;
        Country = _country;
        Year = _year;
    }

    public string Name{get;set;}
    public string Country{get;set;}
    public int Year{get;set;}
    public int Price{get;set;}
}

public class Program
{
    public static void Main(string[] args)
    {
        /*List<string> cars = new List<string>() {"bmw","lada","mersedes"};
        List<Car> result = cars.Select(p => new Car(p)).ToList();

        List<Car> resultWithoutLada = result
            .Where(car => car.Name != "lada").ToList();*/

        /*List<Car> cars = new List<Car>();
        cars.Add(new Car("Lada"));

        List<string> note = cars.Select(p => p.Name).ToList();

        foreach(string p in note){
            System.Console.WriteLine("dqwd");
            System.Console.WriteLine(p);
        }*/
        
        /*List<Car> cars = new List<Car>();
        cars.Add(new Car("Lada",));

        List<Car> note = new List<Car>();

        note = cars.Where(p)*/

        /*List<Car> cars = new List<Car>();
        cars.Add(new Car("bmw", "germany", 1990));
        cars.Add(new Car("mersedes", "germany", 1991));

        int MaxYear = cars.Max(p => p.Year);
        Car? resultMax = cars.Where(p => p.Year == MaxYear).FirstOrDefault();
        System.Console.WriteLine(resultMax?.Name);

        int MinYear = cars.Min(p => p.Year);
        Car? resultMin = cars.Where(p => p.Year == MinYear).FirstOrDefault();
        System.Console.WriteLine(resultMin?.Name);

        int SumYear = cars.Sum(p => p.Year);
        System.Console.WriteLine(SumYear);

        double AverageYear = cars.Average(p => p.Year);
        System.Console.WriteLine(AverageYear);*/

        /*List<Car> cars = new List<Car>();

        Car testCon = new Car("pego","france",1999);

        //cars.Add(testCon);
        cars.Add(new Car("bmw", "germany", 1990));
        cars.Add(new Car("mersedes", "germany", 1991));

        if(cars.Select(p => p.Name).Contains("pego")){
            System.Console.WriteLine("done;");
        }
        else{
            System.Console.WriteLine("Error!")
        }*/
    }
}