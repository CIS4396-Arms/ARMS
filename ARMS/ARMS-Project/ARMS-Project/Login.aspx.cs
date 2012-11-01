using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

using System.DirectoryServices;
using System.Configuration;
using System.Web.Security;
//using System.Web.UI.DataSourceControl;
using System.Xml;
using System.Data.SqlClient;


namespace ARMS_Project
{

    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Context.Request.Browser.Adapters.Clear();
            string strRemoteIP = null;
            string strRemoteOS = null;
            strRemoteIP = Request.ServerVariables["REMOTE_ADDR"];
            strRemoteOS = Request.ServerVariables["HTTP_USER_AGENT"];
            if ((strRemoteIP.Length) > 1)
            {
                LabelIP.Text = "IP Address Of Your Computer: " + strRemoteIP;
            }
            else
            {
                LabelIP.Text = "IP Address Of +..Your Computer: UNDETERMINED";
            }
            Page.RegisterStartupScript("SetFocus", "<script>document.getElementById('" + TextBoxUID.ClientID + "').focus();</script>");
            //Original line in VB.NET below:
            //Page.RegisterStartupScript("SetFocus", "<script>document.getElementById('" & TextBoxUID.ClientID & "').focus();</script>")
        }

        protected void ButtonLogin_Click(object sender, System.EventArgs e)
        {
            string anUser = TextBoxUID.Text;
            string apassword = TextBoxPWD.Text;
            string RetVal = null;
            switch (anUser.ToUpper())
            {
                case "GUEST":
                    RetVal = "Guest";
                    break;
                default:
                    RetVal = AuthenticateUser(anUser, apassword);
                    break;
            }
            if ((RetVal.Length) > 0)
            {
                Session["UserID"] = TextBoxUID.Text.Trim();
                Session["UserPWD"] = TextBoxPWD.Text.Trim();
                /////////////////////////CHANGE URL IF NEEDED////////
                Response.Redirect("Home.aspx", false);
                /////////////////////////CHANGE URL IF NEEDED////////
            }
            else
            {
                /////////////////////////CHANGE URL IF NEEDED///////////
                Response.Redirect("LoginFailure.aspx", false);
                /////////////////////////CHANGE URL IF NEEDED///////////
            }
        }

        public static string getDNFromLDAP(string strUID)
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://rock.temple.edu/ou=temple,dc=tu,dc=temple,dc=edu");
            entry.AuthenticationType = AuthenticationTypes.None;
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            entry.Close();
            entry.Dispose();
            mySearcher.Filter = "(sAMAccountName=" + strUID + ")";
            SearchResult result = mySearcher.FindOne();
            mySearcher.Dispose();
            int nIndex = result.Path.LastIndexOf("/");
            string strDN = result.Path.Substring((nIndex + 1)).ToString().TrimEnd();
            return strDN;
        }
        //getDNFromLDAP

        public string AuthenticateUser(string strUID, string strPassword)
        {

            string strID = string.Empty;
            DirectoryEntry entry = new DirectoryEntry();

            try
            {
                // call getDNFRromLDAP method to anonymously (port 389)
                // search against ldap for the correct DN
                string strDN = getDNFromLDAP(strUID);

                //now use the found DN for the secure bind (port 636)
                entry.Path = "LDAP://rock.temple.edu/" + strDN;
                entry.Username = strDN;
                entry.Password = strPassword;
                entry.AuthenticationType = AuthenticationTypes.SecureSocketsLayer;

                //try to fetch a property..if no errors raised then it works
                strID = entry.Properties["sAMAccountName"][0].ToString();

            }
            catch
            {

            }
            finally
            {
                entry.Close();
                entry.Dispose();
            }

            return strID;
        }
        public Login()
        {
            Load += Page_Load;
        }
    }
}