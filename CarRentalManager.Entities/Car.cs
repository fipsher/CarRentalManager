using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string RegNum { get; set; }
        public int PassangerNum { get; set; }
        public decimal FuelConsuption { get; set; }
        public decimal Rate { get; set; }
        public bool isOperating { get; set; }
    }
}
