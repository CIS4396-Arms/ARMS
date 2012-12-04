using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text.pdf;

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

            vectorsDataSource.TypeName = "ARMS_Project.VectorLogic";
            vectorsDataSource.SelectMethod = "GetVectors";
            vectorsDataSource.DataBind();

            alertNoResults.Visible = false;
            alertResults.Visible = false;
        }

        protected void createPDF(Stream output)
        {
            //Vector tempVector = myConn.getVectorByID(Convert.ToInt16(Request.QueryString["id"]));
            Vector tempVector = myConn.getVectorByID(2);
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=vector_" + tempVector.id + ".pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 72, 72, 72, 72);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            //Page title and spacing
            iTextSharp.text.Chunk pageTitle = new iTextSharp.text.Chunk("Vector Record", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20));
            document.Add(pageTitle);
            iTextSharp.text.Paragraph spacing = new iTextSharp.text.Paragraph(" ");
            document.Add(spacing);

            //Name
            iTextSharp.text.Paragraph tempParagraph = new iTextSharp.text.Paragraph();
            iTextSharp.text.Chunk tempLabel = new iTextSharp.text.Chunk("Vector Name: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            iTextSharp.text.Chunk tempValue = new iTextSharp.text.Chunk(tempVector.vectorName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Multiple Cloning Site
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Multiple Cloning Site: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempVector.multipleCloningSite, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Antibiotic Resistance
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Antibiotic Resistance: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempVector.antibioticResistance, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Vector Size
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Vector Size: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempVector.vectorSize, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Promoter
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Promoter: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempVector.promoter, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Notes
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Notes: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempVector.notes, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            document.Close();
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
            gvVectors.DataBind();
            if (gvVectors.Rows.Count == 0)
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
            bool delete = myConn.deleteVector(id);
            if (!delete)
            {
                // Delete error
            }
            gvVectors.DataBind();
        }

        //  Enable PDF printing
        protected void btnPrint_Click(Object sender, EventArgs e)
        {
            createPDF(new MemoryStream());
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