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
        public int labID { get; set; }
        public String concentration { get; set; }
        public String color { get; set; }
        public String excitation { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public SecondaryAntibody()
        {
            concentration = "";
            color = "";
            excitation = "";
            labID = 0;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Secondary Antibody objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public SecondaryAntibody(int newLabID, String newConcentration, String newColor, String newExcitation)
        {
            concentration = newConcentration;
            color = newColor;
            excitation = newExcitation;
            labID = newLabID;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Secondary Antibody records from the database (accounts for autonumbered ID). 
        /// </summary>
        public SecondaryAntibody(int newID, int newLabID, String newConcentration, String newColor, String newExcitation)
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
            return ("Antibody Type: Secondary || ID: " + id + " || Lab ID: " + labID + " || Concentration: " + concentration + " || Color: " + color + " || Excitation: " + excitation);
        }
    }
}