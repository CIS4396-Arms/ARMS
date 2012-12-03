using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project.assets
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Logout"]))
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

            /*if (!IsPostBack)
            {
               //Check if User is logged in
                if (string.IsNullOrEmpty(Session["UserID"] as string))
                {

                }
            }*/
        }

       /* protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Check if User is logged in
            if (!(string.IsNullOrEmpty(Session["UserID"] as string)))
            {
                //if empty, drop session
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }*/
    }
}