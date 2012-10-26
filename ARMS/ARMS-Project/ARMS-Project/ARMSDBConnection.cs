using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

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
        /// Inserts the provided Construct object as a new record into the database
        /// </summary>
        /// <param name="temp">Construct object to be added to the database</param>
        public void addConstruct(Construct temp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the provided PrimaryAntibody object as a new record into the database
        /// </summary>
        /// <param name="temp">PrimaryAntibody object to be added to the database</param>
        public void addPrimaryAntibody(PrimaryAntibody temp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the provided SecondaryAntibody object as a new record into the database
        /// </summary>
        /// <param name="temp">SecondaryAntibody object to be added to the database</param>
        public void addSecondaryAntibody(SecondaryAntibody temp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the provided Vector object as a new record into the database
        /// </summary>
        /// <param name="temp">Vector object to be added to the database</param>
        public void addVector(Vector temp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets every Construct record in the database, saves each one in a new Construct object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Construct objects</returns>
        public ArrayList getAllConstructs()
        {
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getConstructRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Construct tempConstruct = new Construct(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString());
                temp.Add(tempConstruct);
            }
            return temp;
        }

        /// <summary>
        /// Gets every Primary Antibody record in the database, saves each one in a new Primary Antibody object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Primary Antibody objects</returns>
        public ArrayList getAllPrimaryAntibodies()
        {
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getPrimaryAntibodyRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PrimaryAntibody tempPrimaryAntibody = new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString());
                temp.Add(tempPrimaryAntibody);
            }
            return temp;
        }

        /// <summary>
        /// Gets every SecondaryAntibody record in the database, saves each one in a new SecondaryAntibody object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Secondary Antibody objects</returns>
        public ArrayList getAllSecondaryAntibodies()
        {
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getSecondaryAntibodyRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SecondaryAntibody tempSecondaryAntibody = new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), Convert.ToInt32(rdr.GetValue(0)));
                temp.Add(tempSecondaryAntibody);
            }
            return temp;
        }

        /// <summary>
        /// Gets every Vector record in the database, saves each one in a new Vector object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Vector objects</returns>
        public ArrayList getAllVectors()
        {
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getVectorRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Vector tempVector = new Vector(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString());
                temp.Add(tempVector);
            }
            return temp;
        }

        /// <summary>
        /// Untested so far.  Checks the database for the next available construct ID.  Used to allow the application to know what the id of a new construct will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available construct ID.</returns>
        public int getNextAvailableConstructID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from Construct ORDER BY ID DESC;").ExecuteScalar())+1;
        }

        /// <summary>
        /// Untested so far.  Checks the database for the next available primary antibody ID.  Used to allow the application to know what the id of a new antibody will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available primary antibody ID.</returns>
        public int getNextAvailablePrimaryAntibodyID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from PrimaryAntibody ORDER BY ID DESC;").ExecuteScalar())+1;
        }

        /// <summary>
        /// Untested so far.  Checks the database for the next available secondary antibody ID.  Used to allow the application to know what the id of a new antibody will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available secondary antibody ID.</returns>
        public int getNextAvailableSecondaryAntibodyID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from SecondaryAntibody ORDER BY ID DESC;").ExecuteScalar())+1;
        }

        /// <summary>
        /// Untested so far.  Checks the database for the next available vector ID.  Used to allow the application to know what the id of a new vector will be before it's inserted into the database.
        /// </summary>
        /// <returns>Integer value the next available construct ID.</returns>
        public int getNextAvailableVectorID()
        {
            return ((int)new SqlCommand("SELECT TOP 1 ID from Vector ORDER BY ID DESC;").ExecuteScalar()) + 1;
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