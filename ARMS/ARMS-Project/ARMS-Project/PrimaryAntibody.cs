using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class PrimaryAntibody
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUsername"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public int id { get; set; }
        public int lotID { get; set; }
        public String name { get; set; }
        public String solution { get; set; }
        public String hostSpecies { get; set; }
        public String format { get; set; }
        public String reactiveSpecies { get; set; }
        public double concentration { get; set; }
        public double workingDilution { get; set; }
        public String antigen { get; set; }
        public String phlourosphore { get; set; }
        public String protocolHREF { get; set; }

        /// <summary>
        /// Default constructor.  Auto-assigns the id based on next available autonumber integer in the database.
        /// </summary>
        public PrimaryAntibody()
        {
            id = myConn.getNextAvailablePrimaryAntibodyID();
            lotID = 0;
            name = "";
            solution = "";
            hostSpecies = "";
            format = "";
            reactiveSpecies = "";
            concentration = 0.0;
            workingDilution = 0.0;
            antigen = "";
            phlourosphore = "";
            protocolHREF = "";
        }

        /// <summary>
        /// Overloaded Constructor.  Does not auto-assign ID
        /// </summary>
        public PrimaryAntibody(int newID, int newLotID, String newName, String newSolution, String newHostSpecies, String newFormat, String newReactiveSpecies, double newConcentration, double newWorkingDilution, string newAntigen, String newPhlourosphore, String newProtocolHREF)
        {
            id = newID;
            lotID = newLotID;
            name = newName;
            solution = newSolution;
            hostSpecies = newHostSpecies;
            format = newFormat;
            reactiveSpecies = newReactiveSpecies;
            concentration = newConcentration;
            workingDilution = newWorkingDilution;
            antigen = newAntigen;
            phlourosphore = newPhlourosphore;
            protocolHREF = newProtocolHREF;
        }

        public String toString()
        {
            return("ID: "+id+" || Lot ID: "+lotID+" || Name: "+name+" || Solution: "+solution+" || Host Species: "+hostSpecies+" || Format: "+format+" || Reactive Species: "+reactiveSpecies+" || Concentration: "+concentration+" || Working Dilution: "+workingDilution+" || Antigen: "+antigen+" || Phlourosphore: "+phlourosphore+" || Protocol Location: "+protocolHREF)
        }
    }
}