using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;


namespace CarRentalManager.Repositories
{

   
    public class SqlUserRepository : IUserRepository
    {
        //Declaring queries for stored procedures
        private const string _spGetUserByLoginQuery = "spGetUserByLogin";
        private readonly string _connectionString;

       public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Get hash for some string (password)
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        //Get user by Login and Password
        public User GetUserByLogin(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = _spGetUserByLoginQuery;
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", MD5Hash(password));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        User user = null;
                        if (reader.Read())
                        {
                            user = new User();
                            user.Id = (int)reader["Id"];
                            user.FirstName = (string)reader["FirstName"];
                            user.LastName = (string)reader["LastName"];
                            user.Login = (string)reader["Login"];
                            user.isDisabled = (bool)reader["Disabled"];
                        }
                        return user;
                    }
                }
            }
        }
    }
}
