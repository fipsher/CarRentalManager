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
    public class SqlOrderRepository: IOrderRepository
    {
        //Declaring queries for stored procedures
        private const string _spGetIncomeQuery = "spGetIncome";
        private const string _spCreateOrderQuery = "spCreateOrder";
        private const string _spCloseOrderQuery = "spCloseOrder";
        private readonly string _connectionString;

        public SqlOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }    

        //Get income of the company for certain period of time
        public List<Order> GetIncome(string startDate, string endDate)
        {
            List<Order> orderList = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spGetIncomeQuery;

                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                                      
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                      while (reader.Read())
                      {
                            Order givenOrder = new Order();
                            givenOrder.StartDay = reader["StartDate"].ToString();
                            givenOrder.EndDay = reader["EndDate"].ToString();
                            givenOrder.Income = reader["Income"].ToString() == "" ? 0 : (decimal)reader["Income"];
                            orderList.Add(givenOrder);
                      }
                    }
                    
                }
            }
            return orderList;
        }

        //Create order and return order details
        public List<Order> CreateOrder(string startDate, string endDate,
                                        string firstName, string lastName,
                                        string licenseNum, int carId, int userId)
        {
            List<Order> orderList = new List<Order>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spCreateOrderQuery;

                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@LicenseNum", licenseNum);
                    command.Parameters.AddWithValue("@CarId", carId);
                    command.Parameters.AddWithValue("@UserId", userId);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Order givenOrder = new Order();
                                givenOrder.Id = (int)reader["Id"];
                                givenOrder.FirstName = (string)reader["FirstName"];
                                givenOrder.LastName = (string)reader["LastName"];
                                givenOrder.LicenseNum = (string)reader["LicenseNum"];
                                givenOrder.CarId = (int)reader["CarId"];
                                givenOrder.CarName = (string)reader["CarName"];
                                givenOrder.StartDay = reader["StartDate"].ToString();
                                givenOrder.EndDay = reader["EndDate"].ToString();
                                givenOrder.Cost = (decimal)reader["Cost"];                                
                                givenOrder.isActive = (bool)reader["Active"];
                                givenOrder.isDelayed = (bool)reader["Delayed"];
                                givenOrder.UserId = (int)reader["UserId"];
                                orderList.Add(givenOrder);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return orderList;
        }

        //Close order after customer returnig car to the company and calculating penalty if delay happen
        public List<Order> CloseOrder(int orderId, int userId)
        {
            List<Order> orderList = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spCloseOrderQuery;
                    
                    command.Parameters.AddWithValue("@Id", orderId);
                    command.Parameters.AddWithValue("@UserId", userId);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Order givenOrder = new Order();
                                givenOrder.Id = (int)reader["Id"];
                                givenOrder.FirstName = (string)reader["FirstName"];
                                givenOrder.LastName = (string)reader["LastName"];
                                givenOrder.LicenseNum = (string)reader["LicenseNum"];
                                givenOrder.CarId = (int)reader["CarId"];
                                givenOrder.CarName = (string)reader["CarName"];
                                givenOrder.StartDay = reader["StartDate"].ToString();
                                givenOrder.EndDay = reader["EndDate"].ToString();
                                givenOrder.Cost = (decimal)reader["Cost"];
                                givenOrder.Penalty = (decimal)reader["Fine"];
                                givenOrder.isActive = (bool)reader["Active"];
                                givenOrder.isDelayed = (bool)reader["Delayed"];
                                givenOrder.UserId = (int)reader["UserId"];
                                orderList.Add(givenOrder);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return orderList;
        }

    }
}
