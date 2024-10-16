using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Entities
{
    public interface ICourierUserService
    {
        // Method to place a new courier order
        string PlaceOrder(Courier courierObj);

        // Method to get the status of a courier order
        string GetOrderStatus(string trackingNumber);

        // Method to cancel a courier order
        bool CancelOrder(string trackingNumber);

        // Method to get a list of orders assigned to a specific courier staff member
        List<Courier> GetAssignedOrder(int courierStaffId);
    }
}
