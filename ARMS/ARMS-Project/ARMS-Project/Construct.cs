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
        public String name { get; set; }
        public String source { get; set; }
        public String digestSite5 { get; set; }
        public String digestSite3 { get; set; }
        public String buffer { get; set; }
        public String notes { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Construct()
        {
            name = "";
            source = "";
            digestSite5 = "";
            digestSite3 = "";
            buffer = "";
            notes = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Construct objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public Construct(String newName, String newSource, String newDigestSite5, String newDigestSite3, String newBuffer, String newNotes)
        {
            name = newName;
            source = newSource;
            digestSite5 = newDigestSite5;
            digestSite3 = newDigestSite3;
            buffer = newBuffer;
            notes = newNotes;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Construct records from the database (accounts for autonumbered ID). 
        /// </summary>
        public Construct(int newID, String newName, String newSource, String newDigestSite5, String newDigestSite3, String newBuffer, String newNotes)
        {
            id = newID;
            name = newName;
            source = newSource;
            digestSite5 = newDigestSite5;
            digestSite3 = newDigestSite3;
            buffer = newBuffer;
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
            return ("Construct || ID: " + id + " || Name = " + name + " || Source = " + source + " || 5' Digest Site: " + digestSite5 + " || 3' Digest Site: " + digestSite3 + " || Buffer: " + buffer + " || Notes: " + notes);
        }
    }
}