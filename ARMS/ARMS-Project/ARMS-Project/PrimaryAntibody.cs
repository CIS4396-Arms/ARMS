using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Web;

namespace ARMS_Project
{

    public class PrimaryAntibodyLogic
    {
        // Get all antibodies
        public static DataTable GetPrimaryAntibodies()
        {
            ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return HelperMethods.ConvertArrayListToDataTable(myConn.getAllPrimaryAntibodies());
        }

        // Get primary antibodies that match keyword
        public static DataTable GetPrimaryAntibodies(String filter, String Keyword)
        {
            ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return HelperMethods.ConvertArrayListToDataTable(myConn.getAllPrimaryAntibodies());
        }

    }

    public class PrimaryAntibody
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public int labID { get; set; }
        public String lotNumber { get; set; }
        public String enzymeName { get; set; }
        public String solution { get; set; }
        public String clone { get; set; }
        public String hostSpecies { get; set; }
        public String format { get; set; }
        public String reactiveSpecies { get; set; }
        public String concentration { get; set; }
        public String workingDilution { get; set; }
        public String antigen { get; set; }
        public String phlourosphore { get; set; }
        public String protocolHREF { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrimaryAntibody()
        {
            labID = 0;
            lotNumber = "";
            enzymeName = "";
            solution = "";
            clone = "";
            hostSpecies = "";
            format = "";
            reactiveSpecies = "";
            concentration = "";
            workingDilution = "";
            antigen = "";
            phlourosphore = "";
            protocolHREF = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Primary Antibody objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public PrimaryAntibody(int newLabID, String newLotNumber, String newenzymeName, String newSolution, String newClone, String newHostSpecies, String newFormat, String newReactiveSpecies, String newConcentration, String newWorkingDilution, String newAntigen, String newPhlourosphore, String newProtocolHREF)
        {
            labID = newLabID;
            lotNumber = newLotNumber;
            enzymeName = newenzymeName;
            solution = newSolution;
            clone = newClone;
            hostSpecies = newHostSpecies;
            format = newFormat;
            reactiveSpecies = newReactiveSpecies;
            concentration = newConcentration;
            workingDilution = newWorkingDilution;
            antigen = newAntigen;
            phlourosphore = newPhlourosphore;
            protocolHREF = newProtocolHREF;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Primary Antibody records from the database (accounts for autonumbered ID). 
        /// </summary>
        public PrimaryAntibody(int newID, int newLabID, String newLotNumber, String newenzymeName, String newSolution, String newClone, String newHostSpecies, String newFormat, String newReactiveSpecies, String newConcentration, String newWorkingDilution, String newAntigen, String newPhlourosphore, String newProtocolHREF)
        {
            id = newID;
            labID = newLabID;
            lotNumber = newLotNumber;
            enzymeName = newenzymeName;
            solution = newSolution;
            clone = newClone;
            hostSpecies = newHostSpecies;
            format = newFormat;
            reactiveSpecies = newReactiveSpecies;
            concentration = newConcentration;
            workingDilution = newWorkingDilution;
            antigen = newAntigen;
            phlourosphore = newPhlourosphore;
            protocolHREF = newProtocolHREF;
        }

        /// <summary>
        /// Compares the ID of the current PrimaryAntibody object to that of a provided PrimaryAntibody
        /// </summary>
        /// <param enzymeName="temp">PrimaryAntibody object to be compared to.</param>
        /// <returns>True if the ID's are equal (meaning the antibodies are the same), false otherwise.</returns>
        public Boolean Equals(PrimaryAntibody temp)
        {
            return this.id == temp.id;
        }

        /// <summary>
        /// Returns a text representation of the SecondaryAntibody object.
        /// </summary>
        public String toString()
        {
            return ("Antobody Type: Primary || ID: " + id + " || Lab ID: " + labID + " || Lot Number: " + lotNumber + " || Enzyme Name: " + enzymeName + " || Solution: " + solution + " || Clone:  "+ clone + " || Host Species: " + hostSpecies + " || Format: " + format + " || Reactive Species: " + reactiveSpecies + " || Concentration: " + concentration + " || Working Dilution: " + workingDilution + " || Antigen: " + antigen + " || Phlourosphore: " + phlourosphore + " || Protocol Location: " + protocolHREF);
        }
    }
}