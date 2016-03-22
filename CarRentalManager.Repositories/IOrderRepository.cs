using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.Entities;

namespace CarRentalManager.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetIncome(string startDate, string endDate);
        List<Order> CreateOrder(string startDate, string endDate, 
                                string firstName, string lastName, 
                                string licenseNum, int carId, int userId);
        List<Order> CloseOrder(int orderId, int userId);
    }
}
