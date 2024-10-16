
//--Task 1: Control Flow Statements--


//1. Write a program that checks whether a given order is delivered or not based on its status (e.g.,
//"Processing," "Delivered," "Cancelled"). Use if-else statements for this. 

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the status of the order from the below: \r\n\"Processing\" \"Delivered\" \"Cancelled\" ");
        string status= Console.ReadLine();

        if( status == "Delivered")
        {
            Console.WriteLine("Order is delivered");
        }

        else if (status == "Processing")
        {
            Console.WriteLine("Order is Processing");
        }

        else if (status == "Cancelled")
        {
            Console.WriteLine("Order is Cancelled");
        }

        else
        {
            Console.WriteLine("Entered status is not in list");
        }

        Console.WriteLine("------------------------------------------------");
        
        
        //2. Implement a switch-case statement to categorize parcels based on their weight into "Light," 
        //"Medium," or "Heavy."
        Console.WriteLine("Enter the weight of the parcel in KGs:");
        double weight = Convert.ToDouble(Console.ReadLine());

        switch (weight)
        {
            case double n when (n <= 1.0):
                Console.WriteLine("Parcel is lessthan or equal to 1 KG so categorized into Light!");
                break;
            case double n when (n > 1.0 && n < 5.0):
                Console.WriteLine("Parcel is lessthan 5 KG and greaterthan 1 KG  so categorized into Medium!");
                break;
            case double n when weight > 5:
                Console.WriteLine("Parcel is greaterthan 5 KG so categorized into Heavy!");
                break;
        }
        Console.WriteLine("------------------------------------------------");

        //3.Implement User Authentication 1.Create a login system for employees and customers using Java
        //control flow statements.
       
        Console.WriteLine("Enter your role Employee (E) or Customer (C):");
        char role = Convert.ToChar(Console.ReadLine());

        var employeeCredentials = new (string username, string password)[]
        {
            ("vijay","pass")
        };

        var customerCredentials = new (string username, string password)[]
        {
            ("jai","pass")
        };

        Console.WriteLine("Enter your usename:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();


        if (role == 'E' || role == 'e')
        {
            if (username == employeeCredentials[0].username && password == employeeCredentials[0].password)
            {
                Console.WriteLine("\nWelcome  " + username + "\nLogged in Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Credentials!!");
            }
        }
        else if (role == 'C' || role == 'c')
        {
            if (username == customerCredentials[0].username && password == customerCredentials[0].password)
            {
                Console.WriteLine("\nWelcome  " + username + "\nLogged in Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Credentials!!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Entry");
        }

        Console.WriteLine("------------------------------------------------");
        Console.ReadKey();


    }
}