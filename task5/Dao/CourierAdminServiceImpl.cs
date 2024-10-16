using CourierManagementSystem.Entities;
using CourierManagementSystem.Exceptions;  // Add this
using System;
using System.Collections.Generic;

namespace CourierManagementSystem.Services
{
    public class CourierAdminServiceImpl : ICourierAdminService
    {
        private static List<Employee> employees = new List<Employee>();
        private static int employeeIdSeed = 1;

        public int AddCourierStaff(Employee obj)
        {
            obj.EmployeeID = employeeIdSeed++;
            employees.Add(obj);
            return obj.EmployeeID;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = employees.Find(e => e.EmployeeID == employeeId);
            if (employee == null)
            {
                throw new InvalidEmployeeIdException();  // Throw custom exception
            }
            return employee;
        }
    }
}
