using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{

    public class LabLogic
    {
        // Get all antibodies
        public static ArrayList GetLabs()
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return myConn.getAllLabs();
        }

    }

    public class Lab
    {
        public int id { get; set; }
        public String name { get; set; }

        /// <summary>
        /// Default constructor.  Auto-assigns the id based on next available autonumber integer in the database.
        /// </summary>
        public Lab()
        {
            id = 0;
            name = "";
        }

        /// <summary>
        /// Overloaded Constructor.
        /// </summary>
        public Lab(String newName)
        {
            id = 0;
            name = newName;
        }

        /// <summary>
        /// Overloaded Constructor.
        /// </summary>
        public Lab(int newID, String newName)
        {
            id = newID;
            name = newName;
        }

        /// <summary>
        /// Returns a text representation of the Vector object.
        /// </summary>
        public String toString()
        {
            return ("Lab ID: " + id + " || Name: " + name);
        }
    }
}