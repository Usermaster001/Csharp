using System;

public class Exception_sum : Exception {
    public double Value { 
        get;  
    }
    public Exception_sum ( string message, double money ) : base ( message ) { 
        Value = money;
    }
}

class Count {
    protected string number_count;
    protected int pin_code;
    protected double money;

    public Count ( string _number_count, int _pin_code, double _money ) {
        number_count = _number_count;
        pin_code = _pin_code;
        money = _money;
    }

    public string get_number_count ( ) {
        return number_count;
    }
    
    public int get_pin_code ( ) {
        return pin_code;
    }

    public double get_money ( ) {
        return money;
    }

    public void print_info () {
        System.Console.WriteLine ( $"number_count:{ number_count }" );
        System.Console.WriteLine ( $"Money:{ money }" );
    }

    public virtual void spend_money( double sum ) {
        if ( sum > 0 ){
            System.Console.WriteLine( $"\nspend money:{ sum }\n" );
            if ( money - sum >= 0 ){
                money = money - sum;
                print_info();
            }
            else {
                throw new Exception_sum( "Exception_sum Money:", money - sum );
            }
        }
        else {
            System.Console.WriteLine( "Error, sum < 0" );
        }
    }
};

class Count_default : Count{
    public Count_default ( string _number_count, int _pin_code, double _money ) 
        : base ( _number_count, _pin_code, _money ) { }

    public override void spend_money( double sum ) {
        double commission = 0.15;
        double test = money - sum - ( sum * commission );
        if ( sum + sum * commission > 0 ){
            System.Console.WriteLine( $"\nspend money:{ sum + sum * commission }\n" );
            if ( test >= 0 ){
                money = test;
                print_info();
            }
            else {
                throw new Exception_sum( "Exception_sum Money:", test );
            }
        }
        else {
            System.Console.WriteLine( "Error, sum < 0" );
        }
    }
}

class Count_preferential : Count{
    public Count_preferential ( string _number_count, int _pin_code, double _money ) 
        : base ( _number_count, _pin_code, _money ) { }

    public override void spend_money( double sum ) {
        double commission = 0.3;
        double test = money - sum - ( sum * commission );
        if ( sum + sum * commission > 0 ){
            System.Console.WriteLine( $"\nspend money:{ sum + sum * commission }\n" );
            if ( test >= 0 ){
                money = test;
                print_info();
            }
            else {
                throw new Exception_sum( "Exception_sum Money:", test );
            }
        }
        else {
            System.Console.WriteLine( "\nError, sum < 0" );
        }
    }
}


public class HelloWorld
{    
    public static void Main(string[] args){
        try {
            System.Console.WriteLine( "\nStart\n" );
            Count test = new Count( "2200 0000 0000 0000", 1234, 100 );
            Count_preferential test_default = new Count_preferential( test.get_number_count(), 
                                                                      test.get_pin_code(),
                                                                      test.get_money());
            test_default.print_info ( );
            test_default.spend_money( -90 );
        }
        catch ( Exception_sum ex ) {
            System.Console.WriteLine ( ex.Message );
            System.Console.WriteLine ( ex.Value );
        }
        finally {
            System.Console.WriteLine ( "\nFinish" );
        }
    }
}