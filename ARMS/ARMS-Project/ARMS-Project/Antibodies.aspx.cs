using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class view : System.Web.UI.Page
    {
        ARMSDBConnection myConn = new ARMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        //  On page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAntibodies();
            }
        }

        //  DataBinds ArrayList to GridView on Antibodies.aspx
        protected void ShowAntibodies()
        {
            gvAntibodies.DataSource = myConn.getAllPrimaryAntibodies();
            gvAntibodies.DataBind();
        }

        // DataBinds Antibody to FormView
        [WebMethod]
        public ArrayList GetAntibody()
        {
            Console.WriteLine("I'm in here bro");
            return myConn.getAllPrimaryAntibodies();
        }

    }
}