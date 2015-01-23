using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.DataAccess;
using NSCC.Web.Awards.Search.Classes;


namespace NSCC.Web.Awards.Search
{
    public partial class Detail : System.Web.UI.Page
    {
        protected string Deadline;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["I"]))
                {
                    GetAwardDetails(Request.QueryString["I"].ToString());
                }
            }
        }

        protected void rpAttachments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                string text = (string) e.Item.DataItem;
                Literal litAttachment = (Literal) e.Item.FindControl("litAttachment");

                litAttachment.Text = text;
            }
        }

        protected void rpEssayQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                EssayQuestion es = (EssayQuestion) e.Item.DataItem;
                Literal litEssayQuestion = (Literal) e.Item.FindControl("litEssayQuestion");

                litEssayQuestion.Text = es.Description;
            }
        }

        private void GetAwardDetails(string code)
        {
            AwardsSearchDal searchDal = new AwardsSearchDal();
            CommonDal commonDal = new CommonDal();

            AwardSelection award = searchDal.GetAwardDetail(code);
            if (award != null)
            {

                Page.Header.Title = String.Format(Page.Header.Title, award.DisplayName);
                litCrumbAwardName.Text = award.DisplayName;
                litTitle.Text = award.DisplayName;
                litDesc.Text = award.Description;
                litAmount.Text = "$" + award.Amount;
                litAcademicLoad.Text = award.AcademicLoad.Equals("All") ? "Full-time/Part-time": award.AcademicLoad;
                
                litNumAwards.Text = award.NumberOfAwards.ToString();
                litAwardType.Text = (award.NumberOfAwards > 1 ? award.PlurilizeAwardType() : award.AwardType);

                if (award.RequireIncomeInfo) { htmlGenericFinancialInfo.Visible = true; }


                if (award.Deadline != null) { Deadline = award.Deadline.ToString("MMMM dd, yyyy"); }

                if (award.HasProgramRestrictions)
                {
                    string programList = string.Empty;
                    for (int i = 0; i < award.EligibleProgramNames.Count; i++)
                    {
                        if ((i + 1) == award.EligibleProgramNames.Count && award.EligibleProgramNames.Count != 1)
                        {
                            programList = programList.TrimEnd(", ".ToCharArray());
                            programList += " or ";
                        }
                        programList += award.EligibleProgramNames[i] + ", ";
                    }
                    litPrograms.Text = programList.TrimEnd(", ".ToCharArray());
                    
                    liProgramRestrictions.Visible = true;
                }
                else
                {
                    liNoProgramRestriction.Visible = true;
                }

                if (award.SpecialCriteria.Any())
                {
                    liSpecialCriteria.Visible = true;
               
                    litSpecialCriteriaList.Text = award.GetFormattedSpecialCriteria();

                }

                /*
                if (award.SpecialCriteria.Count > 0)
                {
                    litSpecialCriteriaHeader.Visible = true;
                    string specialCriteria = string.Empty;
                    foreach (string s in award.SpecialCriteria)
                    {
                        specialCriteria += s + ", ";
                    }
                    specialCriteria = specialCriteria.TrimEnd(", ".ToCharArray());

                    litSpecialCriteria.Text = specialCriteria;
                    litSpecialCriteria.Visible = true;
                }
                */

                if (award.RequireIncomeInfo)
                {                    
                }
               
                litSummary.Text = award.GetSummary();

                if (!String.IsNullOrEmpty(award.OtherCriteria))
                {
                    litOtherCriteria.Text = award.OtherCriteria;
                    genericAssessmentCriteriaHeader.Visible = true;
                    litOtherCriteria.Visible = true;
                }
                
                if (award.NumberOfAttachments > 0)
                {
                    List<string> attachmentBulletPoints = new List<string>();

                    var qCount = award.AttachmentsRequired.Count(at => at.AttachmentType.StartsWith("REFQUESTION"));
                    if (qCount > 0)
                    {


                        StringBuilder referenceQuestionnaireStringBuilder = new StringBuilder();
                        referenceQuestionnaireStringBuilder.Append(
                            String.Format(
                                System.Configuration.ConfigurationManager.AppSettings[
                                    "AWARDS_REQUIRE_REFERENCE_QUESTIONNAIRE"], qCount));

                        foreach (var item in award.QuestionnaireTypes)
                        {

                            string subValue = string.Empty;
                            string subValue2 = string.Empty;
                            if (qCount == 2 && award.QuestionnaireTypes.Count() == 1)
                            {
                                subValue = "Both";
                                subValue2 = "s";
                            }
                            else if (qCount == 2 && award.QuestionnaireTypes.Count() > 1)
                            {
                                subValue = "1";
                            }

                            referenceQuestionnaireStringBuilder.Append(
                            String.Format(
                                System.Configuration.ConfigurationManager.AppSettings["AWARDS_REQUIRE_REFERENCE_QUESTIONNAIRE_" + item], subValue, subValue2));
                        }
                        attachmentBulletPoints.Add(referenceQuestionnaireStringBuilder.ToString());
                        
                    }

                

                    if (award.AttachmentsRequired.FirstOrDefault(at => at.AttachmentType.StartsWith("REFLETTER")) != null)
                    {
                        StringBuilder referenceLetterBuilder = new StringBuilder();
                        referenceLetterBuilder.Append(System.Configuration.ConfigurationManager.AppSettings["AWARDS_REQUIRE_REFERENCE_LETTER"]);

                        var refLetter =
                            award.AttachmentsRequired.FirstOrDefault(at => at.AttachmentType.StartsWith("REFLETTER"));

                        referenceLetterBuilder.Append(
                            System.Configuration.ConfigurationManager.AppSettings["AWARDS_REQUIRE_REFERENCE_LETTER_" + refLetter.AttachmentType]);

                        attachmentBulletPoints.Add(referenceLetterBuilder.ToString());
                    }

                    if (award.AttachmentsRequired.FirstOrDefault(at => at.AttachmentType.Equals("HIGHSCHOOLTRANSCRIPT")) != null)
                    {
                        attachmentBulletPoints.Add(System.Configuration.ConfigurationManager.AppSettings["AWARDS_REQUIRE_HIGHSCHOOL_TRANSCRIPT"]);
                    }

                    rpAttachments.DataSource = attachmentBulletPoints;
                    rpAttachments.DataBind();
                }

                if (award.EssayQuestions.Count > 0)
                {
                    List<EssayQuestion> essayQuestions =
                        commonDal.GetEssayQuestionInRange(award.EssayQuestions.Select(x => int.Parse(x)).ToArray());
                    rpEssayQuestions.DataSource = essayQuestions;
                    rpEssayQuestions.DataBind();

                }               

                if (!String.IsNullOrEmpty(award.LogoFile))
                {                    
                    imgDonationLogo.ImageUrl = String.Format(imgDonationLogo.ImageUrl, award.LogoFile);
                    imgDonationLogo.Visible = true;
                    pDonatedIntro.Visible = true;
                }

                litStandardPayment.Text = award.StandardPayment ? System.Configuration.ConfigurationManager.AppSettings["AWARDS_STANDARD_PAYMENT_DESC"] : award.OtherInfo;


                // replace 
                string extraCriteria = Regex.Replace(Regex.Replace(award.ExtraCriteria, "</?div[^<]*?>", string.Empty),
                                                 "</?span[^<]*?>", string.Empty);
                if (!string.IsNullOrEmpty(HtmlUtils.HtmlStrip(extraCriteria)))
                {
                    litExtraCriteria.Text = award.ExtraCriteria;
                    litExtraCriteria.Visible = true;
                    htmlGenericExtraCriteria.Visible = true;
                }

                //


//                if (!String.IsNullOrEmpty(award.ExtraCriteria))
//                {
//                    litExtraCriteria.Text = award.ExtraCriteria;
//                    litExtraCriteria.Visible = true;
//                    htmlGenericExtraCriteria.Visible = true;
//                }

            }
            else
            {
                // Invalid or expired award, redirect to search page
                Response.Redirect("Default.aspx");
            }
        }
    }
}