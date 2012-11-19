using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class Vector
    {
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUsername"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public int labID { get; set; }
        public String vectorName { get; set; }
        public String multipleCloningSite { get; set; }
        public String antibioticResistance { get; set; }
        public String vectorSize { get; set; }
        public String promoter { get; set; }
        public String notes { get; set; }
        public String specSheetHREF { get; set; }

        /// <summary>
        /// Default constructor.  Auto-assigns the id based on next available autonumber integer in the database.
        /// </summary>
        public Vector()
        {
            id = 0;
            labID = 0;
            vectorName = "";
            multipleCloningSite = "";
            antibioticResistance = "";
            vectorSize = "";
            promoter = "";
            notes = "";
            specSheetHREF = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Vector objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public Vector(int newLabID, String newVectorName, String newMultipleCloningSite, String newAntibioticResistance, String newVectorSize, String newPromoter, String newNotes, String newSpecSheetHREF)
        {
            id = 0;
            labID = newLabID;
            vectorName = newVectorName;
            multipleCloningSite = newMultipleCloningSite;
            antibioticResistance = newAntibioticResistance;
            vectorSize = newVectorSize;
            promoter = newPromoter;
            notes = newNotes;
            specSheetHREF = newSpecSheetHREF;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Vector records from the database (accounts for autonumbered ID).
        /// </summary>
        public Vector(int newID, int newLabID, String newVectorName, String newMultipleCloningSite, String newAntibioticResistance, String newVectorSize, String newPromoter, String newNotes, String newSpecSheetHREF)
        {
            id = newID;
            labID = newLabID;
            vectorName = newVectorName;
            multipleCloningSite = newMultipleCloningSite;
            antibioticResistance = newAntibioticResistance;
            vectorSize = newVectorSize;
            promoter = newPromoter;
            notes = newNotes;
            specSheetHREF = newSpecSheetHREF;
        }

        /// <summary>
        /// Compares the ID of the current Vector object to that of a provided Vector
        /// </summary>
        /// <param name="temp">Vector object to be compared to.</param>
        /// <returns>True if the ID's are equal (meaning the constructs are the same), false otherwise.</returns>
        public Boolean Equals(Vector temp)
        {
            return this.id == temp.id;
        }

        /// <summary>
        /// Returns a text representation of the Vector object.
        /// </summary>
        public String toString()
        {
            return ("Vector || ID: " + id + " || Lab ID: " + labID + " || Vector Name: " + vectorName + " || Multiple Cloning Site: " + multipleCloningSite + " || Antibiotic Resistance: " + antibioticResistance + " || Vector Size: " + vectorSize + " || Promoter: " + promoter + " || Notes: " + notes + " || Spec Sheet HREF: " + specSheetHREF);
        }
    }
}