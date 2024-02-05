using System;
using System.Collections;

/*5)public class max_element
{
    public T find_max_el<T>(T[] array) where T : IComparable{
        T max = array[0];
        foreach(T item in array){
            if(item.CompareTo(max) < 0){
                max = item;
            }
        }
        return max;
    }
}*/

public class HelloWorld
{
    /*1)delegate void delegate_test(int n);

    public static void func1(int n){
        System.Console.WriteLine(n);
    }

    public static void func2(int n){
        System.Console.WriteLine(n * n);
    }

    public static void func3(int n){
        int res = 1;
        for(int i = 2;i <= n;i++){
            res *= i;
        }
        System.Console.WriteLine(res);
    }*/

    /*3)delegate int Operation(int x, int y);

    delegate int Square(int x);*/

    /*4)delegate void delegate4 <T>(T t); 

    public static void print <T> (T t){
        System.Console.WriteLine(t);
    }

    public static T print_test <T>(T t){
        return t;
    }*/

    public static void Main(string[] args)
    {
        /*1)delegate_test d;
        d = func1;
        d += func2;
        d += func3;
        d(5);*/

        /*2)(лямбда)delegate_test d2 = (int n) => {System.Console.WriteLine(n);};
        d2(1);*/
        
        /*3)Operation operation = (x, y) => x + y;

        System.Console.WriteLine(operation(1,2));*/

        /*4)delegate4 <string> del = print;
        del("wdq");*/
        
        /*5)int[] tes = {1,2,3};
        max_element test = new max_element();
        System.Console.WriteLine(test.find_max_el(tes));*/
        
        {
            System.Console.WriteLine("finish");
        }
    }
}
