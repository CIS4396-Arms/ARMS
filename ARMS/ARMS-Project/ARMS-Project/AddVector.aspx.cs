using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class AddVector : System.Web.UI.Page
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
            }
            ObjectDataSource labsDataSource = new ObjectDataSource();
            labsDataSource.TypeName = "ARMS_Project.LabLogic";
            labsDataSource.SelectMethod = "GetLabs";

            ddlLabID.DataSource = labsDataSource;
            ddlLabID.DataTextField = "name";
            ddlLabID.DataValueField = "id";
            ddlLabID.DataBind();
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
                string files = specSheetHREF.Value + savePath + ",";
                specSheetHREF.Value = files;

                lblSpecUpload.Text = "File has been successfully uploaded, you may upload another";
            }
            else
            {
                lblSpecUpload.Text = "File upload failed.";
            }
        }

        //  submit
        protected void btnSubmit_click(Object sender, EventArgs e)
        {
            Vector vector = new Vector();
            if (ddlantibioticResistance.SelectedValue != "Other")
            {
                vector.antibioticResistance = ddlantibioticResistance.SelectedValue;
            }
            else
            {
                vector.antibioticResistance = txtantibioticResistance.Text;
            }
            vector.labID = int.Parse(ddlLabID.SelectedValue);
            vector.multipleCloningSite = txtmultipleCloningSite.Text;
            vector.notes = txtnotes.Text;
            vector.promoter = txtpromter.Text;
            vector.specSheetHREF = specSheetHREF.Value;
            vector.vectorName = txtvectorName.Text;
            vector.vectorSize = txtvectorSize.Text;
            if (myConn.addVector(vector))
            {
                Response.Redirect("Vectors.aspx");
            }
        }
    }
}