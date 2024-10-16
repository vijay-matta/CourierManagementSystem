using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net;

public class Program
{
    private static void Main(string[] args)
    {
        //9. Parcel Tracking: Create a program that allows users to input a parcel tracking number.Store the 
        // tracking number and Status in 2d String Array. Initialize the array with values.Then, simulate the
        // tracking process by displaying messages like "Parcel in transit," "Parcel out for delivery," or "Parcel 
        // delivered" based on the tracking number's status.

        Console.WriteLine("Enter the Tracking Number of the parcel:");
        string tnumber = Console.ReadLine();

        string[,] parcel = new string[,] { { "T12345", "In Transit" },
                                           { "T23456", "Out for Delivery" },
                                           { "T34567", "Delivered" },
                                           { "T45678", "In Transit" },
                                           { "T56789", "Delivered" } 
                                          };
        bool hastrack = false;
        for (int i = 0; i < parcel.GetLength(0); i++)
        {
            if (tnumber == parcel[i, 0])
            {
                hastrack = true;
               string status = parcel[i, 1];
                switch (status) {
                    
                    case "In Transit":
                        {
                            Console.WriteLine("Parcel in transit");
                            break;
                        }

                    case "Out for Delivery":
                        {
                            Console.WriteLine("Parcel is Out for Delivery");
                            break;
                        }

                    case "Delivered":
                        {
                            Console.WriteLine("Parcel Delivered");
                            break;
                        }

                }
            }


        }
        if (hastrack == false) {
            Console.WriteLine("No parcel with that tracking id found!!");
        }
        Console.ReadKey();



        Console.WriteLine("---------------------------------------------------");
        // Q 10):
        Console.WriteLine("Enter the data:");
        string data = Console.ReadLine();

        Console.WriteLine("Enter the detail:");
        string detail = Console.ReadLine();

        bool isvalid = validatedata(data, detail);
        if (isvalid == false) {
        Console.WriteLine("Invalid data");
        }
        else
        {
            Console.WriteLine("The data is valid");
        }
        Console.ReadKey();


        Console.WriteLine("---------------------------------------------------");
        
        
        // Q 11):
        Console.WriteLine("---Validating Address---");

        Console.WriteLine("Enter the Street Name:");
        string street = Console.ReadLine();
        Console.WriteLine("Enter the City Name:");
        string city = Console.ReadLine();
        Console.WriteLine("Enter the State Name:");
        string state = Console.ReadLine();
        Console.WriteLine("Enter the ZipCode Name:");
        string zipcode = Console.ReadLine();

        bool isvalid1 = validatedata(street, city,state,zipcode);
        if (isvalid1 == false)
        {
            Console.WriteLine("Invalid data");
        }
        else
        {
            Console.WriteLine("The data is valid");
        }
        Console.ReadKey();
        Console.WriteLine("---------------------------------------------------");

        //12. Order Confirmation Email: Create a program that generates an order confirmation email. The email 
        //should include details such as the customer's name, order number, delivery address, and expected 
        //delivery date. 

        Console.WriteLine("Enter customer's name:");
        string customerName = Console.ReadLine();

        Console.WriteLine("Enter order number:");
        string orderNumber = Console.ReadLine();

        Console.WriteLine("Enter delivery address:");
        string deliveryAddress = Console.ReadLine();

        Console.WriteLine("Enter expected delivery date (e.g., 2024-10-15):");
        string deliveryDate = Console.ReadLine();

        Console.WriteLine("\n--- Order Confirmation Email ---\n");

        Console.WriteLine( $"Dear {customerName},\n\n" +
               $"Thank you for your order!\n" +
               $"Order Number: {orderNumber}\n" +
               $"Delivery Address: {deliveryAddress}\n" +
               $"Expected Delivery Date: {deliveryDate}\n\n" +
               "We hope you enjoy your purchase.\n" +
               "Sincerely,\n" +
               "The Company"
               );

        Console.ReadKey();
        Console.WriteLine("---------------------------------------------------");

        //Q 13)
        Console.WriteLine("Enter source address:");
        string source = Console.ReadLine();

        Console.WriteLine("Enter destination address:");
        string destination = Console.ReadLine();

        
        Console.WriteLine("Enter the weight of the parcel (in kg):");
        double weight = Convert.ToDouble(Console.ReadLine());

        
        Console.WriteLine("Enter the distance between source and destination (in km):");
        double distance = Convert.ToDouble(Console.ReadLine());

       
        double shippingCost = CalculateShippingCost(distance, weight);

        
        Console.WriteLine($"\nThe shipping cost from {source} to {destination} for a {weight} kg parcel is: {shippingCost:C}");

        Console.ReadKey();
        Console.WriteLine("---------------------------------------------------");

        //Q 12)
        Console.WriteLine("Enter password length:");
        int length = Convert.ToInt32(Console.ReadLine());

       
        string password = GeneratePassword(length);
        Console.WriteLine("Generated Password: " + password);

        Console.ReadKey();
        Console.WriteLine("---------------------------------------------------");

    }


    //10. Customer Data Validation: Write a function which takes 2 parameters, data-denotes the data and 
    //detail-denotes if it is name addtress or phone number.Validate customer information based on
    //following critirea.Ensure that names contain only letters and are properly capitalized, addresses do not
    // contain special characters, and phone numbers follow a specific format(e.g., ###-###-####).

    public static bool validatedata(string data, string detail)
    {
        if (detail == "name")
        {
            return ValidateName(data);
        }
        else if (detail == "address")
        {
            return ValidateAddress(data);
        }
        else if (detail == "phone number")
        {
            return ValidatePhoneNumber(data);
        }
        else
        {
            Console.WriteLine("Invalid detail type.");
            return false;
        }
    }

    public static bool ValidateName(string name) 
    {
        foreach (char c in name) 
        {
            if (!char.IsLetter(c))
            {
                Console.WriteLine($"{c} is invalid. The name should contain only letters");
                return false;
            }

        }
        if (!char.IsUpper(name[0]))
        {
            Console.WriteLine("The first letter should be Capital");
            return false;
        }

        return true;
    
    }
    public static bool ValidateAddress(string address) 
    {
        foreach (char c in address)
        {
            if (!char.IsLetterOrDigit(c) && c != ' ')
            {
                Console.WriteLine("Invalid address. No special characters allowed.");
                return false;
            }
        }
        return true;

    }

    public static bool ValidatePhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length == 12 && phoneNumber[3] == '-' && phoneNumber[7] == '-')
        {
            return true;
        }
        else
        {
            Console.WriteLine("Invalid phone number format. Use ###-###-####.");
            return false;
        }

    }
    //11. Address Formatting: Develop a function that takes an address as input (street, city, state, zip code) 
    //and formats it correctly, including capitalizing the first letter of each word and properly formatting the
    //zip code.
    public static bool validatedata(string street, string city, string state, string zipcode)
    {
        if (street != null)
        {
            return validatestreet(street);
        }
        else if (city != null)
        {
            return validatecity(city);
        }
        else if (state != null)
        {
            return validatestate(state);
        }
        else if (zipcode != null)
        {
            return validatezipcode(zipcode);
        }
        else
        {
            Console.WriteLine("Invalid detail type.");
            return false;
        }
    }
    public static bool validatestreet(string street)
    {
        foreach (char c in street)
        {
            if (!char.IsLetterOrDigit(c) && c != ' ')
            {
                Console.WriteLine("Invalid street name. Please enter only letter and digits!!");
                return false;
            }
        }
        if (!char.IsUpper(street[0]))
        {
            Console.WriteLine("The first letter should be Capital");
            return false;
        }
        return true;
    }

    public static bool validatecity(string city)
    {
        foreach (char c in city)
        {
            if (!char.IsLetter(c) && c != ' ')
            {
                Console.WriteLine("Invalid City name. Please enter only letter !!");
                return false;
            }
        }
        if (!char.IsUpper(city[0]))
        {
            Console.WriteLine("The first letter should be Capital");
            return false;
        }
        return true;
    }

    public static bool validatestate(string state)
    {
        foreach (char c in state)
        {
            if (!char.IsLetter(c) && c != ' ')
            {
                Console.WriteLine("Invalid State name. Please enter only letter and digits!!");
                return false;
            }
        }
        if (!char.IsUpper(state[0]))
        {
            Console.WriteLine("The first letter should be Capital");
            return false;
        }
        return true;
    }

    public static bool validatezipcode(string zipcode)
    {
        foreach (char c in zipcode)
        {
            if (!char.IsDigit(c) && c != ' ')
            {
                Console.WriteLine("Invalid zipcode. Please enter only letter and digits!!");
                return false;
            }
            else if (char.IsDigit(c) && zipcode.Length==7 && zipcode[4] == '-')
            {
                return true;
            }
        }
        return true;
    }

    //13. Calculate Shipping Costs: Develop a function that calculates the shipping cost based on the distance 
    //between two locations and the weight of the parcel.You can use string inputs for the source and
    //destination addresses.

    public static double CalculateShippingCost(double distance, double weight)
    {
        
        double baseCost = 5.00;
        double distanceCost = distance * 1.00; 
        double weightCost = weight * 2.00;     

        return baseCost + distanceCost + weightCost;
    }

    //14. Password Generator: Create a function that generates secure passwords for courier system 
    //accounts.Ensure the passwords contain a mix of uppercase letters, lowercase letters, numbers, and
    //special characters.
    public static string GeneratePassword(int length)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
        Random random = new Random();
        char[] password = new char[length];

        
        for (int i = 0; i < length; i++)
        {
            password[i] = chars[random.Next(chars.Length)];
        }

        return new string(password);
    }
}