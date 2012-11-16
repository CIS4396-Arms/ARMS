using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class Vector
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUsername"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public String MCS { get; set; }
        public String ARS { get; set; }
        public String promoter { get; set; }
        public String sizeVP { get; set; }
        public String notes { get; set; }

        /// <summary>
        /// Default constructor.  Auto-assigns the id based on next available autonumber integer in the database.
        /// </summary>
        public Vector()
        {
            MCS = "";
            ARS = "";
            promoter = "";
            sizeVP = "";
            notes = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Vector objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public Vector(String newMCS, String newARS, String newPromoter, String newSizeVP, String newNotes)
        {
            MCS = newMCS;
            ARS = newARS;
            promoter = newPromoter;
            sizeVP = newSizeVP;
            notes = newNotes;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Vector records from the database (accounts for autonumbered ID).
        /// </summary>
        public Vector(int newID, String newMCS, String newARS, String newPromoter, String newSizeVP, String newNotes)
        {
            id = newID;
            MCS = newMCS;
            ARS = newARS;
            promoter = newPromoter;
            sizeVP = newSizeVP;
            notes = newNotes;
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
            return ("Vector || ID: " + id + " || MCS : " + MCS + " || ARS: " + ARS + " || Promoter: " + promoter + " || SizeVP: " + sizeVP + " || Notes: " + notes);
        }
    }
}