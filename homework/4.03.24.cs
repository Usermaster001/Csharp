using System;
using System.Text.Json;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;


public class Person
{
    public string Name { get; set; } = "Undefined";
    public int Age { get; set; } = 1;
    public string Country { get; set; } = "default";
 
    public Person() { }
    public Person(string name, int age, string coutnry)
    {
        Name = name;
        Age = age;
        Country = coutnry;
    }
}

public class Program{
    public static void Xml(){
        Person person = new Person("Tom", 17, "USA");
 
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
    
        using (FileStream fs = new FileStream("xml.txt", FileMode.OpenOrCreate)){
            xmlSerializer.Serialize(fs, person);
        
            Console.WriteLine("Object has been serialized");
        }
    }

    public static async void Json(){
        using (FileStream fs = new FileStream("json.txt", FileMode.OpenOrCreate)){
            Person person = new Person("Tom", 17, "USA");
            await JsonSerializer.SerializeAsync<Person>(fs, person);
            Console.WriteLine("Data has been saved to file");
        }
    }

    public static void Soap(){
        SoapFormatter formatter = new SoapFormatter();
        
        using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate)){
            Person person = new Person("Tom", 17, "USA");
            formatter.Serialize(fs, person);
        }
    }

    public static void Main(string[] args){
        //Xml();
        //Json();
        Soap();
    }
}