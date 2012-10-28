﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class Constructs : System.Web.UI.Page
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        //  On page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowConstructs();
            }
        }

        //  DataBinds ArrayList to GridView on Antibodies.aspx
        protected void ShowConstructs()
        {
            gvConstructs.DataSource = myConn.getAllConstructs();
            gvConstructs.DataBind();
        }
    }
}