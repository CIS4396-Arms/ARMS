using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class Construct
    {
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUsername"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public int labID { get; set; }
        public String name { get; set; }
        public String insert { get; set; }
        public String vector { get; set; }
        public String species { get; set; }
        public String antibioticResistance { get; set; }
        public String digestSite5 { get; set; }
        public String digestSite3 { get; set; }
        public String notes { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Construct()
        {
            id = 0;
            labID = 0;
            name = "";
            insert = "";
            vector = "";
            species = "";
            antibioticResistance = "";
            digestSite5 = "";
            digestSite3 = "";
            notes = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Construct objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public Construct(int newLabID, String newName, String newInsert, String newVector, String newSpecies, String newAntibioticResistance, String newDigestSite5, String newDigestSite3, String newNotes)
        {
            id = 0;
            labID = newLabID;
            name = newName;
            insert = newInsert;
            vector = newVector;
            species = newSpecies;
            antibioticResistance = newAntibioticResistance;
            digestSite5 = newDigestSite5;
            digestSite3 = newDigestSite3;
            notes = newNotes; 
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Construct records from the database (accounts for autonumbered ID). 
        /// </summary>
        public Construct(int newID, int newLabID, String newName, String newInsert, String newVector, String newSpecies, String newAntibioticResistance, String newDigestSite5, String newDigestSite3, String newNotes)
        {
            id = newID;
            labID = newLabID;
            name = newName;
            insert = newInsert;
            vector = newVector;
            species = newSpecies;
            antibioticResistance = newAntibioticResistance;
            digestSite5 = newDigestSite5;
            digestSite3 = newDigestSite3;
            notes = newNotes;
        }

        /// <summary>
        /// Compares the ID of the current Construct object to that of a provided Construct
        /// </summary>
        /// <param name="temp">Construct object to be compared to.</param>
        /// <returns>True if the ID's are equal (meaning the constructs are the same), false otherwise.</returns>
        public Boolean Equals(Construct temp)
        {
            return this.id == temp.id;
        }

        /// <summary>
        /// Returns a text representation of the Construct object.
        /// </summary>
        public String toString()
        {
            return ("Construct || ID: " + id + " || Lab ID: " + labID + " || Name: " + name + " || Insert: " + insert + " || Vector: " + vector + " || Species: " + species + " || Antibiotic Resistance: " + antibioticResistance + " || 5' Digest Site: " + digestSite5 + " || 3' Digest Site: " + digestSite3 + " || Notes: " + notes);
        }
    }
}