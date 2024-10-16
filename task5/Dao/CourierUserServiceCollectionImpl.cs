using System;
using System.Collections.Generic;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Exceptions;

namespace CourierManagementSystem.Services
{
    public class CourierUserServiceCollectionImpl : ICourierUserService
    {
        // Variable to hold the collection of CourierCompanies
        private CourierCompanyCollection companyObj;

        public CourierUserServiceCollectionImpl()
        {
            companyObj = new CourierCompanyCollection();  // Initialize collection
        }

        // Method to place a new courier order
        public string PlaceOrder(Courier courierObj)
        {
            string trackingNumber = "TN" + (1000 + new Random().Next(9000));  // Generate a random tracking number
            courierObj.TrackingNumber = trackingNumber; // Assign tracking number

            // Find the company to add the courier to (assuming a sample company)
            CourierCompany company = companyObj.FindCompanyByName("Sample Company");
            if (company != null)
            {
                company.AddCourier(courierObj); // Add courier to the existing company
            }
            else
            {
                // If the company doesn't exist, create a new one
                company = new CourierCompany("Sample Company");
                company.AddCourier(courierObj);
                companyObj.AddCompany(company); // Add the new company to the collection
            }

            return trackingNumber; // Return the generated tracking number
        }

        // Method to get the status of a courier order
        public string GetOrderStatus(string trackingNumber)
        {
            foreach (var company in companyObj.GetCompanies())
            {
                foreach (var courier in company.Couriers)
                {
                    if (courier.TrackingNumber == trackingNumber)
                    {
                        return courier.Status; // Return the status of the found courier
                    }
                }
            }

            throw new TrackingNumberNotFoundException("Tracking number not found."); // Exception if not found
        }

        // Method to cancel a courier order
        public bool CancelOrder(string trackingNumber)
        {
            foreach (var company in companyObj.GetCompanies())
            {
                foreach (var courier in company.Couriers)
                {
                    if (courier.TrackingNumber == trackingNumber)
                    {
                        company.RemoveCourier(courier);  // Remove the courier from the company's list
                        return true;
                    }
                }
            }

            return false; // Return false if the courier is not found
        }

        // Method to get a list of orders assigned to a specific courier staff member
        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            List<Courier> assignedOrders = new List<Courier>();  // List to store assigned orders

            foreach (var company in companyObj.GetCompanies()) // Iterate over companies
            {
                foreach (var courier in company.Couriers) // Iterate over couriers
                {
                    if (courier.EmployeeId == courierStaffId) // Check if the courier is assigned to the staff
                    {
                        assignedOrders.Add(courier); // Add to the list
                    }
                }
            }

            return assignedOrders; // Return the list of assigned orders
        }
    }
}
