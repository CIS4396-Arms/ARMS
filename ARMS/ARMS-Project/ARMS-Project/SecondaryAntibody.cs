using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class SecondaryAntibody
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUsername"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public String concentration { get; set; }
        public String color { get; set; }
        public String excitation { get; set; }
        public int labID { get; set; }

        /// <summary>
        /// Default constructor.  Auto-assigns the id based on next available autonumber integer in the database.
        /// </summary>
        public SecondaryAntibody()
        {
            id = myConn.getNextAvailableSecondaryAntibodyID();
            concentration = "";
            color = "";
            excitation = "";
            labID = 0;
        }

        /// <summary>
        /// Overloaded Constructor.  Does not auto-assign ID
        /// </summary>
        public SecondaryAntibody(int newID, String newConcentration, String newColor, String newExcitation, int newLabID)
        {
            id = newID ;
            concentration = newConcentration;
            color = newColor;
            excitation = newExcitation;
            labID = 0;
        }

        /// <summary>
        /// Compares the ID of the current SecondaryAntibody object to that of a provided SecondaryAntibody
        /// </summary>
        /// <param name="temp">SecondaryAntibody object to be compared to.</param>
        /// <returns>True if the ID's are equal (meaning the antibodies are the same), false otherwise.</returns>
        public Boolean Equals(SecondaryAntibody temp)
        {
            return this.id == temp.id;
        }

        /// <summary>
        /// Returns a text representation of the SecondaryAntibody object.
        /// </summary>
        public String toString()
        {
            return ("Antibody Type: Secondary || ID: " + id + " || Concentration: " + concentration + " || Color: " + color + " || Excitation: " + excitation + " || Lab ID: " + labID);
        }
    }
}