namespace CourierManagementSystem.Entities
{
    public class User
    {
        // Private properties
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        // Default constructor
        public User() { }

        // Parameterized constructor
        public User(int userID, string userName, string email, string password, string contactNumber, string address)
        {
            UserID = userID;
            UserName = userName;
            Email = email;
            Password = password;
            ContactNumber = contactNumber;
            Address = address;
        }

        // ToString() method to print the details of User
        public override string ToString()
        {
            return $"User [UserID={UserID}, UserName={UserName}, Email={Email}, ContactNumber={ContactNumber}, Address={Address}]";
        }
    }
}
