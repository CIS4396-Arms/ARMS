using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class AddSecondaryAntibody : System.Web.UI.Page
    {
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
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
            SecondaryAntibody antibody = new SecondaryAntibody();
            antibody.labID = int.Parse(txtLabID.Text);
            antibody.antibodyName = txtName.Text;
            antibody.antigen = txtAntigen.Text;
            antibody.applications = txtApplications.Text;
            antibody.concentration = txtConcentration.Text;
            antibody.excitation = txtExcitation.Text;
            antibody.flourophore = txtFlourophore.Text;
            antibody.hostSpecies = txtHostSpecies.Text;
            antibody.lotNumber = txtLotNumber.Text;
            antibody.reactiveSpecies = txtReactiveSpecies.Text;
            antibody.workingDilution = txtWorkingDilution.Text;
            if (myConn.addSecondaryAntibody(antibody))
            {
                Response.Redirect("SecondaryAntibodies.aspx");
            }
        }
    }
}