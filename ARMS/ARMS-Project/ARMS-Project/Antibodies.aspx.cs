﻿using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class view : System.Web.UI.Page
    {
        ARMSDBConnection myConn;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void dbConnTestBTN_Click(object sender, EventArgs e)
        {
            try
            {
                myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUsername"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
                //PrimaryAntibody myAB = new PrimaryAntibody();
                ArrayList datArray = myConn.getAllVectors();
                foreach (Vector temp in datArray)
                    dbConnTestLBL.Text += "<br />" + temp.toString();
            }
            catch (Exception ex)
            {
                dbConnTestLBL.Text = "Oops, didn't work.\n"+ex.ToString();
            }
        }
    }
}