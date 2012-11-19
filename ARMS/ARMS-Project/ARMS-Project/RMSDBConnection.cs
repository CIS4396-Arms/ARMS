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
    public class RMSDBConnection
    {
        SqlConnection conn;

        public RMSDBConnection(String username, String password, String serverURL, String database)
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
        /// <returns>True if add is successful, false otherwise</returns>
        public Boolean addConstruct(Construct temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Construct VALUES(" + temp.labID + ",'" + temp.name + "','" + temp.insert + "','" + temp.vector + "','" + temp.species + "','" + temp.antibioticResistance + "','" + temp.digestSite5 + "','" + temp.digestSite3 + "','" + temp.notes + "');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Inserts the provided PrimaryAntibody object as a new record into the database
        /// </summary>
        /// <param name="temp">PrimaryAntibody object to be added to the database</param>
        /// <returns>True if add is successful, false otherwise</returns>
        public Boolean addPrimaryAntibody(PrimaryAntibody temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.PrimaryAntibody VALUES(" + temp.labID + ",'" + temp.lotNumber + "','" + temp.name + "','" + temp.type + "','" + temp.clone + "','" + temp.hostSpecies + "','" + temp.reactiveSpecies + "','" + temp.concentration + "','" + temp.workingDilution + "','" + temp.applications + "','" + temp.isotype + "','" + temp.antigen + "','" + temp.fluorophore + "','" + temp.protocolHREF + "','" + temp.specSheetHREF + "');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i);
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Inserts the provided SecondaryAntibody object as a new record into the database
        /// </summary>
        /// <param name="temp">SecondaryAntibody object to be added to the database</param>
        /// <returns>True if add is successful, false otherwise</returns>
        public Boolean addSecondaryAntibody(SecondaryAntibody temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.SecondaryAntibody VALUES(" + temp.labID + ",'" + temp.concentration + "','" + temp.excitation + "','" + temp.antibodyName + "','" + temp.hostSpecies + "','" + temp.reactiveSpecies + "','" + temp.flourophore + "','" + temp.workingDilution + "','" + temp.lotNumber + "','" + temp.antigen + "','" + temp.applications + "');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Inserts the provided Vector object as a new record into the database
        /// </summary>
        /// <param name="temp">Vector object to be added to the database</param>
        /// <returns>True if add is successful, false otherwise</returns>
        public Boolean addVector(Vector temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Vector VALUES('" + temp.MCS + "','" + temp.ARS + "','" + temp.promoter + "','" + temp.sizeVP + "','" + temp.notes + "');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes the construct record with the specified ID
        /// </summary>
        /// <param name="id">ID of the construct to be deleted</param>
        /// <returns>True if successful, false otherwise.</returns>
        public Boolean deleteConstruct(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Construct WHERE ID="+id+";", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i);
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Delete the primary antibody record with the specified ID
        /// </summary>
        /// <param name="id">ID of the primary antibody to be deleted</param>
        /// /// <returns>True if successful, false otherwise.</returns>
        public Boolean deletePrimaryAntibody(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.PrimaryAntibody WHERE ID=" + id + ";", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i);
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes the secondary antibody record with the specified ID
        /// </summary>
        /// <param name="id">ID of the secondary antibody to be deleted</param>
        /// <returns>True if successful, false otherwise.</returns>
        public Boolean deleteSecondaryAntibody(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.SecondaryAntibody WHERE ID=" + id + ";", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i);
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes the vector record with the specified ID
        /// </summary>
        /// <param name="id">ID of the vector to be deleted</param>
        /// <returns>True if successful, false otherwise.</returns>
        public Boolean deleteVector(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Vector WHERE ID=" + id + ";", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i);
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
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
                Construct tempConstruct = new Construct(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString());
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
                PrimaryAntibody tempPrimaryAntibody = new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString(), rdr.GetValue(14).ToString(), rdr.GetValue(15).ToString());
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
                SecondaryAntibody tempSecondaryAntibody = new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString());
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
        /// Gets an ArrayList of all construct objects in the database with the associated Lab ID.
        /// </summary>
        /// <param name="labID">ID of the lab that owns the construct</param>
        /// <returns>ArrayList of construct objects with the associated Lab ID</returns>
        public ArrayList getConstructsByLabID(int labID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Construct WHERE LabID=" + labID + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while(rdr.Read())
                tempList.Add(new Construct(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Gets an ArrayList of all Primary Antibody objects in the database with the associated Lab ID.
        /// </summary>
        /// <param name="labID">ID of the lab that owns the construct</param>
        /// <returns>ArrayList of Primary Antibody objects with the associated Lab ID</returns>
        public ArrayList getPrimaryAntibodyByLabID(int labID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PrimaryAntibody WHERE LabID=" + labID + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while(rdr.Read())
                tempList.Add(new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString(), rdr.GetValue(14).ToString(), rdr.GetValue(15).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Gets an ArrayList of all Secondary Antibody objects in the database with the associated Lab ID.
        /// </summary>
        /// <param name="labID">ID of the lab that owns the construct</param>
        /// <returns>ArrayList of Secondary Antibody objects with the associated Lab ID</returns>
        public ArrayList getSecondaryAntibodyByLabID(int labID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SecondaryAntibody WHERE LabID=" + labID + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while(rdr.Read())
                tempList.Add(new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Gets an ArrayList of all Vector objects in the database with the associated Lab ID.
        /// </summary>
        /// <param name="labID">ID of the lab that owns the construct</param>
        /// <returns>ArrayList of Vector objects with the associated Lab ID</returns>
        public ArrayList getVectorByLabID(int labID)
        {
            conn.Open();
            ArrayList tempList = new ArrayList();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Vector WHERE LabID=" + labID + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
                tempList.Add(new Vector(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Gets the construct denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the construct to be located</param>
        /// <returns>Construct object if found, null if not</returns>
        public Construct getConstructByID(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Construct WHERE ID=" + id + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            Construct temp;
            if (rdr.Read())
                temp = new Construct(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString());
            else
                temp = null;
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets the PrimaryAntibody denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the PrimaryAntibody to be located</param>
        /// <returns>PrimaryAntibody object if found, null if not</returns>
        public PrimaryAntibody getPrimaryAntibodyByID(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PrimaryAntibody WHERE ID=" + id + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            PrimaryAntibody temp;
            if (rdr.Read())
                temp = new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString(), rdr.GetValue(14).ToString(), rdr.GetValue(15).ToString());
            else
                temp = null;
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets the SecondaryAntibody denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the SecondaryAntibody to be located</param>
        /// <returns>SecondaryAntibody object if found, null if not</returns>
        public SecondaryAntibody getSecondaryAntibodyByID(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SecondaryAntibody WHERE ID=" + id + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            SecondaryAntibody temp;
            if (rdr.Read())
                temp = new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString());
            else
                temp = null;
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets the Vector denoted by the provided ID
        /// </summary>
        /// <param name="id">ID of the Vector to be located</param>
        /// <returns>Vector object if found, null if not</returns>
        public Vector getVectorByID(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Vector WHERE ID=" + id + ";", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            Vector temp;
            if (rdr.Read())
                temp = new Vector(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString());
            else
                temp = null;
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Takes an accessnet ID of a user and returns that user's lab ID
        /// </summary>
        /// <param name="accessNetID">TUid of the user whose lab is to be found</param>
        /// <returns>Lab ID of the user provided.  0 if global, -1 if not found</returns>
        public int getLab(String accessNetID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Lab FROM Authentication WHERE AccessNet='"+accessNetID+"';", conn);
            object tempObj = cmd.ExecuteScalar();
            conn.Close();
            if (tempObj == null)
                return -1;
            else
                return Convert.ToInt32(tempObj);
        }

        /// <summary>
        /// Updates the construct record with the specified ID
        /// </summary>
        /// <param name="id">ID of the construct to be updated</param>
        public void updateConstruct(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the primary antibody record with the specified ID
        /// </summary>
        /// <param name="id">ID of the primary antibody to be updated</param>
        public void updatePrimaryAntibody(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the secondary antibody record with the specified ID
        /// </summary>
        /// <param name="id">ID of the secondary antibody to be updated</param>
        public void updateSecondaryAntibody(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the vector record with the specified ID
        /// </summary>
        /// <param name="id">ID of the vector to be updated</param>
        public void updateVector(int id)
        {
            throw new NotImplementedException();
        }
    }
}