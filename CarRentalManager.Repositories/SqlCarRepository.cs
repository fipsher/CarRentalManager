using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CarRentalManager.Entities;

namespace CarRentalManager.Repositories
{
    public class SqlCarRepository: ICarRepository
    {
        //Declaring queries for stored procedures
        private const string _spGetPriceListQuery = "spGetPriceList";
        private const string _spGetAvailableCarsQuery = "spGetAvailableCars";
        private const string _spGetDelayedCarsQuery = "spGetDelayedCars";
        private readonly string _connectionString;

        public SqlCarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
//Rewiew AZ: 
        /// <summary>
        /// Create summary like this (more informative)
        /// </summary>
        /// <returns></returns>
        //Getting price list
        public List<Car> GetPriceList()
        {
            List<Car> priceList = new List<Car>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spGetPriceListQuery;                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            Car vehicle = new Car();
                            vehicle.Id = (int)reader["Id"];
                            vehicle.Class = (string)reader["Class"];
                            vehicle.Name = (string)reader["Name"];
                            vehicle.PassangerNum = (int)reader["PassengerNum"];
                            vehicle.FuelConsuption = (decimal)reader["FuelConsuption"];
                            vehicle.Rate = (decimal)reader["Rate"];                            
                            priceList.Add(vehicle);
                        }                        
                    }
                }
            }
            return priceList;
        }

        //Getting cars available for certain period of time
        public List<Car> GetAvailableCars(string startDate, string endDate, string carClass,
                                          int passengerNum, decimal fuelConsumption, decimal carPrice)
        {
            List<Car> carsList = new List<Car>();

            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spGetAvailableCarsQuery;

                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@Class", carClass);
                    command.Parameters.AddWithValue("@Price", carPrice);
                    command.Parameters.AddWithValue("@PassengerNum", passengerNum);
                    command.Parameters.AddWithValue("@FuelConsuption", fuelConsumption);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Car vehicle = new Car();
                                vehicle.Id = (int)reader["Id"];
                                vehicle.Class = (string)reader["Class"];
                                vehicle.Name = (string)reader["Name"];
                                vehicle.PassangerNum = (int)reader["PassengerNum"];
                                vehicle.FuelConsuption = (decimal)reader["FuelConsuption"];
                                vehicle.Rate = (decimal)reader["Rate"];
                                carsList.Add(vehicle);
                            }
                        }
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return carsList;
        }

        //Getting cars whos users do not return them in time
        public List<DelayedCar> GetDelayedCars()
        {
            List<DelayedCar> carsList = new List<DelayedCar>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spGetDelayedCarsQuery;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            DelayedCar vehicle = new DelayedCar();
                            vehicle.Id = (int)reader["Id"];
                            vehicle.Class = (string)reader["Class"];
                            vehicle.Name = (string)reader["Name"];
                            vehicle.FirstName = (string)reader["FirstName"];
                            vehicle.LastName = (string)reader["LastName"];
                            vehicle.LicenseNum = (string)reader["LicenseNum"];
                            carsList.Add(vehicle);
                        }
                    }
                }
            }
            return carsList;
        }

    }
}
