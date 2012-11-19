using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class Constructs : System.Web.UI.Page
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
            constructsDataSource.TypeName = "ARMS_Project.ConstructLogic";
            constructsDataSource.SelectMethod = "GetConstructs";
            constructsDataSource.DataBind();
        }

        //  Filter gridview with parameters
        protected void btnFilter_click(Object sender, EventArgs e)
        {
            constructsDataSource.TypeName = "ARMS_Project.ConstructLogic";
            constructsDataSource.SelectMethod = "GetConstructs";
            constructsDataSource.SelectParameters.Remove(constructsDataSource.SelectParameters["filter"]);
            constructsDataSource.SelectParameters.Remove(constructsDataSource.SelectParameters["keyword"]);
            constructsDataSource.SelectParameters.Add("filter", TypeCode.String, ddlFilter.SelectedValue.ToString());
            constructsDataSource.SelectParameters.Add("keyword", TypeCode.String, txtFilterKeyword.Text);
            constructsDataSource.DataBind();
        }

        //  Delete object
        protected void btnDelete_click(Object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Delete"]);
            bool delete = myConn.deleteConstruct(id);
            if (!delete)
            {
                // Delete error
            }
            gvConstructs.DataBind();
        }

        //  Save changes of object
        protected void btnSave_click(Object sender, EventArgs e)
        {
            Construct temp = new Construct();
            temp.id = int.Parse(txtid.Value);
            temp.labID = int.Parse(txtlabID.Text);
            temp.antibioticResistance = txtantibioticResistance.Text;
            temp.digestSite3 = txtdigestSite3.Text;
            temp.digestSite5 = txtdigestSite5.Text;
            temp.insert = txtinsert.Text;
            temp.name = txtname.Text;
            temp.notes = txtnotes.Text;
            temp.species = txtspecies.Text;
            temp.vector = txtvector.Text;
            myConn.updateConstruct(temp);
            gvConstructs.DataBind();
        }

        // Returns json object for ajax request
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static Construct GetConstruct(int id)
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return myConn.getConstructByID(id);
        }

    }
}