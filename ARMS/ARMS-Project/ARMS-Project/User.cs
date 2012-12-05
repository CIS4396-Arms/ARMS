using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace ARMS_Project
{

    public class UserLogic
    {
        // Get all users
        public static ArrayList GetUsers()
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return myConn.getAllLabUsers();
        }
    }

    public class User
    {
        public String AccessnetID;
        public int labID;
        public String fullName;
        public String email;

        /// <summary>
        /// Default constructor.  Auto-assigns the id based on next available autonumber integer in the database.
        /// </summary>
        public User()
        {
            AccessnetID = "";
            labID = 0;
            fullName = "";
            email = "";
        }

        /// <summary>
        /// Overloaded Constructor.
        /// </summary>
        public User(String newAccessnetID, int newLabID, String newFullName, String newEmail)
        {
            AccessnetID = newAccessnetID;
            labID = newLabID;
            fullName = newFullName;
            email = newEmail;
        }

        /// <summary>
        /// Returns a text representation of the Lab object.
        /// </summary>
        public String toString()
        {
            return ("Accessnet ID: " + AccessnetID + " || Name: " + fullName + " || Lab ID: " + labID + " || Email: " + email);
        }
    }
}