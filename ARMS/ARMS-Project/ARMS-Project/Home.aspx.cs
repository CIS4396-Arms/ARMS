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
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if User is logged in
            if (string.IsNullOrEmpty(Session["UserID"] as string))
            {
                //if user not logged in, redirect to Login page
                Response.Redirect("Login.aspx");
            }

            //Detect User Access Level
            //String accessNet = (Session["UserID"]).ToString();
            //int labNum = myConn.getLab(accessNet);
            //save User Lab in Session
            //Session["Lab"] = labNum;
            //if (labNum == -1)
            //{
            //    lblMisc.Text = "You are not assigned to a lab.";
            //}
            //else
            //{
            //    lblMisc.Text = "Logged in as " + Session["UserID"].ToString();
            //}

        }
    }
}