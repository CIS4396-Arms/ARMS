using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class AddVector : System.Web.UI.Page
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////Check if User is logged in
                //if (string.IsNullOrEmpty(Session["UserID"] as string))
                //{
                //    //if user not logged in, redirect to Login page
                //    Response.Redirect("Login.aspx");
                //}
            }
        }

        //  submit
        protected void btnSubmit_click(Object sender, EventArgs e)
        {
            Vector vector = new Vector();
            vector.ARS = txtARS.Text;
            vector.MCS = txtMCS.Text;
            vector.promoter = txtPromter.Text;
            vector.sizeVP = txtSizeVP.Text;
            if (myConn.addVector(vector))
            {
                Response.Redirect("Vectors.aspx");
            }
        }
    }
}