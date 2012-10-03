using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ARMS_Project
{
    /**
     *      Author: A.J. Harnak
     *      Date: 9/24/2012
     *      Description: ARMSDBConnection connects and interacts with a specified Microsoft SQL Server Database
     **/
    public class ARMSDBConnection
    {
        public ARMSDBConnection(String username, String password, String serverURL, String database)
        {
            SqlConnection conn = new SqlConnection("user id=" + username + ";password=" + password + ";server=" + serverURL + ";Trusted_Connection=no;database=" + database + ";connection timeout=30");
            try
            {
                conn.Open();
                Console.WriteLine("Database connection successfully established.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Unable to connect to the specified database.  Please check the parameters and try again.\n"+e.ToString());
            }
        }

        
        //This function verifies the credential of a user by accessing the DB user table
        //It takes as parameters the username and password and it returns true if the user 
        //is found
        public bool verifyUserCredentials(string username, string password)
        {
            bool authorizedUser = false;

            try
            {
                SqlCommand objCommand = new SqlCommand();
                SqlDataReader dataReader = objCommand.ExecuteReader();

                //calling a store procedure that returns the user and password
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "FindUser";

                objCommand.Parameters.AddWithValue("@theUsername", username);
                objCommand.Parameters.AddWithValue("@thePassword", password);

                //if match is found return true, else return false
                if (dataReader.Read())
                {
                    authorizedUser = true;
                }
                else
                {
                    authorizedUser = false;
                }
                dataReader.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return authorizedUser;
        }
    }
}