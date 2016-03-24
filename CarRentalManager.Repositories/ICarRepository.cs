using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.Entities;

namespace CarRentalManager.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetPriceList();
        List<Car> GetAvailableCars(string startDate, string endDate, string carClass, 
                                    int passengerNum, decimal fuelConsumption, decimal carPrice);//Rewiew AZ: create filter class for cars to set it as input param here 
        List<DelayedCar> GetDelayedCars();

    }
}
