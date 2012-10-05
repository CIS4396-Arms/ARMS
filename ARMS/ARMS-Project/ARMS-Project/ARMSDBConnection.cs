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
        SqlConnection conn;

        public ARMSDBConnection(String username, String password, String serverURL, String database)
        {
            conn = new SqlConnection("user id=" + username + ";password=" + password + ";server=" + serverURL + ";Trusted_Connection=no;database=" + database + ";connection timeout=30");
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

        /// <summary>
        /// Untested so far.  Checks the database for the next available construct ID.  Used to allow the application to know what the id of a new construct will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available construct ID.</returns>
        public int getNextAvailableConstructID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from ARMS_Construct ORDER BY ID DESC;").ExecuteScalar())+1;
        }

        /// <summary>
        /// Untested so far.  Checks the database for the next available primary antibody ID.  Used to allow the application to know what the id of a new antibody will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available primary antibody ID.</returns>
        public int getNextAvailablePrimaryAntibodyID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from ARMS_Primary_Antibody ORDER BY ID DESC;").ExecuteScalar())+1;
        }

        /// <summary>
        /// Untested so far.  Checks the database for the next available secondary antibody ID.  Used to allow the application to know what the id of a new antibody will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available secondary antibody ID.</returns>
        public int getNextAvailableSecondaryAntibodyID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from ARMS_Secondary_Antibody ORDER BY ID DESC;").ExecuteScalar())+1;
        }

        /// <summary>
        /// Untested so far.  Checks the database for the next available vector ID.  Used to allow the application to know what the id of a new vector will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available construct ID.</returns>
        public int getNextAvailableVectorID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from ARMS_Vector ORDER BY ID DESC;").ExecuteScalar()) + 1;
        }


        /// <summary>
        ///This function verifies the credential of a user by accessing the DB user table.  It takes as parameters the username and password and it returns true if the user is found.
        /// </summary>
        /// <param name="username">Username to be verified</param>
        /// <param name="password">Password to be verified for the specified user</param>
        /// <returns></returns>
        public bool verifyUserCredentials(string username, string password)
        {
            Boolean authorizedUser = false;
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
                    authorizedUser = true;
                else
                    authorizedUser = false;
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