using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using System.IO;

namespace ARMS_Project
{
    public partial class view : System.Web.UI.Page
    {
        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        //  On page load
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

            ddllabID.DataSource = labsDataSource;
            ddllabID.DataTextField = "name";
            ddllabID.DataValueField = "id";
            ddllabID.DataBind();

            antibodiesDataSource.TypeName = "ARMS_Project.PrimaryAntibodyLogic";
            antibodiesDataSource.SelectMethod = "GetPrimaryAntibodies";
            antibodiesDataSource.DataBind();

            gvAntibodies.DataBind();

            alertResults.Visible = false;
            alertNoResults.Visible = false;

        }

        protected void createPDF(Stream output)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition","attachment; filename=antibody.pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
                iTextSharp.text.Rectangle page = document.PageSize;
            PdfPTable head = new PdfPTable(1);
            head.TotalWidth = page.Width;
            iTextSharp.text.Phrase phrase = new iTextSharp.text.Phrase(
              DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " GMT",
              new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8)
            );    
            PdfPCell c = new PdfPCell(phrase);
            c.Border = iTextSharp.text.Rectangle.NO_BORDER;
            c.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
            c.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            head.AddCell(c);
            head.WriteSelectedRows(
                // first/last row; -1 writes all rows
              0, -1,
                // left offset
              0,
                // ** bottom** yPos of the table
              page.Height - document.TopMargin + head.TotalHeight + 20,
              writer.DirectContent
            );
            document.Close();
        }

        //  handle protocol file upload
        protected void ProtcolUpload_Click(object sender, EventArgs e)
        {
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
                string files = txtprotocolHREF.Value + savePath + ",";
                txtprotocolHREF.Value = files;

                lblProtcolUpload.Text = "File has been successfully uploaded, you may upload another";
            }
            else
            {
                lblProtcolUpload.Text = "File upload failed.";
            }
        }


        //  Filter gridview with parameters
        protected void btnFilter_click(Object sender, EventArgs e)
        {
            antibodiesDataSource.TypeName = "ARMS_Project.PrimaryAntibodyLogic";
            antibodiesDataSource.SelectMethod = "GetPrimaryAntibodies";
            antibodiesDataSource.SelectParameters.Remove(antibodiesDataSource.SelectParameters["filter"]);
            antibodiesDataSource.SelectParameters.Remove(antibodiesDataSource.SelectParameters["keyword"]);
            antibodiesDataSource.SelectParameters.Add("filter", TypeCode.String, ddlFilter.SelectedValue.ToString());
            antibodiesDataSource.SelectParameters.Add("keyword", TypeCode.String, txtFilterKeyword.Text);
            antibodiesDataSource.DataBind();
            gvAntibodies.DataBind();
            if (gvAntibodies.Rows.Count == 0)
            {
                alertNoResults.Visible = true;
            }
            else
            {
                alertResults.Visible = true;
            }

        }

        //  Delete object
        protected void btnDelete_click(Object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Delete"]);
            bool delete = myConn.deletePrimaryAntibody(id);
            if (!delete)
            {
                // Delete error
            }
            gvAntibodies.DataBind();
        }

        //  Enable PDF printing
        protected void btnPrint_Click(Object sender, EventArgs e)
        {
            createPDF(new MemoryStream());
        }

        //  Save changes of object
        protected void btnSave_click(Object sender, EventArgs e)
        {
            PrimaryAntibody temp = new PrimaryAntibody();
            temp.id = int.Parse(txtid.Value);
            temp.antigen = txtantigen.Text;
            temp.applications = txtapplications.Text;
            temp.clone = txtclone.Text;
            temp.concentration = txtconcentration.Text;
            if (ddlfluorophore.SelectedValue != "Other")
            {
                temp.fluorophore = ddlfluorophore.SelectedValue;
            }
            else
            {
                temp.fluorophore = txtfluorophore.Text;
            }
            temp.hostSpecies = ddlhostSpecies.SelectedValue;
            temp.isotype = txtisotype.Text;
            temp.lotNumber = txtlotNumber.Text;
            temp.labID = int.Parse(ddllabID.SelectedValue);
            temp.name = txtname.Text;
            String reactiveSpecies = "";
            int i = 0;
            foreach (System.Web.UI.WebControls.ListItem li in ddlreactiveSpecies.Items)
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
            temp.reactiveSpecies = reactiveSpecies;
            temp.workingDilution = txtworkingDilution.Text;
            if (rbmonoclonal.Checked)
            {
                temp.type = "Monoclonal";
            }
            else
            {
                temp.type = "Polyclonal";
            }
            myConn.updatePrimaryAntibody(temp);
            gvAntibodies.DataBind();
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