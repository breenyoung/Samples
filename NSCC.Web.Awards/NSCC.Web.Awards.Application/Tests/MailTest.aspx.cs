using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NSCC.Web.AwardsApplication.Tests
{
    public partial class MailTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string body = String.Format(ConfigurationManager.AppSettings["AWARDS_EMAIL_BODY"], "Breen", "", "<br/>");

            MailMessage mailmessage = new MailMessage(
                ConfigurationManager.AppSettings["AWARDS_EMAIL_FROM"].ToString(),
                "breen@cyberplex.com",
                ConfigurationManager.AppSettings["AWARDS_EMAIL_SUBJECT"].ToString(),
                body);
            mailmessage.IsBodyHtml = true;

            // Send the message.
            SmtpClient client = new SmtpClient();

            client.Send(mailmessage);            
            
        }
    }
}