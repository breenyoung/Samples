using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSCC.Web.Awards.Managers;
using NSCC.Web.AwardsApplication.Classes;

namespace NSCC.Web.AwardsApplication.Tests
{
    public partial class FilenameTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uploadFolder = ConfigurationManager.AppSettings["AWARDS_ATTACHMENT_UPLOAD_FOLDER"];

            FilenameHelper fh = new FilenameHelper();

            string desiredFilename = "1234567-1.jpg";

            string givenFilename = fh.GetFilename(uploadFolder, desiredFilename);


            Response.Write(givenFilename);

        }
    }
}