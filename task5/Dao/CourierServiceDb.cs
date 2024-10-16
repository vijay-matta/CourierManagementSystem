
using System.Data.SqlClient;
using System;
using CourierManagementSystem.ConnectionUtil;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Dao; // Add this to access Courier class


namespace CourierManagementSystem.Dao
{
    public class CourierServiceDb
    {
        private SqlConnection connection;

        // Constructor to initialize the connection
        public CourierServiceDb()
        {
            connection = DBConnection.GetConnection();
        }

        // Insert a new courier order
        public void InsertCourierOrder(Courier courier)
        {
            Console.WriteLine("Tracking Number: " + courier.TrackingNumber);

            string query = "INSERT INTO Courier (CourierId,SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate, EmployeeId) VALUES (@CourierId,@SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, @Weight, @Status,@TrackingNumber,  @DeliveryDate, @AssignedStaffId)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CourierId", courier.CourierId);
            cmd.Parameters.AddWithValue("@SenderName", courier.SenderName);
            cmd.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
            cmd.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
            cmd.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
            cmd.Parameters.AddWithValue("@Weight", courier.Weight);
            cmd.Parameters.AddWithValue("@Status", courier.Status);
            cmd.Parameters.AddWithValue("@TrackingNumber", courier.TrackingNumber);
            cmd.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);
            cmd.Parameters.AddWithValue("@AssignedStaffId", courier.EmployeeId);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Inserted Sucessfully");
        }

        // Update courier status
        public void UpdateCourierStatus(string trackingNumber, string newStatus)
        {
            string query = "UPDATE Courier SET Status = @Status WHERE TrackingNumber = @TrackingNumber";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Status", newStatus);
            cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // Retrieve courier by tracking number
        public Courier GetCourierByTrackingNumber(string trackingNumber)
        {
            string query = "SELECT * FROM Courier WHERE TrackingNumber = @TrackingNumber";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Courier courier = null;

            if (reader.Read())
            {
                courier = new Courier
                {
                    CourierId = (int)reader["CourierId"],
                    SenderName = reader["SenderName"].ToString(),
                    SenderAddress = reader["SenderAddress"].ToString(),
                    ReceiverName = reader["ReceiverName"].ToString(),
                    ReceiverAddress = reader["ReceiverAddress"].ToString(),
                    Weight = (decimal)reader["Weight"],
                    Status = reader["Status"].ToString(),
                    TrackingNumber = reader["TrackingNumber"].ToString(),
                    DeliveryDate = (DateTime)reader["DeliveryDate"],
                    //EmployeeId = (int)reader["AssignedStaffId"]
                };
            }

            reader.Close();
            connection.Close();
            return courier;
        }
    }
}
