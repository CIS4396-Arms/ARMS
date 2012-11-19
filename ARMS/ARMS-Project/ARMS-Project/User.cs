using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class User
    {
        public String AccessnetID;
        public int labID;
        public String fullName;

        /// <summary>
        /// Default constructor.  Auto-assigns the id based on next available autonumber integer in the database.
        /// </summary>
        public User()
        {
            AccessnetID = "";
            labID = 0;
            fullName = "";
        }

        /// <summary>
        /// Overloaded Constructor.
        /// </summary>
        public User(String newAccessnetID, int newLabID, String newFullName)
        {
            AccessnetID = newAccessnetID;
            labID = newLabID;
            fullName = newFullName;
        }

        /// <summary>
        /// Returns a text representation of the Lab object.
        /// </summary>
        public String toString()
        {
            return("Accessnet ID: " + AccessnetID + " || Name: " + fullName + " || Lab ID: " + labID);
        }
    }
}