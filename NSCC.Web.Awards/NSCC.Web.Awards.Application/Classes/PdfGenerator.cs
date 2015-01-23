using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Configuration;

using WebSupergoo.ABCpdf9;


namespace NSCC.Web.AwardsApplication.Classes
{
    public class PdfGenerator
    {
        #region Properties

        public string Title { get; set; }
        public string Author { get; set; }
        public string Filename { get; set; }

        public string UrlToRetrieve { get; set; }
        public string OutputFolder { get; set;}
        public string AttachmentFolder { get; set; }

        public List<string> Attachments { get; set; }

        public bool ExecuteJavascript { get; set; }
        public string HtmlEngine { get; set; }

        #endregion

        public PdfGenerator()
        {
            this.Attachments = new List<string>();
            this.ExecuteJavascript = true;
            this.HtmlEngine = "MSHtml";

            XSettings.InstallLicense(ConfigurationManager.AppSettings["AWARDS_ABCPDFKEY"]);
        }

        public void Build()
        {

            EngineType engineType;
            EngineType.TryParse(this.HtmlEngine, out engineType);

            Doc document = new Doc();
            document.HtmlOptions.Engine = engineType;
            document.HtmlOptions.UseScript = this.ExecuteJavascript;
            


            //document.Rect.Inset(72, 144);

            document.SetInfo(-1, "/Info*/Author:Text", this.Author);
            document.SetInfo(-1, "/Info*/Title:Text", this.Title);            

            int pageId = document.AddImageUrl(this.UrlToRetrieve);
            while (true)
            {
                //document.FrameRect();
                if (!document.Chainable(pageId))
                {
                    break;
                }
                document.Page = document.AddPage();
                pageId = document.AddImageToChain(pageId);
            }

            for (int i = 1; i <= document.PageCount; i++)
            {
                document.PageNumber = i;
                document.Flatten();
            }

            ProcessAttachments(document);

            CheckIfDirExists(this.OutputFolder);

            document.Save(this.OutputFolder + "\\" + this.Filename);
            document.Clear();
        }

        private void CheckIfDirExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void ProcessAttachments(Doc parentDocument)
        {
            foreach (string img in this.Attachments)
            {
                Doc attachDoc = new Doc();
                attachDoc.Read(this.AttachmentFolder + "\\" + img);
                parentDocument.Append(attachDoc);
            }
        }

    }
}