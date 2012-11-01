using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class SecondaryAntibodies : System.Web.UI.Page
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        //  On page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAntibodies();
             
                    ////Check if User is logged in
                    //if (string.IsNullOrEmpty(Session["UserID"] as string))
                    //{
                    //    //if user not logged in, redirect to Login page
                    //    Response.Redirect("Login.aspx");
                    //}

            }
        }

        //  DataBinds ArrayList to GridView on Antibodies.aspx
        protected void ShowAntibodies()
        {
            gvSecondaryAntibodies.DataSource = myConn.getAllSecondaryAntibodies();
            gvSecondaryAntibodies.DataBind();
        }

        //  Delete button click
        protected void Delete_Click()
        {
            
        }

    }
}