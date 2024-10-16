namespace CourierManagementSystem.Entities
{
    public class Employee
    {
        // Private properties
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Role { get; set; }
        public double Salary { get; set; }

        // Default constructor
        public Employee() { }

        // Parameterized constructor
        public Employee(int employeeID, string employeeName, string email, string contactNumber, string role, double salary)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            Email = email;
            ContactNumber = contactNumber;
            Role = role;
            Salary = salary;
        }

        // ToString() method
        public override string ToString()
        {
            return $"Employee [EmployeeID={EmployeeID}, EmployeeName={EmployeeName}, Email={Email}, ContactNumber={ContactNumber}, Role={Role}, Salary={Salary}]";
        }
    }
}
