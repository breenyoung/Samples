using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NSCC.Web.Awards.Classes.Validation;

namespace NSCC.Web.Awards.Classes
{
    public class AwardApplication
    {
        
        #region Form Properties

        [Required]
        public Guid Id { get; set; }
        public DateTime DateSubmitted { get; set; }
        public bool AcceptedTerms { get; set; }
        public string UserAgent { get; set; }

        // Personal
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string StudentNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required]        
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        [Required]
        public string Campus { get; set; }
        public string CampusName { get; set; }

        [Required]        
        public string Program { get; set; }
        public string ProgramName { get; set; }

        // Income
        public decimal IncomePreStudy { get; set; }
        public decimal IncomeFamily { get; set; }
        public decimal IncomeSpouse { get; set; }
        public decimal IncomeScholarships { get; set; }
        public decimal IncomeSponsorships { get; set; }
        public decimal IncomeStudentLoan { get; set; }
        public decimal IncomeOtherLoan { get; set; }
        public decimal IncomeSavings { get; set; }
        public decimal IncomeStudyPeriod { get; set; }
        public decimal IncomeOther { get; set; }
        public decimal IncomeTotal { get; set; }

        // Expenses
        public decimal ExpenseTuition { get; set; }
        public decimal ExpenseHealthBenefits { get; set; }
        public decimal ExpenseStudentAssociation { get; set; }
        public decimal ExpenseUpass { get; set; }
        public decimal ExpenseTextbooks { get; set; }
        public decimal ExpenseParking { get; set; }
        public decimal ExpensePortfolioSupplies { get; set; }
        public decimal ExpenseGeneralSupplies { get; set; }
        public decimal ExpenseTools { get; set; }
        public decimal ExpenseSafetyCerts { get; set; }
        public decimal ExpenseSafetySupplies { get; set; }
        public decimal ExpenseMedical { get; set; }
        public decimal ExpenseOther { get; set; }
        public decimal ExpenseRentMortgage { get; set; }
        public decimal ExpensePhone { get; set; }
        public decimal ExpenseInternet { get; set; }
        public decimal ExpenseElectricity { get; set; }
        public decimal ExpenseHeat { get; set; }
        public decimal ExpenseInsurance { get; set; }
        public decimal ExpenseGroceries { get; set; }
        public decimal ExpenseDebtPayments { get; set; }
        public decimal ExpenseFamilyCare { get; set; }
        public decimal ExpenseTransportation { get; set; }
        public decimal ExpensePersonal { get; set; }
        public decimal ExpenseTotal { get; set; }

        public decimal FinancialNeed { get; set; }

        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }
        public string Question6 { get; set; }
        public string Question7 { get; set; }
        public string Question8 { get; set; }
        public string Question9 { get; set; }
        public string Question10 { get; set; }

        public List<string> Attachments { get; set; } 

        [Required]
        [EnsureOneElement]
        public List<AwardSelection> Awards { get; set;}

        #endregion

        public AwardApplication()
        {

        }

    }
}