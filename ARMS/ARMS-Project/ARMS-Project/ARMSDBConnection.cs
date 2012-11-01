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
                conn.Close();
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
        public Boolean addConstruct(Construct temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Construct VALUES('"+temp.name+"','"+temp.source+"','"+temp.digestSite5+"','"+temp.digestSite3+"','"+temp.buffer+"','"+temp.notes+"');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts the provided PrimaryAntibody object as a new record into the database
        /// </summary>
        /// <param name="temp">PrimaryAntibody object to be added to the database</param>
        public Boolean addPrimaryAntibody(PrimaryAntibody temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.PrimaryAntibody VALUES('" + temp.labID + "','" + temp.lotNumber + "','" + temp.enzymeName + "','" + temp.solution + "','" + temp.clone + "','" + temp.hostSpecies + "','" + temp.format + "','" + temp.reactiveSpecies + "','" + temp.concentration + "','" + temp.workingDilution + "','" + temp.antigen + "','" + temp.phlourosphore + "','" + temp.protocolHREF + "');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i);
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts the provided SecondaryAntibody object as a new record into the database
        /// </summary>
        /// <param name="temp">SecondaryAntibody object to be added to the database</param>
        public Boolean addSecondaryAntibody(SecondaryAntibody temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.SecondaryAntibody VALUES('" + temp.concentration + "','" + temp.color + "','" + temp.excitation + "','" + temp.labID +"');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts the provided Vector object as a new record into the database
        /// </summary>
        /// <param name="temp">Vector object to be added to the database</param>
        public Boolean addVector(Vector temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Vector VALUES('" + temp.MCS + "','" + temp.ARS + "','" + temp.promoter + "','" + temp.sizeVP + "','" + temp.notes + "');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets every Construct record in the database, saves each one in a new Construct object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Construct objects</returns>
        public ArrayList getAllConstructs()
        {
            conn.Open();
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getConstructRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Construct tempConstruct = new Construct(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString());
                temp.Add(tempConstruct);
            }
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets every Primary Antibody record in the database, saves each one in a new Primary Antibody object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Primary Antibody objects</returns>
        public ArrayList getAllPrimaryAntibodies()
        {
            conn.Open();
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getPrimaryAntibodyRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PrimaryAntibody tempPrimaryAntibody = new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString());
                temp.Add(tempPrimaryAntibody);
            }
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets every SecondaryAntibody record in the database, saves each one in a new SecondaryAntibody object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Secondary Antibody objects</returns>
        public ArrayList getAllSecondaryAntibodies()
        {
            conn.Open();
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getSecondaryAntibodyRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SecondaryAntibody tempSecondaryAntibody = new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), Convert.ToInt32(rdr.GetValue(0)));
                temp.Add(tempSecondaryAntibody);
            }
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets every Vector record in the database, saves each one in a new Vector object, and puts it in an ArrayList.
        /// </summary>
        /// <returns>ArrayList of Vector objects</returns>
        public ArrayList getAllVectors()
        {
            conn.Open();
            ArrayList temp = new ArrayList();
            SqlCommand cmd = new SqlCommand("dbo.getVectorRecords", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Vector tempVector = new Vector(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString());
                temp.Add(tempVector);
            }
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Not yet implemented.  Gets the construct denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the construct to be located</param>
        /// <returns>Construct object if found, -1 if not</returns>
        public Construct getConstructByID(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not yet implemented.  Gets the SecondaryAntibody denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the SecondaryAntibody to be located</param>
        /// <returns>SecondaryAntibody object if found, -1 if not</returns>
        public SecondaryAntibodies getSecondaryAntibodyByID(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not yet implemented.  Gets the PrimaryAntibody denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the PrimaryAntibody to be located</param>
        /// <returns>PrimaryAntibody object if found, -1 if not</returns>
        public PrimaryAntibody getPrimaryAntibodyByID(int id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Not yet implemented.  Gets the Vector denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the Vector to be located</param>
        /// <returns>Vector object if found, -1 if not</returns>
        public Vector getVectorByID(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not yet implemented.  Takes an accessnet ID of a user and returns that user's lab ID
        /// </summary>
        /// <param name="accessNetID">TUid of the user whose lab is to be found</param>
        /// <returns>Lab ID of the user provided.  0 if global, -1 if not found</returns>
        public int getLab(String accessNetID)
        {
            throw new NotImplementedException();
            
        }
    }
}