using System;

//5. Write a c# program that uses a for loop to display all the orders for a specific customer. 

public class Program
{
    private static void Main(string[] args)

    {

        Console.WriteLine("Enter number of orders:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] orderid = new int [n];
        string [] customername = new string [n];
        string[] productname = new string [n];
        double[] amount = new double [n];


        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the OrderId:");
            orderid[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the CustomerName:");
            customername[i] = (Console.ReadLine());

            Console.WriteLine("Enter the Product Name:");
            productname[i] = (Console.ReadLine());

            Console.WriteLine("Enter the Amount:");
            amount[i] =double.Parse(Console.ReadLine());


        }
        Console.WriteLine("Now Enter the customer name to know the detail:");
        string cname = Console.ReadLine();
        bool hasorder = false;

        for(int i = 0;i < n; i++)
        {
            if (cname.Equals(customername[i]))
            {
                Console.WriteLine("Customer Name:"+cname+ "\nOrder Id :" + orderid[i] + "\n Product Name:" + productname [i]+ "\nAmount:"+ amount[i]);
                hasorder = true;
                break;
            }
            
        }
        if(hasorder == false)
        {
            Console.WriteLine("No Customer Found!!");
        }
        Console.ReadKey();
        
    }

}