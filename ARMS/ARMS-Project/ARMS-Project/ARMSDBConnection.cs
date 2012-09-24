using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

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
    }
}