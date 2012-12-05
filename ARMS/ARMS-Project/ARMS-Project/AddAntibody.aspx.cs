using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Amazon.S3;

namespace ARMS_Project
{
    public partial class AddAntibody : System.Web.UI.Page
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
                   //Response.Redirect("Login.aspx");
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
        protected void ProtcolUpload_Click(object sender, EventArgs e)
        {


            string filePath = HelperMethods.UploadToS3(ProtcolUpload.FileName, ProtcolUpload.FileContent);

            string saveDir = @"\Uploads\";

            // Get the physical file system path for the currently
            // executing application.
            string appPath = Request.PhysicalApplicationPath;

            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.
            if (ProtcolUpload.HasFile)
            {
                string savePath = appPath + saveDir +
                    Server.HtmlEncode(ProtcolUpload.FileName);

                ProtcolUpload.SaveAs(savePath);
                string files = protocolHREF.Value + savePath + ",";
                protocolHREF.Value = files;

                lblProtcolUpload.Text = "File has been successfully uploaded, you may upload another";
            }
            else
            {
                lblProtcolUpload.Text = "File upload failed.";
            }
        }

        //  submit
        protected void btnSubmit_click(Object sender, EventArgs e)
        {
            PrimaryAntibody antibody = new PrimaryAntibody();
            antibody.labID = int.Parse(ddlLabID.SelectedValue);
            antibody.lotNumber = txtLotNumber.Text;
            antibody.name = txtName.Text;
            antibody.clone = txtClone.Text;
            if (rbMono.Checked)
            {
                antibody.type = "Monoclonal";
            }
            else
            {
                antibody.type = "Polyclonal";
            }
            antibody.hostSpecies = ddlHostSpecies.SelectedValue;
            String reactiveSpecies = "";
            int i = 0;
            foreach (ListItem li in ddlReactiveSpecies.Items)
            {  
                if (li.Selected == true)
                {
                    if (i > 0)
                    {
                        reactiveSpecies += ",";
                    }
                    reactiveSpecies += li.Value;
                    i++;
                }
            }
            antibody.reactiveSpecies = reactiveSpecies;
            antibody.concentration = txtConcentration.Text;
            antibody.workingDilution = txtWorkingDilution.Text;
            antibody.isotype = txtIsotype.Text;
            antibody.antigen = txtAntigen.Text;
            antibody.applications = txtApplication.Text;
            if (ddlFluorophore.SelectedValue != "Other")
            {
                antibody.fluorophore = ddlFluorophore.SelectedValue;
            }
            else
            {
                antibody.fluorophore = fluorophoreOther.Text;
            }
            antibody.protocolHREF = protocolHREF.Value;
            if (myConn.addPrimaryAntibody(antibody))
            {
                Response.Redirect("Antibodies.aspx");
            }
        }
    }
}