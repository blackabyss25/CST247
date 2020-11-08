using Activity1Part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel user)
        {
            string query = "SELECT * FROM dbo.Users";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query,con);
                
                
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                finally
                {
                    con.Close();
                }
            } 
        }

    }
}