using CourierManagementSystem.Entities;
using CourierManagementSystem.Exceptions;  // Add this
using CourierManagementSystem.Services;
//using CourierManagementSystem.Database;  // Assuming CourierServiceDb is in this namespace
using System;
using CourierManagementSystem.Dao;

namespace CourierManagementSystem
{
    public class Payment
    {
        ICourierUserService userService = new CourierUserServiceImpl();
        ICourierAdminService adminService = new CourierAdminServiceImpl();
        CourierServiceDb db = new CourierServiceDb();  // Ensure this is correctly defined in the project

        public Payment()
        {
            try
            {
                // Add courier staff
                Employee staff = new Employee
                {
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

                // Get order status (exception will be thrown if not found)
                string status = userService.GetOrderStatus(trackingNumber);
                Console.WriteLine($"Order Status: {status}");

                // Cancel the order (exception will be thrown if tracking number is invalid)
                bool canceled = userService.CancelOrder(trackingNumber);
                Console.WriteLine(canceled ? "Order canceled successfully." : "Order could not be canceled.");

                // Test invalid tracking number
                string invalidTrackingNumber = "INVALID_TRACKING_NUMBER";
                userService.GetOrderStatus(invalidTrackingNumber);  // Will throw exception
            }
            catch (TrackingNumberNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidEmployeeIdException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Process completed.");
            }
        }
    }
}
