using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using NSCC.Web.AwardsApplication.Classes;

namespace NSCC.Web.AwardsApplication.Tests
{
    public partial class PdfTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PdfGenerator pdfGen = new PdfGenerator();
            pdfGen.Title = "Sample Output22";
            pdfGen.Author = "Breen Young";
            pdfGen.UrlToRetrieve = String.Format(ConfigurationManager.AppSettings["AWARDS_PDF_GENERATION_URL"].ToString(), new Guid("ec436e85-b413-4777-9e5b-146617f57a5f"), ConfigurationManager.AppSettings["AWARDS_PDF_SECRET_TOKEN"], "A2");
            pdfGen.OutputFolder = ConfigurationManager.AppSettings["AWARDS_PDF_OUTPUT_FOLDER"].ToString();
            pdfGen.AttachmentFolder = ConfigurationManager.AppSettings["AWARDS_ATTACHMENT_UPLOAD_FOLDER"].ToString();
            pdfGen.Filename = "boutput.pdf";

            //pdfGen.Attachments.Add("jpgtest.jpg");
            //pdfGen.Attachments.Add("pngtest.png");
            //pdfGen.Attachments.Add("cheatsheet.pdf");

            pdfGen.Build();

            Response.Write("Completed");

        }
    }
}