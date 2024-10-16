using CourierManagementSystem.Entities;
using CourierManagementSystem.Exceptions;  // Add this
using System;
using System.Collections.Generic;

namespace CourierManagementSystem.Services
{
    public class CourierUserServiceImpl : ICourierUserService
    {
        private static List<Courier> courierOrders = new List<Courier>();
        private static int trackingNumberSeed = 1000;

        public string PlaceOrder(Courier courierObj)
        {
            string trackingNumber = $"TN{trackingNumberSeed++}";
            courierObj.TrackingNumber = trackingNumber;
            courierOrders.Add(courierObj);
            return trackingNumber;
        }

        public string GetOrderStatus(string trackingNumber)
        {
            Courier order = courierOrders.Find(c => c.TrackingNumber == trackingNumber);
            if (order == null)
            {
                throw new TrackingNumberNotFoundException();  // Throw custom exception
            }
            return order.Status;
        }

        public bool CancelOrder(string trackingNumber)
        {
            Courier order = courierOrders.Find(c => c.TrackingNumber == trackingNumber);
            if (order == null)
            {
                throw new TrackingNumberNotFoundException("Order with this tracking number doesn't exist.");
            }
            courierOrders.Remove(order);
            return true;
        }

        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            return courierOrders.FindAll(c => c.EmployeeId == courierStaffId);
        }
    }
}
