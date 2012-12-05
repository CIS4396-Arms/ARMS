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
using System.Net.Mail;


namespace ARMS_Project
{

    public partial class Login : System.Web.UI.Page
    {

        RMSDBConnection myConn = new RMSDBConnection(System.Configuration.ConfigurationManager.AppSettings["dbUserName"], System.Configuration.ConfigurationManager.AppSettings["dbPassword"], System.Configuration.ConfigurationManager.AppSettings["dbServer"], System.Configuration.ConfigurationManager.AppSettings["database"]);

        public void ButtonLogin_Click(object sender, EventArgs e)
        {
            int answer;
            Boolean success;
            if (ButtonLogin.Text == "Submit")
            {
                if (txtNewPass1.Text == txtNewPass2.Text)
                    if (injectionPass(txtNewPass1.Text))
                        if (injectionPass(txtNewPass2.Text))
                        {
                            success = myConn.updatePassword(txtNewPass1.Text, TextBoxUID.Text);
                            if (success == true)
                                redirect(1);
                            else
                            {
                                LabelIP.Visible = true;
                                LabelIP.Text = "Unable to update password.";
                            }
                        }
                        else
                        {
                            LabelIP.Visible = true;
                            LabelIP.Text = "Please do not use the the following characters: ; ' - _ / *";
                        }
                    else
                    {
                        LabelIP.Visible = true;
                        LabelIP.Text = "Please do not use the the following characters: ; ' - _ / *";
                    }
                else
                {
                    LabelIP.Visible = true;
                    LabelIP.Text = "Passwords are not the same";
                }
            }
            else
            {
                if (TextBoxPWD.Text != "")
                {
                    LabelIP.Visible = false;
                    if (TextBoxUID.Text != "")
                    {
                        LabelIP.Visible = false;
                        if (injectionPass(TextBoxPWD.Text))
                        {
                            LabelIP.Visible = false;
                            if (injectionPass(TextBoxUID.Text))
                            {
                                LabelIP.Visible = false;
                                answer = myConn.CheckLogin(TextBoxUID.Text, TextBoxPWD.Text);
                                redirect(answer);
                            }
                            else
                            {
                                LabelIP.Visible = true;
                                LabelIP.Text = "Please do not use the the following characters: ; ' - _ / *";
                            }
                        }
                        else
                        {
                            LabelIP.Visible = true;
                            LabelIP.Text = "Please do not use the the following characters: ; ' - _ / *";
                        }
                    }
                    else
                    {
                        LabelIP.Visible = true;
                        LabelIP.Text = "Please enter username";
                    }
                }
                else
                {
                    LabelIP.Visible = true;
                    LabelIP.Text = "Please enter password";
                }

            }
        }

        public Boolean injectionPass(String utext)
        {
            if (!(utext.Contains(';')))
                if (!(utext.Contains("'")))
                    if (!(utext.Contains("--")))
                        if (!(utext.Contains("/*")))
                            if (!(utext.Contains("*/")))
                                if (!(utext.Contains("xp_")))
                                    return true;
                                else
                                    return false;
                            else
                                return false;
                        else
                            return false;
                    else
                        return false;
                else
                    return false;
            else
                return false;
        }

        public void redirect(int answer)
        {
            if (answer==1)
            {
                Session["UserID"] = TextBoxUID.Text;
                Session["Lab"] = myConn.getLab(TextBoxUID.Text);
                Response.Redirect("Antibodies.aspx");
            }
            else
            {
                if (answer==-1)
                {
                    LabelIP.Visible=true;
                    LabelIP.Text="Invalid username and password";
                }
                else
                {
                    lblNewPass1.Visible = true;
                    lblNewPass2.Visible = true;
                    txtNewPass1.Visible = true;
                    txtNewPass2.Visible = true;
                    ButtonLogin.Text = "Submit";
                    TextBoxPWD.Enabled = false;
                    TextBoxUID.Enabled = false;
                }
            }       
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            if (myConn.UserExists(TextBoxUID.Text))
            {
                String email =myConn.GetUserEmail(TextBoxUID.Text);
                String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random random = new Random();
                String result = "TEMP" + new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                Boolean success = myConn.updatePassword(result, TextBoxUID.Text);
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("RMS.donotreply@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "RMS User Credentials";
                    mail.Body = "Dear RMS User,\n\nYour new password is " + result + " - please use it to log in to the system.  You will be prompted to change your password upon log in.\n\nSincerely,\nRMS Admin Team";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("RMS.donotreply@gmail.com", "rmsadmin12");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    //lblForgotPassword.Text += ex.ToString();
                }
                lblForgotPassword.Text = "Your password has been reset and been sent to the email address associated with the provided username.";
                lblForgotPassword.Visible = true;
            }
            else
            {
                lblForgotPassword.Text = "The username provided was not found.  Please try again.  If you forgot your username, please contact the system administrator.";
                lblForgotPassword.Visible = true;
            }
        }
    }
}