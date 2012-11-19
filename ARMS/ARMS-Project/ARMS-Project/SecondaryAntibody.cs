using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ARMS_Project
{

    public class SecondaryAntibodyLogic
    {
        // Get all antibodies
        public static DataTable GetSecondaryAntibodies()
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return HelperMethods.ConvertArrayListToDataTable(myConn.getAllSecondaryAntibodies());
        }

        // Get secondary antibodies that match keyword
        public static DataTable GetSecondaryAntibodies(String filter, String keyword)
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return HelperMethods.ConvertArrayListToDataTable(myConn.searchForSecondaryAntibodies(filter, keyword));
        }

    }

    public class SecondaryAntibody
    {
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUsername"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public int labID { get; set; }
        public String concentration { get; set; }
        public String excitation { get; set; }
        public String antibodyName { get; set; }
        public String hostSpecies { get; set; }
        public String reactiveSpecies { get; set; }
        public String flourophore { get; set; }
        public String workingDilution { get; set; }
        public String lotNumber { get; set; }
        public String antigen { get; set; }
        public String applications { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SecondaryAntibody()
        {
            id = 0;
            labID = 0;
            concentration = "";
            excitation = "";
            antibodyName = "";
            hostSpecies = "";
            reactiveSpecies = "";
            flourophore = "";
            workingDilution = "";
            lotNumber = "";
            antigen = "";
            applications = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Used for creation of new Secondary Antibody objects (does not assign value to ID, which is autonumbered in the database).
        /// </summary>
        public SecondaryAntibody(int newLabID, String newConcentration, String newExcitation, String newAntibodyName, String newHostSpecies, String newReactiveSpecies, String newFlourophore, String newWorkingDilution, String newLotNumber, String newAntigen, String newApplications)
        {
            id = 0;
            labID = newLabID;
            concentration = newConcentration;
            excitation = newExcitation;
            antibodyName = newAntibodyName;
            hostSpecies = newHostSpecies;
            reactiveSpecies = newReactiveSpecies;
            flourophore = newFlourophore;
            workingDilution = newWorkingDilution;
            lotNumber = newLotNumber;
            antigen = newAntigen;
            applications = newApplications;
        }

        /// <summary>
        /// Overloaded Constructor.  Used for retrieval and storage of Secondary Antibody records from the database (accounts for autonumbered ID). 
        /// </summary>
        public SecondaryAntibody(int newID, int newLabID, String newConcentration, String newExcitation, String newAntibodyName, String newHostSpecies, String newReactiveSpecies, String newFlourophore, String newWorkingDilution, String newLotNumber, String newAntigen, String newApplications)
        {
            id = newID;
            labID = newLabID;
            concentration = newConcentration;
            excitation = newExcitation;
            antibodyName = newAntibodyName;
            hostSpecies = newHostSpecies;
            reactiveSpecies = newReactiveSpecies;
            flourophore = newFlourophore;
            workingDilution = newWorkingDilution;
            lotNumber = newLotNumber;
            antigen = newAntigen;
            applications = newApplications;
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
            return ("Antibody Type: Secondary || ID: " + id + " || Lab ID: " + labID + " || Concentration: " + concentration + " || Excitation: " + excitation + " || Antibody Name: " + antibodyName + " || Host Species: " + hostSpecies + " || Reactive Species: " + reactiveSpecies + " || Flourophore: " + flourophore + " || Working Dilution: " + workingDilution + " || Lot Number: " + lotNumber + " || Antigen: " + antigen + " || Applications: " + applications);
        }
    }
}