namespace CourierManagementSystem.Entities
{
    public class Location
    {
        // Private properties
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }

        // Default constructor
        public Location() { }

        // Parameterized constructor
        public Location(int locationID, string locationName, string address)
        {
            LocationID = locationID;
            LocationName = locationName;
            Address = address;
        }

        // ToString() method
        public override string ToString()
        {
            return $"Location [LocationID={LocationID}, LocationName={LocationName}, Address={Address}]";
        }
    }
}

