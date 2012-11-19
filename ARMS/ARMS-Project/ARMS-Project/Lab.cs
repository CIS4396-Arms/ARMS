using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class Lab
    {
        public int id;
        public String name;

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