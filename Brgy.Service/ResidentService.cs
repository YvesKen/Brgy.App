using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Brgy.Domain;
using System.Data;

namespace Brgy.Service
{
    public class ResidentService
    {
        private readonly string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BrgyDB;Integrated Security=True";

        
        public DataTable GetPopulationStats()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
              
                string query = "SELECT Category, TotalCount FROM PopulationStats";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }


        public bool UpdatePopulation(string category, int count)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    string query = "UPDATE PopulationStats SET TotalCount = @count WHERE Category = @cat";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@cat", category);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { return false; }
        }
    }
}