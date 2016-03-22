using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.Entities;

namespace CarRentalManager.Repositories
{
    public interface ICustomerRepository
    {
        List<Order> GetCustomerHistory(string firstName, string lastName, string licenseNum);
    }
}
