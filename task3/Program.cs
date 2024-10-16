using System.Security.Cryptography.X509Certificates;
using System;
using static Program;


public class Program

{
    public class courier
    {
        public string Name { get; set; }
        public int Location { get; set; }

        public courier(string name, int location)
        {
            Name = name;
            Location = location;
        }

        
    }


    public static void Main(string[] args)
    {
        //7. Create an array to store the tracking history of a parcel, where each entry represents a location update.

        Console.WriteLine("Enter the Number of Location Updates you want to insert:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] orderid = new int[n];
        string [] date = new string[n];
        string[] time = new string[n];
        string[] location = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the OrderId:");
            orderid[i] = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date:");
            date[i] = Console.ReadLine();
            Console.WriteLine("Enter the Time:");
            time[i] = Console.ReadLine();
            Console.WriteLine("Enter the location Update:");
            location[i] = Console.ReadLine();
        }
        Console.WriteLine("--------------------------------------------------------");
        
        Console.WriteLine("Enter the Orderid of the Parcel:");
        int pid = Convert.ToInt32(Console.ReadLine());
        bool haspid = false;
        Console.WriteLine("Tracking Histroy of the Parcel");

        for (int i = 0; i < n; i++) 
        {
            if (orderid[i] == pid) { 
            Console.WriteLine("\nOrderid:" + pid + "\nDate" + i + ":" + date[i] + "\nTime" + i + ":" + "\nLocation" + i + ":" + location[i]);
                haspid = true;
            }
        
        }
        if (haspid = false)
        {
            Console.WriteLine("No Orders Found!!");
        }
        Console.ReadKey();
        Console.WriteLine("--------------------------------------------------------");

        //8. Implement a method to find the nearest available courier for a new order using an array of couriers. 





        static courier nearestlocation(courier[] courier, int newlocation)
        {
            courier nearestcourier = null;
            int smallestDistance = int.MaxValue;  

            

            // Ensure couriers array is not empty
            if (courier.Length == 0)
            {
                Console.WriteLine("No couriers available.");
                return null;  
            }

            for (int i = 0; i < courier.Length; i++)
            {
                int distance = Math.Abs(courier[i].Location - newlocation); 
                Console.WriteLine($"Courier: {courier[i].Name}, Location: {courier[i].Location}, Distance: {distance}");

                // Update if we find a smaller distance
                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    nearestcourier = courier[i];  
                }
            }
            return nearestcourier;



        }






        courier[] courier =
        {
            new courier("Courier1", 10),
            new courier("Courier2", 20),
            new courier("Courier3", 30),
            new courier("Courier4", 40),
        };

        Console.WriteLine("Enter the Location of new Courier:");
        int newlocation = int.Parse(Console.ReadLine());

        courier nearestcourier = nearestlocation(courier, newlocation);
        Console.WriteLine($"\nThe nearest courier is {nearestcourier.Name}, located at {nearestcourier.Location}.");
                
        Console.ReadKey();
    }
    

    

}
