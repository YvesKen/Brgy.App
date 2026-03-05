using System;
using Microsoft.Data.SqlClient;
using Brgy.Domain;

namespace Brgy.Service
{
    public class AuthService
    {
       
        private readonly string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BrgyDB;Integrated Security=True;Encrypt=False";

        public Account VerifyUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "SELECT Username, FullName, CODE FROM Accounts WHERE Username=@u AND Password=@p";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Account
                        {
                            Username = reader["Username"].ToString(),
                            FullName = reader["FullName"].ToString(),
                           
                            IsOfficial = reader["CODE"].ToString() == "Honey123"
                        };
                    }
                }
            }
            return null; 
        }

        public bool RegisterOfficial(Account acc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    string query = "INSERT INTO Accounts (Username, Password, FullName, CODE) VALUES (@u, @p, @n, @c)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", acc.Username);
                    cmd.Parameters.AddWithValue("@p", acc.Password);
                    cmd.Parameters.AddWithValue("@n", acc.FullName);
                    cmd.Parameters.AddWithValue("@c", acc.Code);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { return false; }
        }
    }
}