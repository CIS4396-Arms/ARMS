using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class AddConstruct : System.Web.UI.Page
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
                ObjectDataSource labsDataSource = new ObjectDataSource();
                labsDataSource.TypeName = "ARMS_Project.LabLogic";
                labsDataSource.SelectMethod = "GetLabs";

                ddlLabID.DataSource = labsDataSource;
                ddlLabID.DataTextField = "name";
                ddlLabID.DataValueField = "id";
                ddlLabID.DataBind();
            }
            
        }

        //  submit
        protected void btnSubmit_click(Object sender, EventArgs e)
        {
            Construct construct = new Construct();
            construct.name = txtname.Text;
            construct.labID = int.Parse(ddlLabID.SelectedValue);
            construct.insert = txtinsert.Text;
            construct.species = txtSpecies.Text;
            construct.vector = txtvector.Text;
            if (ddlantibioticResistance.SelectedValue != "Other")
            {
                construct.antibioticResistance = ddlantibioticResistance.SelectedValue;
            }
            else
            {
                construct.antibioticResistance = txtantibioticResistance.Text;
            }
            String digestSite5 = "";
            int i = 0;
            foreach (ListItem li in ddldigestSite5.Items)
            {
                if (li.Selected == true)
                {
                    if (i > 0)
                    {
                        digestSite5 += ",";
                    }
                    digestSite5 += li.Value;
                    i++;
                }
            }
            construct.digestSite5 = digestSite5;
            String digestSite3 = "";
            i = 0;
            foreach (ListItem li in ddldigestSite3.Items)
            {
                if (li.Selected == true)
                {
                    if (i > 0)
                    {
                        digestSite3 += ",";
                    }
                    digestSite3 += li.Value;
                    i++;
                }
            }
            construct.digestSite3 = digestSite3;
            if (myConn.addConstruct(construct))
            {
                Response.Redirect("Constructs.aspx");
            }
        }
    }
}