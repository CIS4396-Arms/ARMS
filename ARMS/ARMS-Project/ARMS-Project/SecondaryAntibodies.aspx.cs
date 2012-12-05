using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text.pdf;

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

           secondaryAntibodiesDataSource.TypeName = "ARMS_Project.SecondaryAntibodyLogic";
           secondaryAntibodiesDataSource.SelectMethod = "GetSecondaryAntibodies";
           secondaryAntibodiesDataSource.DataBind();

           alertNoResults.Visible = false;
           alertResults.Visible = false;
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
            SecondaryAntibody temp = new SecondaryAntibody();
            temp.id = int.Parse(txtid.Value);
            temp.antibodyName = txtantibodyName.Text;
            temp.antigen = txtantigen.Text;
            temp.applications = txtapplications.Text;
            temp.concentration = txtconcentration.Text;
            temp.excitation = txtexcitation.Text;
            if (ddlfluorophore.SelectedValue != "Other")
            {
                temp.fluorophore = ddlfluorophore.SelectedValue;
            }
            else
            {
                temp.fluorophore = txtfluorophore.Text;
            }
            temp.hostSpecies = ddlhostSpecies.SelectedValue;
            temp.labID = int.Parse(ddllabID.SelectedValue);
            temp.lotNumber = txtlotNumber.Text;
            String reactiveSpecies = "";
            int i = 0;
            foreach (ListItem li in ddlreactiveSpecies.Items)
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
            myConn.updateSecondaryAntibody(temp);
            gvSecondaryAntibodies.DataBind();
        }

        //  Filter gridview with parameters
        protected void btnFilter_click(Object sender, EventArgs e)
        {
            secondaryAntibodiesDataSource.TypeName = "ARMS_Project.SecondaryAntibodyLogic";
            secondaryAntibodiesDataSource.SelectMethod = "GetSecondaryAntibodies";
            secondaryAntibodiesDataSource.SelectParameters.Remove(secondaryAntibodiesDataSource.SelectParameters["filter"]);
            secondaryAntibodiesDataSource.SelectParameters.Remove(secondaryAntibodiesDataSource.SelectParameters["keyword"]);
            secondaryAntibodiesDataSource.SelectParameters.Add("filter", TypeCode.String, ddlFilter.SelectedValue.ToString());
            secondaryAntibodiesDataSource.SelectParameters.Add("keyword", TypeCode.String, txtFilterKeyword.Text);
            secondaryAntibodiesDataSource.DataBind();
            gvSecondaryAntibodies.DataBind();
            if (gvSecondaryAntibodies.Rows.Count == 0)
            {
                alertNoResults.Visible = true;
            }
            else
            {
                alertResults.Visible = true;
            }
        }

        protected void createPDF(Stream output)
        {
            //SecondaryAntibody tempAntibody = myConn.getSecondaryAntibodyByID(Convert.ToInt16(Request.QueryString["id"]));
            SecondaryAntibody tempAntibody = myConn.getSecondaryAntibodyByID(2);
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=secondary_antibody_" + tempAntibody.id + ".pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 72, 72, 72, 72);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            //Page title and spacing
            iTextSharp.text.Chunk pageTitle = new iTextSharp.text.Chunk("Secondary Antibody Record", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20));
            document.Add(pageTitle);
            iTextSharp.text.Paragraph spacing = new iTextSharp.text.Paragraph(" ");
            document.Add(spacing);

            //Antibody Name
            iTextSharp.text.Paragraph tempParagraph = new iTextSharp.text.Paragraph();
            iTextSharp.text.Chunk tempLabel = new iTextSharp.text.Chunk("Antibody Name: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            iTextSharp.text.Chunk tempValue = new iTextSharp.text.Chunk(tempAntibody.antibodyName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Concentration
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Concentration: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.concentration, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Excitation
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Excitation: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.excitation, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Host Species
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Host Species: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.hostSpecies, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Reactive Species
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Reactive Species: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.reactiveSpecies, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Fluorophore
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Fluorophore: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.fluorophore, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Working Dilution
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Working Dilution: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.workingDilution, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Lot Number
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Lot Number: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.lotNumber, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Antigen
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Antigen: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.antigen, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            //Applications
            tempParagraph = new iTextSharp.text.Paragraph();
            tempLabel = new iTextSharp.text.Chunk("Applications: ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempValue = new iTextSharp.text.Chunk(tempAntibody.applications, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
            tempParagraph.Add(tempLabel);
            tempParagraph.Add(tempValue);
            document.Add(tempParagraph);

            document.Close();
        }

        //  Enable PDF printing
        protected void btnPrint_Click(Object sender, EventArgs e)
        {
            createPDF(new MemoryStream());
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