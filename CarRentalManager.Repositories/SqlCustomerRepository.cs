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
    public class SqlCustomerRepository: ICustomerRepository
    {
        //Declaring query for stored procedure
        private const string _spGetCustomerHistoryQuery = "spGetCustomerHistory";        

        private readonly string _connectionString;

        public SqlCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Get history of customer orders
        public List<Order> GetCustomerHistory(string firstName, string lastName, string licenseNum)
        {
            List<Order> ordersList = new List<Order>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spGetCustomerHistoryQuery;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@LicenseNum", licenseNum);
                    
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
                                givenOrder.CarName = (string)reader["CarName"];
                                givenOrder.StartDay = reader["StartDate"].ToString();
                                givenOrder.EndDay = reader["EndDate"].ToString();
                                givenOrder.Cost = (decimal)reader["Cost"];
                                givenOrder.isActive = (bool)reader["Active"];
                                givenOrder.isDelayed = (bool)reader["Delayed"];
                                givenOrder.UserId = (int)reader["UserId"];
                                ordersList.Add(givenOrder);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return ordersList;
        }
    }
}
