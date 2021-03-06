﻿using System;
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
        /// Inserts the provided lab object as a new record into the database
        /// </summary>
        /// <param name="temp">Construct object to be added to the database</param>
        /// <returns>True if add is successful, false otherwise</returns>
        public Boolean addLab(Lab temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Lab VALUES('" + temp.name + "');", conn);
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
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.SecondaryAntibody VALUES(" + temp.labID + ",'" + temp.concentration + "','" + temp.excitation + "','" + temp.antibodyName + "','" + temp.hostSpecies + "','" + temp.reactiveSpecies + "','" + temp.fluorophore + "','" + temp.workingDilution + "','" + temp.lotNumber + "','" + temp.antigen + "','" + temp.applications + "');", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Inserts the provided User object as a new record into the database with temporary password
        /// </summary>
        /// <param name="temp">User object to be added to the database</param>
        /// <returns>True if add is successful, false otherwise</returns>
        public Boolean addUser(User temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.RMS_User VALUES('" + temp.AccessnetID + "'," + temp.labID + ",'" + temp.fullName + "', 'DEFAULT'" + ",'" + temp.email + "');", conn);
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
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Vector VALUES(" + temp.id + "," + temp.labID + ",'" + temp.vectorName + "','" + temp.multipleCloningSite + "','" + temp.antibioticResistance + "','" + temp.vectorSize + "','" + temp.promoter + "','" + temp.notes + "','" + temp.specSheetHREF + "');", conn);
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
                Construct tempConstruct = new Construct(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(11).ToString());
                temp.Add(tempConstruct);
            }
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets an ArrayList of all Lab objects in the database
        /// </summary>
        /// <returns>ArrayList of all labs in the database</returns>
        public ArrayList getAllLabs()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Lab;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while (rdr.Read())
                tempList.Add(new Lab(Convert.ToInt32(rdr.GetValue(0)), rdr.GetValue(1).ToString()));
            conn.Close();
            return tempList;
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
                PrimaryAntibody tempPrimaryAntibody = new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString(), rdr.GetValue(14).ToString(), rdr.GetValue(15).ToString(), rdr.GetValue(17).ToString());
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
                SecondaryAntibody tempSecondaryAntibody = new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(13).ToString());
                temp.Add(tempSecondaryAntibody);
            }
            conn.Close();
            return temp;
        }

        /// <summary>
        /// Gets an ArrayList of all Users in the database
        /// </summary>
        /// <returns>ArrayList of all users in the database</returns>
        public ArrayList getAllLabUsers()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RMS_User;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while (rdr.Read())
                tempList.Add(new User(rdr.GetValue(0).ToString(), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString()));
            conn.Close();
            return tempList;
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
                Vector tempVector = new Vector(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(10).ToString());
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
                tempList.Add(new Construct(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(11).ToString()));
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
                tempList.Add(new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString(), rdr.GetValue(14).ToString(), rdr.GetValue(15).ToString(), rdr.GetValue(17).ToString()));
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
                tempList.Add(new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(13).ToString()));
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
                tempList.Add(new Vector(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(10).ToString()));
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
                temp = new Construct(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), null);
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
                temp = new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString(), rdr.GetValue(14).ToString(), rdr.GetValue(15).ToString(), null);
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
                temp = new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), null);
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
                temp = new Vector(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), null);
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
            SqlCommand cmd = new SqlCommand("SELECT Lab_ID FROM RMS_USER WHERE AccessNet_ID='"+accessNetID+"';", conn);
            object tempObj = cmd.ExecuteScalar();
            conn.Close();
            if (tempObj == null)
                return -1;
            else
                return Convert.ToInt32(tempObj);
        }

        /// <summary>
        /// Returns an ArrayList full of Construct objects where the search terms with matches in the specified column 
        /// </summary>
        /// <param name="colName">Database column name to be searched</param>
        /// <param name="searchTerms">Words to be searched for</param>
        /// <returns>ArrayList of matching construct objects</returns>
        public ArrayList searchForConstructs(String colName, String searchTerms)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Construct JOIN Lab ON [Construct].[LabID]=[Lab].[Lab_ID] WHERE [" + colName + "] LIKE '%" + searchTerms + "%';", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while (rdr.Read())
                tempList.Add(new Construct(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(11).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Returns an ArrayList full of PrimaryAntibody objects where the search terms with matches in the specified column 
        /// </summary>
        /// <param name="colName">Database column name to be searched</param>
        /// <param name="searchTerms">Words to be searched for</param>
        /// <returns>ArrayList of matching PrimaryAntibody objects</returns>
        public ArrayList searchForPrimaryAntibodies(String colName, String searchTerms)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PrimaryAntibody JOIN Lab ON PrimaryAntibody.LabID=Lab.Lab_ID WHERE " + colName + " LIKE '%" + searchTerms + "%';", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while (rdr.Read())
                tempList.Add(new PrimaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(12).ToString(), rdr.GetValue(13).ToString(), rdr.GetValue(14).ToString(), rdr.GetValue(15).ToString(), rdr.GetValue(17).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Returns an ArrayList full of SecondaryAntibody objects where the search terms with matches in the specified column 
        /// </summary>
        /// <param name="colName">Database column name to be searched</param>
        /// <param name="searchTerms">Words to be searched for</param>
        /// <returns>ArrayList of matching SecondaryAntibody objects</returns>
        public ArrayList searchForSecondaryAntibodies(String colName, String searchTerms)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SecondaryAntibody JOIN Lab ON SecondaryAntibody.LabID=Lab.Lab_ID WHERE " + colName + " LIKE '%" + searchTerms + "%';", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            ArrayList tempList = new ArrayList();
            while (rdr.Read())
                tempList.Add(new SecondaryAntibody(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(10).ToString(), rdr.GetValue(11).ToString(), rdr.GetValue(13).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Returns an ArrayList full of Vector objects where the search terms with matches in the specified column 
        /// </summary>
        /// <param name="colName">Database column name to be searched</param>
        /// <param name="searchTerms">Words to be searched for</param>
        /// <returns>ArrayList of matching Vector objects</returns>
        public ArrayList searchForVectors(String colName, String searchTerms)
        {
            conn.Open();
            ArrayList tempList = new ArrayList();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Vector JOIN Lab ON Vector.LabID=Lab.Lab_ID WHERE " + colName + " LIKE '%" + searchTerms + "%';", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                tempList.Add(new Vector(Convert.ToInt32(rdr.GetValue(0)), Convert.ToInt32(rdr.GetValue(1)), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), rdr.GetValue(4).ToString(), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(10).ToString()));
            conn.Close();
            return tempList;
        }

        /// <summary>
        /// Updates the construct record with the matching ID
        /// </summary>
        /// <param name="temp">Construct object to be written to the database</param>
        public Boolean updateConstruct(Construct temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE dbo.Construct SET LabID='" + temp.labID + "', Name='" + temp.name + "', [Construct].[Insert]='" + temp.insert + "', Vector='" + temp.vector + "', Species='" + temp.species + "', AntibioticResistance='" + temp.antibioticResistance + "', [Construct].[3'DigestSite]='" + temp.digestSite3 + "', [Construct].[5'DigestSite]='" + temp.digestSite5 + "', Note='" + temp.notes + "' WHERE ID=" + temp.id + ";", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates the primary antibody record with the matching ID
        /// </summary>
        /// <param name="temp">PrimaryAntibody object to be written to the database</param>
        public Boolean updatePrimaryAntibody(PrimaryAntibody temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE dbo.PrimaryAntibody SET LabID='" + temp.labID + "', LotNumber='" + temp.lotNumber + "', AntibodyName='" + temp.name + "', Type='" + temp.type + "', Clone='" + temp.clone + "', HostSpecies='" + temp.hostSpecies + "', ReactiveSpecies='" + temp.reactiveSpecies + "', Concentration='" + temp.concentration + "', WorkingDilution='" + temp.workingDilution + "', Applications='" + temp.applications + "', AntibodyIsotype='" + temp.isotype + "', Antigen='" + temp.antigen + "', Fluorophore='" + temp.fluorophore + "', ProtocolAttachments='" + temp.protocolHREF + "', SpecSheet='" + temp.specSheetHREF + "' WHERE ID=" + temp.id + ";", conn);
            Console.WriteLine(cmd);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates the secondary antibody record with the matching ID
        /// </summary>
        /// <param name="temp">SecondaryAntibody object to be written to the database</param>
        public Boolean updateSecondaryAntibody(SecondaryAntibody temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE dbo.SecondaryAntibody SET LabID='" + temp.labID + "', Concentration='" + temp.concentration + "', Excitation='" + temp.excitation + "', AntibodyName='" + temp.antibodyName + "', HostSpecies='" + temp.hostSpecies + "', ReactiveSpecies='" + temp.reactiveSpecies + "', Fluorophore='" + temp.fluorophore + "', WorkingDilution='" + temp.workingDilution + "', LotNumber='" + temp.lotNumber + "', Antigen='" + temp.antigen + "', Applications='" + temp.applications + "' WHERE ID=" + temp.id + ";", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates the vector record with the specified ID
        /// </summary>
        /// <param name="temp">Vector object to be written to the database</param>
        public Boolean updateVector(Vector temp)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE dbo.Vector SET LabID='" + temp.labID + "', VectorName='" + temp.vectorName + "', MultipleCloningSite='" + temp.multipleCloningSite + "', AntibioticResistance='" + temp.antibioticResistance + "', VectorSize='" + temp.vectorSize + "', Promoter='" + temp.promoter + "', Note='" + temp.notes + "', SpecSheet='" + temp.specSheetHREF + "' WHERE ID=" + temp.id + ";", conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates user password
        /// </summary>
        /// <param name="uname">Username</param>
        /// <param name="upass">new Passwords</param>
        /// <returns>true if successful update, false if unsuccesful</returns>
        public Boolean updatePassword(String upass, String uname)
        {
            string sql;
            conn.Open();
            sql = "UPDATE dbo.RMS_User SET Password='" + upass + "' WHERE AccessNet_ID='" + uname + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Validates user login name and pass. 
        /// </summary>
        /// <param name="uname">Username</param>
        /// <param name="upass">Password</param>
        /// <returns>1 if valid, -1 if invalid, 0 if password needs to be changed</returns>
        public int CheckLogin(String uname, String upass)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RMS_USER WHERE AccessNet_ID='" + uname + "' AND Password='" + upass + "';", conn);
            object tempObj = cmd.ExecuteScalar();
            conn.Close();
            if (tempObj == null)
                return -1;
            else
                if (upass != "DEFAULT" && !upass.Contains("TEMP"))
                    return 1;
                else
                    return 0;
        }

        /// <summary>
        /// Checks to see if the specified user exists
        /// </summary>
        /// <param name="uname">Username</param>
        /// <returns>True if user exists, false otherwise</returns>
        public Boolean UserExists(String uname)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RMS_USER WHERE AccessNet_ID='" + uname + "';", conn);
            object tempObj = cmd.ExecuteScalar();
            conn.Close();
            if (tempObj == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Gets the associated email address
        /// </summary>
        /// <param name="uname">Username</param>
        /// <returns>Email address of the associated user</returns>
        public String GetUserEmail(String uname)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Email FROM RMS_USER WHERE AccessNet_ID='" + uname + "';", conn);
            String tempObj = cmd.ExecuteScalar().ToString();
            conn.Close();
            return tempObj;
        }
     
    }
}