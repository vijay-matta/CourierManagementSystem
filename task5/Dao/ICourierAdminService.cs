using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Services
{
    public interface ICourierAdminService
    {
        // Method to add a new courier staff member
        int AddCourierStaff(Employee obj);
    }
}
