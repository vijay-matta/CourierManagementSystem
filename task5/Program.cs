using CourierManagementSystem.Entities;
using CourierManagementSystem.Services;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using CourierManagementSystem.Dao;
using CourierManagementSystem.ConnectionUtil;
//using CourierManagementSystem.Entities;


namespace CourierManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of services
            ICourierUserService userService = new CourierUserServiceImpl();
            ICourierAdminService adminService = new CourierAdminServiceImpl();

            // Add a courier staff
            Employee staff = new Employee
            {
               // EmployeeID = 1,
                EmployeeName = "John Doe",                                                        
                Email = "john@example.com",
                ContactNumber = "1234567890",
                Role = "Courier Staff",
                
                Salary = 25000
            };
            int staffId = adminService.AddCourierStaff(staff);
            Console.WriteLine($"New Courier Staff added with ID: {staffId}");

            // Place an order
            Courier newCourier = new Courier(1, "Alice", "123 Main St", "Bob", "456 Elm St", 5.50m, "In Transit","", DateTime.Now.AddDays(5), staffId);
            string trackingNumber = userService.PlaceOrder(newCourier);
            Console.WriteLine($"Courier placed with Tracking Number: {trackingNumber}");

            // Get order status
            string status = userService.GetOrderStatus(trackingNumber);
            Console.WriteLine($"Order Status: {status}");

            // Cancel the order
            bool canceled = userService.CancelOrder(trackingNumber);
            Console.WriteLine(canceled ? "Order canceled successfully." : "Order could not be canceled.");

            //Console.ReadKey();

            Console.WriteLine("----------------DataBase Interaction--------------------------");

            //ICourierUserService userService = new CourierUserServiceImpl();
            CourierServiceDb dbService = new CourierServiceDb();

            Console.WriteLine("Choose an option: 1. Insert Order  2. Update Status  3. Retrieve Order");
            string choice = Console.ReadLine();
            // Add declarations before using them
            string SenderName, SenderAddress, ReceiverName, ReceiverAddress, Status, TrackingNumber;
            decimal Weight;
            int AssignedStaffId,CourierId;
            DateTime DeliveryDate;


            switch (choice)
            {
                case "1":  // Insert new courier order
                    Console.WriteLine("----Insert new courier order------");

                    // Capture user input
                    Console.WriteLine("Enter the CourierId:");
                    CourierId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Sender Name:");
                    SenderName = Console.ReadLine();
                    Console.WriteLine("Enter the Sender Address:");
                    SenderAddress = Console.ReadLine();
                    Console.WriteLine("Enter the Receiver Name:");
                    ReceiverName = Console.ReadLine();
                    Console.WriteLine("Enter the Receiver Address:");
                    ReceiverAddress = Console.ReadLine();
                    Console.WriteLine("Enter the weight of the Courier:");
                    Weight = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter the Status:");
                    Status = Console.ReadLine();
                    Console.WriteLine("Enter the Tracking Number:");
                    TrackingNumber = Console.ReadLine();
                    Console.WriteLine("Enter the Delivery Date:");
                    DeliveryDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter the Employee Id:");
                    AssignedStaffId = Convert.ToInt32(Console.ReadLine());

                    // Create new courier order
                    Courier newCourierOrder = new Courier(0,SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate, AssignedStaffId);

                    // Call a method to insert into database (use `CourierServiceDb` if applicable)
                    dbService.InsertCourierOrder(newCourierOrder);  // Assuming this method exists in CourierServiceDb
                    break;


                case "2":  // Update courier status
                    Console.WriteLine("----Update courier status------");
                    Console.WriteLine("Enter Tracking Number:");
                    trackingNumber = Console.ReadLine();
                    Console.WriteLine("Enter new Status:");
                    string newStatus = Console.ReadLine();
                    dbService.UpdateCourierStatus(trackingNumber, newStatus);
                    Console.WriteLine("Status updated successfully.");
                    break;

                case "3":  // Retrieve courier by tracking number
                    Console.WriteLine("----Retrieve courier by tracking number------");
                    Console.WriteLine("Enter Tracking Number:");
                    string trackNumber = Console.ReadLine();
                    Courier courier = dbService.GetCourierByTrackingNumber(trackNumber);
                    if (courier != null)
                    {
                        Console.WriteLine($"Courier Found: {courier.SenderName} -> {courier.ReceiverName}, Status: {courier.Status}");
                    }
                    else
                    {
                        Console.WriteLine("Courier not found.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.ReadKey();
        }
    }
}
