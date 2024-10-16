namespace CourierManagementSystem.Entities
{
    public class Courier
    {
        


        public int CourierId { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int EmployeeId { get; set; }

        // Default constructor
        public Courier() { }

        // Parameterized constructor
        public Courier(int courierID, string senderName, string senderAddress, string receiverName,
                       string receiverAddress, decimal weight, string status, string TrackingNumber,
                       DateTime deliveryDate, int assignedStaffId)
        {
            this.CourierId = CourierId;
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            Weight = weight;
            Status = status;
            this.TrackingNumber = TrackingNumber;
            DeliveryDate = deliveryDate;
            EmployeeId = assignedStaffId;
        }
    }
}
