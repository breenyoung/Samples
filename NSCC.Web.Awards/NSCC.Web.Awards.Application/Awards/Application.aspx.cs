using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.DataAccess;
using NSCC.Web.Awards.Managers;
using System.IO;
using NSCC.Web.AwardsApplication.Classes;

using NLog;

//using AwardSelection = NSCC.Web.AwardsApplication.localhost.AwardSelection;

namespace NSCC.Web.AwardsApplication.Awards
{
    public partial class Application : System.Web.UI.Page
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPageData();
            }
        }

        private void LoadPageData()
        {
            LookupManager lookupManager = new LookupManager();
            List<Province> provinces = lookupManager.GetProvinces();

            ddlbProvince.DataTextField = "Name";
            ddlbProvince.DataValueField = "Code";
            ddlbProvince.DataSource = provinces;
            ddlbProvince.DataBind();
            ddlbProvince.SelectedValue = "NS";

            AwardManager awardManager = new AwardManager();
            List<AwardSelection> selectedAwards = awardManager.GetAwardsFromSession();

            if (selectedAwards == null || selectedAwards.Count < 1)
            {
                Response.Redirect("Default.aspx");
            }

            rpSelectedAwards.DataSource = selectedAwards;
            rpSelectedAwards.DataBind();

            litNumAwards.Text = selectedAwards.Count.ToString();

            // Configure page depending on award rules
            SetupAwardRules(selectedAwards);
        }

        protected void lbRemove_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton) sender;

            AwardManager awardManager = new AwardManager();
            awardManager.RemoveAwardFromSession(lb.CommandArgument);

            LoadPageData();
        }

        protected void rpSelectedAwards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {

                AwardSelection selection  = (AwardSelection) e.Item.DataItem;
                Literal litAwardName = (Literal) e.Item.FindControl("litAwardName");
                LinkButton lbRemove = (LinkButton) e.Item.FindControl("lbRemove");

                litAwardName.Text = selection.DisplayName;
                lbRemove.CommandArgument = selection.Code;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                logger.Debug("Starting award submission attempt");


                AwardManager awardManager = new AwardManager();
                List<AwardSelection> awards = awardManager.GetAwardsFromSession();

                // No Awards found, redirect to error page
                if (awards == null || awards.Count < 1)
                {
                    logger.Debug("[{0}] Session timed out, redirect the user to the error page", tbEmail.Text);
                    Response.Redirect("Error.aspx?E=ST");
                }

                AwardsDal dal = new AwardsDal();

                Guid newId = Guid.NewGuid();

                if (Request.UserAgent != null)
                {
                    logger.Debug("[{0}] Attempting to create database entries", newId);

                    AwardApplication aa = new AwardApplication
                        {
                            Id = newId,
                            DateSubmitted = DateTime.Now,
                            FirstName = tbFirstName.Text,
                            LastName = tbLastName.Text,
                            StudentNumber = tbStudentNumber.Text,
                            Email = tbEmail.Text,
                            Address1 = tbAddress1.Text,
                            Address2 = tbAddress2.Text,
                            City = tbCity.Text,
                            Province = ddlbProvince.SelectedValue,
                            PostalCode = tbPostalCode.Text,
                            Phone1 = tbPhone1.Text,
                            Phone2 = tbPhone2.Text,
                            Campus = hdnCampus.Value,
                            Program = hdnProgram.Value,
                            IncomePreStudy = Decimal.Parse(tbIncomePreStudy.Text),
                            IncomeFamily = Decimal.Parse(tbIncomeFamily.Text),
                            IncomeSpouse = Decimal.Parse(tbIncomeSpousePartner.Text),
                            IncomeScholarships = Decimal.Parse(tbIncomeScolarships.Text),
                            IncomeSponsorships = Decimal.Parse(tbIncomeSponsorship.Text),
                            IncomeStudentLoan = Decimal.Parse(tbIncomeStudentLoan.Text),
                            IncomeOtherLoan = Decimal.Parse(tbIncomeOtherLoan.Text),
                            IncomeSavings = Decimal.Parse(tbIncomeSavings.Text),
                            IncomeStudyPeriod = Decimal.Parse(tbIncomeStudyPeriodIncome.Text),
                            IncomeOther = Decimal.Parse(tbIncomeOtherIncome.Text),
                            IncomeTotal = Decimal.Parse(hdnTotalIncome.Value),
                            ExpenseTuition = Decimal.Parse(tbExpenseTuition.Text),
                            ExpenseHealthBenefits = Decimal.Parse(tbExpenseHealthDental.Text),
                            ExpenseStudentAssociation = Decimal.Parse(tbExpenseStudentAssociationFee.Text),
                            ExpenseUpass = Decimal.Parse(tbExpenseUPass.Text),
                            ExpenseTextbooks = Decimal.Parse(tbExpenseTextbooks.Text),
                            ExpenseParking = Decimal.Parse(tbExpenseParking.Text),
                            ExpensePortfolioSupplies = Decimal.Parse(tbExpensePortfolioSupplies.Text),
                            ExpenseGeneralSupplies = Decimal.Parse(tbExpenseGeneralSupplies.Text),
                            ExpenseTools = Decimal.Parse(tbExpenseTools.Text),
                            ExpenseSafetyCerts = Decimal.Parse(tbExpenseSafetyCertifications.Text),
                            ExpenseSafetySupplies = Decimal.Parse(tbExpenseSafetySupplies.Text),
                            ExpenseMedical = Decimal.Parse(tbExpenseMedical.Text),
                            ExpenseOther = Decimal.Parse(tbExpenseOther.Text),
                            ExpenseRentMortgage = Decimal.Parse(tbExpenseRentMortgage.Text),
                            ExpensePhone = Decimal.Parse(tbExpensePhone.Text),
                            ExpenseInternet = Decimal.Parse(tbExpenseInternet.Text),
                            ExpenseElectricity = Decimal.Parse(tbExpenseElectricity.Text),
                            ExpenseHeat = Decimal.Parse(tbExpenseHeat.Text),
                            ExpenseInsurance = Decimal.Parse(tbExpenseInsurance.Text),
                            ExpenseGroceries = Decimal.Parse(tbExpenseGrocery.Text),
                            ExpenseDebtPayments = Decimal.Parse(tbExpenseDebtPayments.Text),
                            ExpenseFamilyCare = Decimal.Parse(tbExpenseFamilyCare.Text),
                            ExpenseTransportation = Decimal.Parse(tbExpenseTransportation.Text),
                            ExpensePersonal = Decimal.Parse(tbExpensePersonal.Text),
                            ExpenseTotal = Decimal.Parse(hdnTotalExpenses.Value),
                            FinancialNeed = Decimal.Parse(hdnFinancialNeed.Value),
                            Question1 = tbQuestion1.Text,
                            Question2 = tbQuestion2.Text,
                            Question3 = tbQuestion3.Text,
                            Question4 = tbQuestion4.Text,
                            Question5 = tbQuestion5.Text,
                            Question6 = tbQuestion6.Text,
                            Question7 = tbQuestion7.Text,
                            Question8 = tbQuestion8.Text,
                            Question9 = tbQuestion9.Text,
                            Question10 = tbQuestion10.Text,
                            UserAgent = Request.UserAgent ?? String.Empty,
                            Awards = awards,
                            AcceptedTerms = true,
                            CampusName = hdnCampusName.Value,
                            ProgramName = hdnProgramName.Value
                        };

                    logger.Debug("[{0}] Attempting to validate Application object", newId);
                    var validationCtx = new ValidationContext(aa, null, null);
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(aa, validationCtx, validationResults, true);

                    if (isValid)
                    {
                        logger.Debug("[{0}] Successfully passed validation", newId);

                        dal.CreateApplication(aa);

                        logger.Debug("[{0}] Successfully created Database entries", newId);

                        // Process Attachments
                        logger.Debug("[{0}] Attempting to create file attachments", newId);
                        List<AwardAttachment> attachments = ProcessAttachments(aa.StudentNumber);
                        logger.Debug("[{0}] Successfully created file attachments", newId);

                        // Create the PDFs
                        logger.Debug("[{0}] Attempting to create PDFs", newId);
                        CreatePdfs(aa, awards, attachments);
                        logger.Debug("[{0}] Successfully created PDFs", newId);

                        // Send Email
                        try
                        {
                            logger.Debug("[{0}] Attempting to send email: {1}", newId, tbEmail.Text);
                            SendEmail(tbFirstName.Text, tbLastName.Text, tbEmail.Text, awards);
                            logger.Debug("[{0}] Successfully sent email: {1}", newId, tbEmail.Text);
                        }
                        catch (Exception ex)
                        {
                            logger.Debug("[{0}] Unable to send email: {1}", newId, tbEmail.Text);
                            // Don't show an error on email failure
                        }

                        logger.Debug("[{0}] Redirecting to success page", newId);
                        Response.Redirect("Success.aspx");
                    }
                    else
                    {
                        logger.Debug("[{0}] Fails validation, Redirecting to error page", newId);
                        Response.Redirect("Error.aspx");                        
                    }
                }                                                                           
            }
        }

        private List<AwardAttachment> ProcessAttachments(string studenNumber)
        {
            string uploadFolder = ConfigurationManager.AppSettings["AWARDS_ATTACHMENT_UPLOAD_FOLDER"];

            List<AwardAttachment> attachments = new List<AwardAttachment>();

            ContentPlaceHolder bodyContent = (ContentPlaceHolder)Page.Master.FindControl("Body");
            if (bodyContent != null)
            {
                int attachCount = 1;
                foreach (Control c in bodyContent.Controls.OfType<FileUpload>())
                {
                    FileUpload fu = (FileUpload)c;
                    if (fu.HasFile)
                    {
                        string[] fileNamePieces = fu.PostedFile.FileName.Split('.');
                        string ext = fileNamePieces[fileNamePieces.Length - 1].ToLower();
                        string desiredFileName = studenNumber + "-" + attachCount + "." + ext;
                        
                        FilenameHelper fh = new FilenameHelper();
                        string givenFilename = fh.GetFilename(uploadFolder, desiredFileName);

                        AwardAttachment a = new AwardAttachment();
                        a.AttachmentType = fu.ID.Replace("fuAttach", "");
                        a.Filename = givenFilename;
                        attachments.Add(a);

                        fu.PostedFile.SaveAs(uploadFolder + "\\" + givenFilename);

                        attachCount += 1;
                    }
                }
            }

            return attachments;
        }

        private void CreatePdfs(AwardApplication aa, List<AwardSelection> awards, List<AwardAttachment> allAttachments)
        {
            string secretToken = ConfigurationManager.AppSettings["AWARDS_PDF_SECRET_TOKEN"].ToString();
            string generationUrl = ConfigurationManager.AppSettings["AWARDS_PDF_GENERATION_URL"].ToString();
            string outputFolderBase = ConfigurationManager.AppSettings["AWARDS_PDF_OUTPUT_FOLDER"].ToString();
            string attachmentFolder = ConfigurationManager.AppSettings["AWARDS_ATTACHMENT_UPLOAD_FOLDER"].ToString();
            string folderOrganizationType = ConfigurationManager.AppSettings["AWARDS_ORGANIZATION_TYPE"].ToString();

            FilenameHelper fh = new FilenameHelper();


            string outputFolder = string.Empty;
            switch (folderOrganizationType)
            {
                case "AWARD":
                    outputFolder = outputFolderBase; // This has to be set on every award loop 
                    break;
                case "STUDENT":
                    outputFolder = outputFolderBase + "\\" + aa.StudentNumber;
                    break;
                case "DATE":
                    DateTime today = DateTime.Today;
                    outputFolder = outputFolderBase + "\\" + today.ToString("yyyy-MM-dd");
                    break;
                case "FLAT":
                    outputFolder = outputFolderBase;
                    break;
                default:
                    outputFolder = outputFolderBase;
                    break;
            }

            // Create PDFs
            foreach (AwardSelection awardSelection in awards)
            {
                PdfGenerator pdfGen = new PdfGenerator();
                pdfGen.Title = "Award Application: " + awardSelection.Code;
                pdfGen.Author = "NSCC";
                pdfGen.UrlToRetrieve = String.Format(generationUrl, aa.Id, secretToken, awardSelection.Code);
                pdfGen.AttachmentFolder = attachmentFolder;

                string desiredFilename = aa.StudentNumber + "-" + awardSelection.Code + ".pdf";
                string givenFilename = fh.GetFilename(attachmentFolder, desiredFilename);
                pdfGen.Filename = givenFilename;

                if (folderOrganizationType.Equals("AWARD")) { pdfGen.OutputFolder = outputFolder + "\\" + awardSelection.Code; }
                else { pdfGen.OutputFolder = outputFolder; }

                List<AwardAttachment> neededAttachments = awardSelection.AttachmentsRequired;
                List<string> files 
                    = (from aAttach in neededAttachments select allAttachments.SingleOrDefault(o => o.AttachmentType.Equals(aAttach.AttachmentType)) 
                           into a where a != null select a.Filename).ToList();

                pdfGen.Attachments = files;


                pdfGen.Build();
            }            
        }
        
        private void SendEmail(string firstName, string lastName, string email, List<AwardSelection> awards)
        {
            string awardList = awards.Aggregate(System.Environment.NewLine, (current, a) => current + ("- " + a.DisplayName + "<br/>" + System.Environment.NewLine));

            string body = String.Format(ConfigurationManager.AppSettings["AWARDS_EMAIL_BODY"], firstName, awardList, "<br/>");

            // Create the message
            MailMessage mailmessage = new MailMessage(
                ConfigurationManager.AppSettings["AWARDS_EMAIL_FROM"].ToString(),
                email,
                ConfigurationManager.AppSettings["AWARDS_EMAIL_SUBJECT"].ToString(),
                body);
            mailmessage.IsBodyHtml = true;

            // Send the message.
            SmtpClient client = new SmtpClient();

            client.Send(mailmessage);            
        }

        public void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return;
                output.Write(buffer, 0, read);
            }
        }

        private void SetupAwardRules(List<AwardSelection> selectedAwards)
        {

            var masterPage = Master as NSCC.Web.Awards.Application.MasterPages.AwardsApplication;

            bool hideIncomeExpenseSection = true;

            
            List<string> attachmentFieldsNeeded = new List<string>();
            List<List<string>> eligibleCampuses = new List<List<string>>();

            List<List<string>> eligiblePrograms = new List<List<string>>();

            List<string> essayQuestionsNeeded = new List<string>();

            foreach (AwardSelection selection in selectedAwards)
            {
                // Check financial info requirement
                if (selection.RequireIncomeInfo) { hideIncomeExpenseSection = false; }

                // Check attachment requirements
                foreach (AwardAttachment attach in selection.AttachmentsRequired)
                {                    
                    if (!attachmentFieldsNeeded.Contains(attach.AttachmentType))
                    {
                        attachmentFieldsNeeded.Add(attach.AttachmentType);       
                    }                    
                }    

                // Check campus requirements
                eligibleCampuses.Add(selection.EligibleCampuses);

                
                // Check program requirements
                eligiblePrograms.Add(selection.EligiblePrograms); 

                // Get Question list
                foreach (string questionCode in selection.EssayQuestions)
                {
                    if (!essayQuestionsNeeded.Contains(questionCode))
                    {
                        essayQuestionsNeeded.Add(questionCode);
                    }
                }
            }

            
            var commonCampuses = eligibleCampuses.Aggregate(new HashSet<string>(eligibleCampuses.First()), (h, e) =>
                {
                    h.IntersectWith(e);
                    return h;
                });

            //var commonCampuses = eligibleCampuses[0].Intersect(eligibleCampuses[1], new CampusComparer());

            var commonPrograms = eligiblePrograms.Aggregate(new HashSet<string>(eligiblePrograms.First()), (h, e) =>
            {
                h.IntersectWith(e);
                return h;
            });            


            // Setup JS code
            StringBuilder scriptCode = new StringBuilder();
            if (masterPage != null)
            {
                // Financial Info
                scriptCode.Append("$(document).ready(function () {");
                if (hideIncomeExpenseSection)
                {
                    scriptCode.Append("NsccAwardApplication.hideFinancialInfo();");
                }

                // Attachments
                scriptCode.Append("NsccAwardApplication.showAttachments([");
                string attachElems = string.Empty;
                foreach (string s in attachmentFieldsNeeded) { attachElems += "'#tr" + s + "',"; }
                scriptCode.Append(attachElems.TrimEnd(",".ToCharArray()));
                scriptCode.Append("]);");
                
                // Campuses
                scriptCode.Append("NsccAwardApplication.addCampusValidator([");
                string campusCodes = string.Empty;
                foreach (string c in commonCampuses) { campusCodes += "'" + c + "',"; }
                scriptCode.Append(campusCodes.TrimEnd(",".ToCharArray()));
                scriptCode.Append("]);");

                // Programs
                scriptCode.Append("NsccAwardApplication.addProgramValidator([");
                string programCodes = string.Empty;
                foreach (string p in commonPrograms) { programCodes += "'" + p + "',"; }
                scriptCode.Append(programCodes.TrimEnd(",".ToCharArray()));
                scriptCode.Append("]);");

                // Questions
                scriptCode.Append("NsccAwardApplication.showQuestions([");
                string questionCodes = string.Empty;
                foreach (string q in essayQuestionsNeeded) { questionCodes += "'#trQUESTION" + q + "',"; }
                scriptCode.Append(questionCodes.TrimEnd(",".ToCharArray()));
                scriptCode.Append("]);");                

                // Script close
                scriptCode.Append("});");

                // Inject in page
                masterPage.Page.ClientScript.RegisterStartupScript(this.GetType(), "AwardsScript", scriptCode.ToString(), true);
            }                

        }
    }

}