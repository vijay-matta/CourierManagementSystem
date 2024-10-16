using System;
using System.Collections.Generic;

namespace CourierManagementSystem.Entities
{
    public class CourierCompany
    {
        public string CompanyName { get; set; }
        public List<Courier> Couriers { get; set; } // Changed from Array to List

        // Constructor to initialize the List
        public CourierCompany(string companyName)
        {
            CompanyName = companyName;
            Couriers = new List<Courier>(); // Initialize the List to store couriers
        }

        // Method to add a new Courier to the list
        public void AddCourier(Courier courier)
        {
            Couriers.Add(courier);
        }

        // Method to remove a Courier from the list
        public void RemoveCourier(Courier courier)
        {
            Couriers.Remove(courier);
        }
    }
}
