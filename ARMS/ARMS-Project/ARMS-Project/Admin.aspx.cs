using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace ARMS_Project
{
    public partial class Admin : System.Web.UI.Page
    {

        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Check if User is logged in
                if (string.IsNullOrEmpty(Session["UserID"] as string))
                {
                    //if user not logged in, redirect to Login page
                    Response.Redirect("Login.aspx");
                }

                List<Lab> tempLabs = new List<Lab>();
                tempLabs = myConn.getAllLabs().Cast<Lab>().ToList();
                ddlLabs.DataSource = tempLabs;
                ddlLabs.DataTextField = "name";
                ddlLabs.DataValueField = "id";
                ddlLabs.DataBind();

            }
        }

        protected void btnCreateLab_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLabName.Text) || txtLabName.Text.Equals("Required field"))
            {
                txtLabName.Text = "Required field";
                txtLabName.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (myConn.addLab(new Lab(txtLabName.Text)))
                {
                    txtLabName.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void txtLabName_TextChanged(object sender, EventArgs e)
        {
            txtLabName.ForeColor = System.Drawing.Color.Black;
        }

        protected void btnAddUserToLab_Click(object sender, EventArgs e)
        {
            myConn.addUser(new User(txtUserName.Text, Convert.ToInt16(ddlLabs.SelectedValue), txtFullName.Text));
        }
    }
}