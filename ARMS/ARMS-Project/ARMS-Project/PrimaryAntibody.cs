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
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return HelperMethods.ConvertArrayListToDataTable(myConn.getAllPrimaryAntibodies());
        }

        // Get primary antibodies that match keyword
        public static DataTable GetPrimaryAntibodies(String filter, String keyword)
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return HelperMethods.ConvertArrayListToDataTable(myConn.searchForPrimaryAntibodies(@filter, @keyword));
        }

    }

    public class PrimaryAntibody
    {
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public int labID { get; set; }
        public String lotNumber { get; set; }
        public String name { get; set; }
        public String type { get; set; }
        public String clone { get; set; }
        public String hostSpecies { get; set; }
        public String reactiveSpecies { get; set; }
        public String concentration { get; set; }
        public String workingDilution { get; set; }
        public String applications { get; set; }
        public String isotype { get; set; }
        public String antigen { get; set; }
        public String fluorophore { get; set; }
        public String protocolHREF { get; set; }
        public String specSheetHREF { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrimaryAntibody()
        {
            labID = 0;
            lotNumber = "";
            name = "";
            type = "";
            clone = "";
            hostSpecies = "";
            reactiveSpecies = "";
            concentration = "";
            workingDilution = "";
            applications = "";
            isotype = "";
            antigen = "";
            fluorophore = "";
            protocolHREF = "";
            specSheetHREF = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Primary Antibody objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public PrimaryAntibody(int newLabID, String newLotNumber, String newName, String newType, String newClone, String newHostSpecies, String newReactiveSpecies, String newConcentration, String newWorkingDilution, String newApplications, String newIsotype, String newAntigen, String newFluorophore, String newProtocolHREF, String newSpecSheetHREF)
        {
            lotNumber = newLotNumber;
            name = newName;
            type = newType;
            clone = newClone;
            hostSpecies = newHostSpecies;
            reactiveSpecies = newReactiveSpecies;
            concentration = newConcentration;
            workingDilution = newWorkingDilution;
            applications = newApplications;
            isotype = newIsotype;
            antigen = newAntigen;
            fluorophore = newFluorophore;
            protocolHREF = newProtocolHREF;
            specSheetHREF = newSpecSheetHREF;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Primary Antibody records from the database (accounts for autonumbered ID). 
        /// </summary>
        public PrimaryAntibody(int newID, int newLabID, String newLotNumber, String newName, String newType, String newClone, String newHostSpecies, String newReactiveSpecies, String newConcentration, String newWorkingDilution, String newApplications, String newIsotype, String newAntigen, String newFluorophore, String newProtocolHREF, String newSpecSheetHREF)
        {
            id = newID;
            labID = newLabID;
            lotNumber = newLotNumber;
            name = newName;
            type = newType;
            clone = newClone;
            hostSpecies = newHostSpecies;
            reactiveSpecies = newReactiveSpecies;
            concentration = newConcentration;
            workingDilution = newWorkingDilution;
            applications = newApplications;
            isotype = newIsotype;
            antigen = newAntigen;
            fluorophore = newFluorophore;
            protocolHREF = newProtocolHREF;
            specSheetHREF = newSpecSheetHREF;
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
            return ("Antobody Type: Primary || ID: " + id + " || Lab ID: " + labID + " || Lot Number: " + lotNumber + " || Name: " + name + " || Type: " + type + " || Clone:  " + clone + " || Host Species: " + hostSpecies + " || Reactive Species: " + reactiveSpecies + " || Concentration: " + concentration + " || Working Dilution: " + workingDilution + " || Applications: " + applications + " || Isotype: " + isotype + " || Antigen: " + antigen + " || Fluorophore: " + fluorophore + " || Protocol Location: " + protocolHREF + " || Spec Sheet Location : " + specSheetHREF);
        }
    }
}