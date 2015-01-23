using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Dapper;
using NSCC.Web.Awards.Classes;

namespace NSCC.Web.Awards.DataAccess
{
    public class AwardsDal
    {
        private string _connectionStringWrite = string.Empty; //System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsWriteConnectionString"].ConnectionString;
        private string _connectionStringRead = string.Empty; //System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsReadConnectionString"].ConnectionString;

        public List<AwardSelection> GetAllAwards()
        {
            this._connectionStringRead = System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsReadConnectionString"].ConnectionString;
            using (var conn = new SqlConnection(this._connectionStringRead))
            {
                string query = "SELECT CombinedAwards.*, Awards.AwardSchedules.deadline AS Deadline "
                                
                                // GROSS EXTRA JOINS TO GET PROGRAMS FOR AWARD
                                + ", "
                                + " (replace(replace(replace ((SELECT AcadPlan FROM awards.awards left outer join awards.programstoawards on Awards.Awards.ListItemID = awards.programstoawards.AwardsListItemId "
                                + " left outer join awards.programs on awards.programstoawards.ProgramsListItemId = awards.programs.ListItemId "
                                + " WHERE CombinedAwards.ID = Awards.Awards.ID for XML PATH('') ), '</AcadPlan><AcadPlan>', ';#'),'</AcadPlan>', ';#'), '<AcadPlan>', ';#')) AS ProgramCodes "

                                + "FROM awards.awards AS CombinedAwards "
                                + "INNER JOIN Awards.SchedulesToAwards ON Awards.SchedulesToAwards.AwardsListItemID = CombinedAwards.ListItemID "
                                + "INNER JOIN Awards.AwardSchedules ON Awards.SchedulesToAwards.AwardSchedulesListItemID = Awards.AwardSchedules.ListItemID "
                                //+ "WHERE DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.deadline "
                                + "WHERE ((Awards.AwardSchedules.Extension = 1 AND DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.extensiondeadline) OR (DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.deadline)) "
                                + "AND Awards.AwardSchedules.Published = 1 "
                                + "ORDER BY CombinedAwards.title";

                conn.Open();

                var rows = conn.Query(query, null);

                return rows.Select(r => Utilities.DynamicRowToAwardSelection(r)).Cast<AwardSelection>().ToList();
            }
        }


        public AwardApplication GetApplication(Guid id)
        {
            this._connectionStringWrite = System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsWriteConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(this._connectionStringWrite))
            {
                string query = "SELECT * FROM submissions WHERE id = @id";

                conn.Open();

                AwardApplication awardApplication = conn.Query<AwardApplication>(query, new { id = id }).SingleOrDefault();

                return awardApplication;
            }
        }

        public List<AwardSelection> GetAwardsForApplication(Guid submissionId)
        {
            this._connectionStringWrite = System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsWriteConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(this._connectionStringWrite))
            {
                string query = "SELECT * FROM submissionawards WHERE submissionid = @id";

                conn.Open();

                var awards = conn.Query<AwardSelection>(query, new { id = submissionId });

                return awards.ToList<AwardSelection>();
            }
        }

        public void CreateApplication(AwardApplication awardApplication)
        {
            this._connectionStringWrite = System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsWriteConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(this._connectionStringWrite))
            {

                string query =
                    "INSERT INTO submissions (id, datesubmitted, firstname, lastname, studentnumber, email, address1, address2, city, province,postalcode,phone1,phone2,campus,program," +
                    "incomeprestudy,incomefamily,incomespouse,incomescholarships,incomesponsorships,incomestudentloan,incomeotherloan,incomesavings,incomestudyperiod,incomeother,incometotal," +
                    "expensetuition,	expensehealthbenefits,expensestudentassociation,expenseupass,expensetextbooks,expenseparking,expenseportfoliosupplies,expensegeneralsupplies," +
                    "expensetools,expensesafetycerts,expensesafetysupplies,expensemedical,expenseother,expenserentmortgage,expensephone,expenseinternet,expenseelectricity,expenseheat," +
                    "expenseinsurance,expensegroceries,expensedebtpayments,expensefamilycare,expensetransportation,expensepersonal,expensetotal,financialneed," +
                    "question1, question2, question3, question4, question5, question6, question7, question8, question9, question10, useragent, acceptedterms, campusname, programname)"

                    +

                    "VALUES(@id, @datesubmitted, @firstname, @lastname, @studentnumber, @email, @address1, @address2, @city, @province, @postalcode,@phone1,@phone2,@campus,@program," +
                    "@incomeprestudy,@incomefamily,@incomespouse,@incomescholarships,@incomesponsorships,@incomestudentloan,@incomeotherloan,@incomesavings,@incomestudyperiod,@incomeother,@incometotal," +
                    "@expensetuition,@expensehealthbenefits,@expensestudentassociation,@expenseupass,@expensetextbooks,@expenseparking,@expenseportfoliosupplies,@expensegeneralsupplies," +
                    "@expensetools,@expensesafetycerts,@expensesafetysupplies,@expensemedical,@expenseother,@expenserentmortgage,@expensephone,@expenseinternet,@expenseelectricity,@expenseheat," +
                    "@expenseinsurance,@expensegroceries,@expensedebtpayments,@expensefamilycare,@expensetransportation,@expensepersonal,@expensetotal,@financialneed," +
                    "@question1, @question2, @question3, @question4, @question5, @question6, @question7, @question8, @question9, @question10, @useragent, @acceptedterms, @campusname, @programname)";


                using (var transactionScope = new TransactionScope())
                {
                    conn.Open();

                    conn.Execute(query, new
                    {
                        id = awardApplication.Id,
                        datesubmitted = awardApplication.DateSubmitted,
                        firstname = awardApplication.FirstName,
                        lastname = awardApplication.LastName,
                        studentnumber = awardApplication.StudentNumber,
                        email = awardApplication.Email,
                        address1 = awardApplication.Address1,
                        address2 = awardApplication.Address2,
                        city = awardApplication.City,
                        province = awardApplication.Province,
                        postalcode = awardApplication.PostalCode,
                        phone1 = awardApplication.Phone1,
                        phone2 = awardApplication.Phone2,
                        campus = awardApplication.Campus,
                        program = awardApplication.Program,
                        incomeprestudy = awardApplication.IncomePreStudy,
                        incomefamily = awardApplication.IncomeFamily,
                        incomespouse = awardApplication.IncomeSpouse,
                        incomescholarships = awardApplication.IncomeScholarships,
                        incomesponsorships = awardApplication.IncomeSponsorships,
                        incomestudentloan = awardApplication.IncomeStudentLoan,
                        incomeotherloan = awardApplication.IncomeOtherLoan,
                        incomesavings = awardApplication.IncomeSavings,
                        incomestudyperiod = awardApplication.IncomeStudyPeriod,
                        incomeother = awardApplication.IncomeOther,
                        incometotal = awardApplication.IncomeTotal,
                        expensetuition = awardApplication.ExpenseTuition,
                        expensehealthbenefits = awardApplication.ExpenseHealthBenefits,
                        expensestudentassociation = awardApplication.ExpenseStudentAssociation,
                        expenseupass = awardApplication.ExpenseUpass,
                        expensetextbooks = awardApplication.ExpenseTextbooks,
                        expenseparking = awardApplication.ExpenseParking,
                        expenseportfoliosupplies = awardApplication.ExpensePortfolioSupplies,
                        expensegeneralsupplies = awardApplication.ExpenseGeneralSupplies,
                        expensetools = awardApplication.ExpenseTools,
                        expensesafetycerts = awardApplication.ExpenseSafetyCerts,
                        expensesafetysupplies = awardApplication.ExpenseSafetySupplies,
                        expensemedical = awardApplication.ExpenseMedical,
                        expenseother = awardApplication.ExpenseOther,
                        expenserentmortgage = awardApplication.ExpenseRentMortgage,
                        expensephone = awardApplication.ExpensePhone,
                        expenseinternet = awardApplication.ExpenseInternet,
                        expenseelectricity = awardApplication.ExpenseElectricity,
                        expenseheat = awardApplication.ExpenseHeat,
                        expenseinsurance = awardApplication.ExpenseInsurance,
                        expensegroceries = awardApplication.ExpenseGroceries,
                        expensedebtpayments = awardApplication.ExpenseDebtPayments,
                        expensefamilycare = awardApplication.ExpenseFamilyCare,
                        expensetransportation = awardApplication.ExpenseTransportation,
                        expensepersonal = awardApplication.ExpensePersonal,
                        expensetotal = awardApplication.ExpenseTotal,
                        financialneed = awardApplication.FinancialNeed,
                        question1 = awardApplication.Question1,
                        question2 = awardApplication.Question2,
                        question3 = awardApplication.Question3,
                        question4 = awardApplication.Question4,
                        question5 = awardApplication.Question5,
                        question6 = awardApplication.Question6,
                        question7 = awardApplication.Question7,
                        question8 = awardApplication.Question8,
                        question9 = awardApplication.Question9,
                        question10 = awardApplication.Question10,
                        useragent = awardApplication.UserAgent,
                        acceptedterms = awardApplication.AcceptedTerms,
                        campusname = awardApplication.CampusName,
                        programname = awardApplication.ProgramName
                    }
                        );



                    foreach (AwardSelection a in awardApplication.Awards)
                    {
                        string q = "INSERT INTO submissionawards (submissionid, awardid) VALUES(@AppId, @AwardId)";
                        conn.Execute(q, new { AppId = awardApplication.Id, AwardId = a.Code });
                    }

                    transactionScope.Complete();
                }
            }
        }


    }
}
