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

            antibodiesDataSource.TypeName = "ARMS_Project.PrimaryAntibodyLogic";
            antibodiesDataSource.SelectMethod = "GetPrimaryAntibodies";
            antibodiesDataSource.DataBind();
        }

        protected void btnFilter_click(Object sender, EventArgs e)
        {
            antibodiesDataSource.SelectParameters.Add("@filter", TypeCode.String, ddlFilter.SelectedValue.ToString());
            antibodiesDataSource.SelectParameters.Add("@keyword", TypeCode.String, txtFilterKeyword.Text);
            antibodiesDataSource.DataBind();

            gvAntibodies.DataBind();
        }

        //  save edits
        protected void btnSave_click(Object sender, EventArgs e)
        {
            Console.WriteLine("function called broseph");
            // call edit antibody function
        }

        // Returns json object for ajax request
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static PrimaryAntibody GetAntibody(int id)
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return myConn.getPrimaryAntibodyByID(id);
        }

    }
}