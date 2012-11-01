using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class Home : System.Web.UI.Page
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Detect User Access Level
            String accessNet = (Session["UserID"]).ToString();
            int labNum = myConn.getLab(accessNet);
            //save User Lab in Session
            Session["Lab"] = labNum;


        }
    }
}