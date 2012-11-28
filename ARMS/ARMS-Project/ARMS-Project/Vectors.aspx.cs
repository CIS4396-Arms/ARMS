using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class Vectors : System.Web.UI.Page
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

            ObjectDataSource labsDataSource = new ObjectDataSource();
            labsDataSource.TypeName = "ARMS_Project.LabLogic";
            labsDataSource.SelectMethod = "GetLabs";

            ddllabID.DataSource = labsDataSource;
            ddllabID.DataTextField = "name";
            ddllabID.DataValueField = "id";
            ddllabID.DataBind();

            vectorsDataSource.TypeName = "ARMS_Project.VectorLogic";
            vectorsDataSource.SelectMethod = "GetVectors";
            vectorsDataSource.DataBind();
        }

        //  handle protocol file upload
        protected void SpecUpload_Click(object sender, EventArgs e)
        {
            string saveDir = @"\Uploads\";

            // Get the physical file system path for the currently
            // executing application.
            string appPath = Request.PhysicalApplicationPath;

            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.
            if (SpecUpload.HasFile)
            {
                string savePath = appPath + saveDir +
                    Server.HtmlEncode(SpecUpload.FileName);

                SpecUpload.SaveAs(savePath);
                string files = txtspecSheetHREF.Value + savePath + ",";
                txtspecSheetHREF.Value = files;

                lblSpecUpload.Text = "File has been successfully uploaded, you may upload another";
            }
            else
            {
                lblSpecUpload.Text = "File upload failed.";
            }
        }


        //  Filter gridview with parameters
        protected void btnFilter_click(Object sender, EventArgs e)
        {
            vectorsDataSource.TypeName = "ARMS_Project.VectorLogic";
            vectorsDataSource.SelectMethod = "GetVectors";
            vectorsDataSource.SelectParameters.Remove(vectorsDataSource.SelectParameters["filter"]);
            vectorsDataSource.SelectParameters.Remove(vectorsDataSource.SelectParameters["keyword"]);
            vectorsDataSource.SelectParameters.Add("filter", TypeCode.String, ddlFilter.SelectedValue.ToString());
            vectorsDataSource.SelectParameters.Add("keyword", TypeCode.String, txtFilterKeyword.Text);
            vectorsDataSource.DataBind();
        }

        //  Delete object
        protected void btnDelete_click(Object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Delete"]);
            bool delete = myConn.deleteVector(id);
            if (!delete)
            {
                // Delete error
            }
            gvVectors.DataBind();
        }

        //  Save changes of object
        protected void btnSave_click(Object sender, EventArgs e)
        {
            Vector temp = new Vector();
            temp.id = int.Parse(txtid.Value);
            temp.labID = int.Parse(ddllabID.SelectedValue);
            if (ddlantibioticResistance.SelectedValue != "Other")
            {
                temp.antibioticResistance = ddlantibioticResistance.SelectedValue;
            }
            else
            {
                temp.antibioticResistance = txtantibioticResistance.Text;
            }
            temp.multipleCloningSite = txtmultipleCloningSite.Text;
            temp.notes = txtnotes.Text;
            temp.promoter = txtpromter.Text;
            temp.specSheetHREF = txtspecSheetHREF.Value;
            temp.vectorName = txtvectorName.Text;
            temp.vectorSize = txtvectorSize.Text;
            myConn.updateVector(temp);
            gvVectors.DataBind();
        }


        // Returns json object for ajax request
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static Vector GetVector(int id)
        {
            RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);
            return myConn.getVectorByID(id);
        }

    }
}