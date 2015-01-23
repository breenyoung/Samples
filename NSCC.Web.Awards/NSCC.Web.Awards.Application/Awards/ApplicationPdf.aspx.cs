using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.DataAccess;
using NSCC.Web.Awards.Managers;

namespace NSCC.Web.AwardsApplication.Awards
{
    public partial class ApplicationPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string secretToken = ConfigurationManager.AppSettings["AWARDS_PDF_SECRET_TOKEN"];

            bool canProceed = false;
            Guid id = new Guid();
            string awardCode = string.Empty;

            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["I"])
                    && !String.IsNullOrEmpty(Request.QueryString["A"])
                    && !String.IsNullOrEmpty(Request.QueryString["T"])
                    && Request.QueryString["T"] == secretToken)
                {
                    try
                    {
                        id = Guid.Parse(Request.QueryString["I"]);
                        awardCode = Request.QueryString["A"];
                        canProceed = true;
                    }
                    catch (Exception ex) { }
                }

                if (canProceed)
                {
                    AwardsDal dal = new AwardsDal();
                    AwardApplication application = dal.GetApplication(id);
                    if (application != null)
                    {
                        bool debugMode = Boolean.Parse(ConfigurationManager.AppSettings["AWARDS_DEBUG_MODE"]);
                        bool directDataAccess = Boolean.Parse(ConfigurationManager.AppSettings["AWARDS_DIRECT_DATA_ACCESS"]);

                        AwardManager awardManager = new AwardManager();
                        AwardSelection award = awardManager.GetAwardById(awardCode, debugMode, directDataAccess);                                                
                        LoadPageData(application, award);
                    }                    
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                
            }
        }

        private void LoadPageData(AwardApplication application, AwardSelection award)
        {

            litAwardName.Text = award.DisplayName;

            litFirstName.Text = application.FirstName;
            litLastName.Text = application.LastName;
            litStudentNumber.Text = application.StudentNumber;
            litEmail.Text = application.Email;
            litAddress1.Text = application.Address1;
            litAddress2.Text = application.Address2;
            litCity.Text = application.City;

            LookupManager lookupManager = new LookupManager();
            litProvince.Text = lookupManager.GetProvinceByCode(application.Province).Name;

            litPostalCode.Text = application.PostalCode;
            litPhone1.Text = application.Phone1;
            litPhone2.Text = application.Phone2;
            litCampus.Text = application.CampusName;
            litProgram.Text = application.ProgramName;

            // Income
            litIncomePreStudy.Text = application.IncomePreStudy.ToString();
            litIncomeFamily.Text = application.IncomeFamily.ToString();
            litIncomeSpousePartner.Text = application.IncomeSpouse.ToString();
            litIncomeScolarships.Text = application.IncomeScholarships.ToString();
            litIncomeSponsorship.Text = application.IncomeSponsorships.ToString();
            litIncomeStudentLoan.Text = application.IncomeStudentLoan.ToString();
            litIncomeOtherLoan.Text = application.IncomeOtherLoan.ToString();
            litIncomeSavings.Text = application.IncomeSavings.ToString();
            litIncomeStudyPeriodIncome.Text = application.IncomeStudyPeriod.ToString();
            litIncomeOtherIncome.Text = application.IncomeOther.ToString();

            // Total income
            litTotalIncome.Text = application.IncomeTotal.ToString();

            // Expenses
            litExpenseTuition.Text = application.ExpenseTuition.ToString();
            litExpenseHealthDental.Text = application.ExpenseHealthBenefits.ToString();
            litExpenseStudentAssociationFee.Text = application.ExpenseStudentAssociation.ToString();
            litExpenseUPass.Text = application.ExpenseUpass.ToString();
            litExpenseTextbooks.Text = application.ExpenseTextbooks.ToString();
            litExpenseParking.Text = application.ExpenseParking.ToString();
            litExpensePortfolioSupplies.Text = application.ExpensePortfolioSupplies.ToString();
            litExpenseGeneralSupplies.Text = application.ExpenseGeneralSupplies.ToString();
            litExpenseTools.Text = application.ExpenseTools.ToString();
            litExpenseSafetyCertifications.Text = application.ExpenseSafetyCerts.ToString();
            litExpenseSafetySupplies.Text = application.ExpenseSafetySupplies.ToString();
            litExpenseMedical.Text = application.ExpenseMedical.ToString();
            litExpenseOther.Text = application.ExpenseOther.ToString();

            // Expenses with multiplication
            litExpenseRentMortgage.Text = application.ExpenseRentMortgage.ToString();
            litExpenseRentMortgageMultiply.Text = (application.ExpenseRentMortgage * 10).ToString();
            litExpensePhone.Text = application.ExpensePhone.ToString();
            litExpensePhoneMultiply.Text = (application.ExpensePhone * 10).ToString();
            litExpenseInternet.Text = application.ExpenseInternet.ToString();
            litExpenseInternetMultiply.Text = (application.ExpenseInternet * 10).ToString();
            litExpenseElectricity.Text = application.ExpenseElectricity.ToString();
            litExpenseElectricityMultiply.Text = (application.ExpenseElectricity * 10).ToString();
            litExpenseHeat.Text = application.ExpenseHeat.ToString();
            litExpenseHeatMultiply.Text = (application.ExpenseHeat * 10).ToString();
            litExpenseInsurance.Text = application.ExpenseInsurance.ToString();
            litExpenseInsuranceMultiply.Text = (application.ExpenseInsurance * 10).ToString();
            litExpenseGrocery.Text = application.ExpenseGroceries.ToString();
            litExpenseGroceryMultiply.Text = (application.ExpenseGroceries * 10).ToString();
            litExpenseDebtPayments.Text = application.ExpenseDebtPayments.ToString();
            litExpenseDebtPaymentsMultiply.Text = (application.ExpenseDebtPayments * 10).ToString();
            litExpenseFamilyCare.Text = application.ExpenseFamilyCare.ToString();
            litExpenseFamilyCareMultiply.Text = (application.ExpenseFamilyCare * 10).ToString();
            litExpenseTransportation.Text = application.ExpenseTransportation.ToString();
            litExpenseTransportationMultiply.Text = (application.ExpenseTransportation * 10).ToString();
            litExpensePersonal.Text = application.ExpensePersonal.ToString();
            litExpensePersonalMultiply.Text = (application.ExpensePersonal * 10).ToString();

            // Total expenses
            litTotalExpenses.Text = application.ExpenseTotal.ToString();

            // Financial need
            litFinancialNeed.Text = application.FinancialNeed.ToString();


            litQuestion1.Text = LinebreaksToBrs(application.Question1);
            litQuestion2.Text = LinebreaksToBrs(application.Question2);
            litQuestion3.Text = LinebreaksToBrs(application.Question3);
            litQuestion4.Text = LinebreaksToBrs(application.Question4);
            litQuestion5.Text = LinebreaksToBrs(application.Question5);
            litQuestion6.Text = LinebreaksToBrs(application.Question6);
            litQuestion7.Text = LinebreaksToBrs(application.Question7);
            litQuestion8.Text = LinebreaksToBrs(application.Question8);
            litQuestion9.Text = LinebreaksToBrs(application.Question9);
            litQuestion10.Text = LinebreaksToBrs(application.Question10);

            // Setup visibility of elements depending on awards
            var masterPage = Master as NSCC.Web.AwardsApplication.MasterPages.PrintFriendly;

            // Check financial info requirement
            bool hideIncomeExpenseSection = !award.RequireIncomeInfo;

            // Get Question list
            List<string> essayQuestionsNeeded = new List<string>();
            foreach (string questionCode in award.EssayQuestions)
            {
                if (!essayQuestionsNeeded.Contains(questionCode)) { essayQuestionsNeeded.Add(questionCode); }
            }

            // Setup JS code
            if (masterPage != null)
            {
                StringBuilder scriptCode = new StringBuilder();

                // Financial Info
                scriptCode.Append("$(document).ready(function () {");
                if (hideIncomeExpenseSection) { scriptCode.Append("NsccAwardApplicationPdf.hideFinancialInfo();"); }

                // Questions
                scriptCode.Append("NsccAwardApplicationPdf.showQuestions([");
                string questionCodes = string.Empty;
                foreach (string q in essayQuestionsNeeded) { questionCodes += "'#trQUESTION" + q + "',"; }
                scriptCode.Append(questionCodes.TrimEnd(",".ToCharArray()));
                scriptCode.Append("]);");

                // Script close
                scriptCode.Append("});");

                // Inject in page
                masterPage.Page.ClientScript.RegisterStartupScript(this.GetType(), "AwardsScript", scriptCode.ToString(), true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "AwardsScript", scriptCode.ToString(), true);
            }                

        }

        private string LinebreaksToBrs(string input)
        {
            input = input.Replace("\n", "<br/>");

            return input;
        }

    }
}