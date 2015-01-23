using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using NSCC.Web.Awards.Classes;
using NSCC.Web.AwardsApplication.Classes;

namespace NSCC.Web.Awards.Application.Tests
{
    public partial class AppMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime now = DateTime.Now;
                tbFilename.Text = "TEST-" + now.Year + "-" + now.Month + "-" + now.Day + "-" + now.Hour + "-" + now.Minute + ".pdf";

            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string secretToken = ConfigurationManager.AppSettings["AWARDS_PDF_SECRET_TOKEN"].ToString();
            string generationUrl = ConfigurationManager.AppSettings["AWARDS_PDF_GENERATION_URL"].ToString();
            string outputFolderBase = ConfigurationManager.AppSettings["AWARDS_PDF_OUTPUT_FOLDER"].ToString();
            string attachmentFolder = ConfigurationManager.AppSettings["AWARDS_ATTACHMENT_UPLOAD_FOLDER"].ToString();

            PdfGenerator pdfGen = new PdfGenerator();
            pdfGen.Title = "Award Application: TEST MODE";
            pdfGen.Author = "NSCC";
            pdfGen.UrlToRetrieve = String.Format(generationUrl, tbSubmissionId.Text, secretToken, tbAwardCode.Text); ;
            pdfGen.AttachmentFolder = attachmentFolder;

            pdfGen.Filename = tbFilename.Text;

            pdfGen.OutputFolder = outputFolderBase;

            pdfGen.Build();

            pnlMessage.Visible = true;
        }
    }
}