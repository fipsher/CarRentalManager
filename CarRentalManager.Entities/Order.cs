using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNum { get; set; }
        public string CarName { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public decimal Cost { get; set; }
        public decimal Penalty { get; set; }
        public decimal Income { get; set; }
        public bool isActive { get; set; }
        public bool isDelayed { get; set; }
        public int UserId { get; set; }
        
    }
}
