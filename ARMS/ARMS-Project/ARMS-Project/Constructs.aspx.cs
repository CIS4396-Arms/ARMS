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
    public partial class Constructs : System.Web.UI.Page
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

            constructsDataSource.TypeName = "ARMS_Project.ConstructLogic";
            constructsDataSource.SelectMethod = "GetConstructs";
            constructsDataSource.DataBind();

            alertNoResults.Visible = false;
            alertResults.Visible = false;

        }

        protected void createPDF(Stream output)
        {
            //Construct tempConstruct = myConn.getConstructByID(Convert.ToInt16(Request.QueryString["id"]));
            Construct tempConstruct = myConn.getConstructByID(2);
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=construct_" + tempConstruct.id + ".pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 72, 72, 72, 72);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            //Page title and spacing
            iTextSharp.text.Chunk pageTitle = new iTextSharp.text.Chunk("Construct Record", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20));
            document.Add(pageTitle);
            iTextSharp.text.Paragraph spacing = new iTextSharp.text.Paragraph(" ");
            document.Add(spacing);

            //Name
            iTextSharp.text.Paragraph tempParagraph = new iTextSharp.text.Paragraph();
            iTextSharp.text.Chunk tempLabel = new iTextSharp.text.Chunk("Construct Name: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            iTextSharp.text.Chunk tempValue = new iTextSharp.text.Chunk(tempConstruct.name, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Insert
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Insert: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempConstruct.insert, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Vector
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Vector: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempConstruct.vector, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Species
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Species: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempConstruct.species, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Antibiotic Resistance
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Antibiotic Resistance: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempConstruct.antibioticResistance, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //5' Digest Site
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("5' Digest Site: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempConstruct.digestSite5, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //3' Digest Site
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Working Dilution: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempConstruct.digestSite3, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Notes
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Notes: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempConstruct.notes, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            document.Close();
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
            gvConstructs.DataBind();
            if (gvConstructs.Rows.Count == 0)
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
            bool delete = myConn.deleteConstruct(id);
            if (!delete)
            {
                // Delete error
            }
            gvConstructs.DataBind();
        }

        //  Enable PDF printing
        protected void btnPrint_Click(Object sender, EventArgs e)
        {
            createPDF(new MemoryStream());
        }

        //  Save changes of object
        protected void btnSave_click(Object sender, EventArgs e)
        {
            Construct temp = new Construct();
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
            temp.digestSite5 = digestSite5;
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
            temp.digestSite3 = digestSite3;
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