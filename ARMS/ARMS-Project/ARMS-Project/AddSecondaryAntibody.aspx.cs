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
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //  submit
        protected void btnSubmit_click(Object sender, EventArgs e)
        {
            SecondaryAntibody antibody = new SecondaryAntibody();
            antibody.color = txtColor.Text;
            antibody.concentration = txtConcentration.Text;
            antibody.labID = int.Parse(txtLabID.Text);
            if (myConn.addSecondaryAntibody(antibody))
            {
                Response.Redirect("SecondaryAntibodies.aspx");
            }
        }
    }
}