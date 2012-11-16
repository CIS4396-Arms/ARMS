using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class AddAntibody : System.Web.UI.Page
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
            PrimaryAntibody antibody = new PrimaryAntibody();
            antibody.labID = int.Parse(txtLabID.Text);
            antibody.lotNumber = txtLotNumber.Text;
            antibody.enzymeName = txtEnzymeName.Text;
            antibody.solution = txtSolution.Text;
            antibody.clone = txtClone.Text;
            antibody.hostSpecies = txtHostSpecies.Text;
            antibody.format = txtFormat.Text;
            antibody.reactiveSpecies = txtFormat.Text;
            antibody.concentration = txtConcentration.Text;
            antibody.workingDilution = txtWorkingDilution.Text;
            antibody.antigen = txtAntigen.Text;
            antibody.phlourosphore = txtPhlourosphore.Text;
            antibody.protocolHREF = txtProtcolHref.Text;
            if (myConn.addPrimaryAntibody(antibody))
            {
                Response.Redirect("Antibodies.aspx");
            }
        }
    }
}