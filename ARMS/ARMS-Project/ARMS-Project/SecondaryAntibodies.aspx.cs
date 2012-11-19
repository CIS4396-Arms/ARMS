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
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        //  On page load
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
           secondaryAntibodiesDataSource.TypeName = "ARMS_Project.SecondaryAntibodyLogic";
           secondaryAntibodiesDataSource.SelectMethod = "GetSecondaryAntibodies";
           secondaryAntibodiesDataSource.DataBind();
        }

        //  Delete object
        protected void btnDelete_click(Object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Delete"]);
            bool delete = myConn.deleteSecondaryAntibody(id);
            if (!delete)
            {
                // Delete error
            }
            gvSecondaryAntibodies.DataBind();
        }

        //  Save changes of object
        protected void btnSave_click(Object sender, EventArgs e)
        {
            Console.WriteLine("function called broseph");
            // call edit antibody function
        }

        // Returns json object for ajax request
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static SecondaryAntibody GetAntibody(int id)
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return myConn.getSecondaryAntibodyByID(id);
        }

    }
}