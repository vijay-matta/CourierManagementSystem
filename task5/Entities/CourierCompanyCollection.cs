using System;
using System.Collections.Generic;
using CourierManagementSystem.Entities; // Assuming this namespace contains CourierCompany

namespace CourierManagementSystem.Entities
{
    public class CourierCompanyCollection
    {
        // Internal list to hold the CourierCompany objects
        private List<CourierCompany> companies;

        // Constructor to initialize the companies list
        public CourierCompanyCollection()
        {
            companies = new List<CourierCompany>();  // Initialize the list
        }

        // Method to add a company to the collection
        public void AddCompany(CourierCompany company)
        {
            if (company != null)
            {
                companies.Add(company);  // Add the company if it's not null
            }
        }

        // Method to find a company by its name
        public CourierCompany FindCompanyByName(string companyName)
        {
            return companies.Find(c => c.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
        }

        // Method to get all companies
        public List<CourierCompany> GetCompanies()
        {
            return companies;  // Return the list of companies
        }

        // Optional: Remove a company by its name
        public void RemoveCompany(string companyName)
        {
            CourierCompany companyToRemove = FindCompanyByName(companyName);
            if (companyToRemove != null)
            {
                companies.Remove(companyToRemove);  // Remove if company exists
            }
        }
    }
}
