using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARMS_Project
{
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dbConnTestBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ARMSDBConnection myConn = new ARMSDBConnection("tuc42419", "nei2neiB", "cis-iis2.temple.edu/Fall2012", "FA12_434218");
                dbConnTestLBL.Text = "I guess it worked!";
            }
            catch (Exception ex)
            {
                dbConnTestLBL.Text = "Oops, didn't work.\n"+ex.ToString();
            }
        }
    }
}