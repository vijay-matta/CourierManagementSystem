
using System;
using System.Data.SqlClient;

using System.IO;

namespace CourierManagementSystem.ConnectionUtil
{
    public class DBConnection
    {
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = "Data Source = VJ-S\\SQLEXPRESS; Initial Catalog = CourierManagementSystem; Integrated Security = True";
                
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }
    }
}
