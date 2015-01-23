using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace NSCC.Web.Awards.Classes
{
    [Serializable]    
    public class AwardSelection
    {
        #region Number to Word Dictionary
        private static IDictionary<int, string> _wordNumbers
            = new Dictionary<int, string>()
                {
                    { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" },
                    { 5, "Five" }, { 6, "Six" }, { 7, "Seven" },
                    { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" },
                    { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" },
                    { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" },
                    { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" },
                    { 20, "Twenty" }, { 21, "Twenty-one" }, { 22, "Twenty-two" },
                    { 23, "Twenty-three" }, { 24, "Twenty-four" }, { 25, "Twenty-five" },
                    { 26, "Twenty-six" }, { 27, "Twenty-seven" }, { 28, "Twenty-eight" },
                    { 29, "Twenty-nine" }, { 30, "Thirty" }
                };
        #endregion

        #region Plurilizer

        private static readonly IDictionary<string, string> _plurilizer
            = new Dictionary<string, string>()
                {
                    { "Award", "Awards"}, { "Bursary", "Bursaries" }, { "Scholarship", "Scholarships"}
                };
        #endregion

        #region Display Exceptions

        private static readonly IDictionary<string, string> _displayExceptions
            = new Dictionary<string, string>()
                {
                    { "female only", "female"},
                    { "mature student", "mature"},
                    { "Female Only", "Female"},
                };

        private static readonly IDictionary<string, bool> _displayExclusions
            = new Dictionary<string, bool>()
                {
                    { "Learning Disability", true}
                };



        #endregion

        private static string _african = "African Nova Scotian";
        private static string _firstNations = "First Nations";

        #region Properties

        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public DateTime Deadline { get; set; }
        public int NumberOfAwards { get; set;}
        public string Amount { get; set; }
        public string AcademicLoad { get; set; }
        public string StudentStatusYear { get; set; }
        public string AwardType { get; set; }
        public List<string> Specificity { get; set; } 
        public List<string> SpecialCriteria { get; set; } 
        public string OtherCriteria { get; set; }

        public bool RequireIncomeInfo { get; set; }
        public int NumberOfAttachments { get; set; }

        public bool HasCampusRestrictions { get; set; }
        public bool HasProgramRestrictions { get; set; }

        public List<AwardAttachment> AttachmentsRequired { get; set; } 
        public List<string> EligibleCampuses { get; set; }
        public List<string> EligibleCampusNames { get; set; } 
        public List<string> EligiblePrograms { get; set; }
        public List<string> EligibleProgramNames { get; set; } 
        public List<string> EssayQuestions { get; set; }

        public string LogoFile { get; set; }
        public bool StandardPayment { get; set; }
        public string OtherInfo { get; set; }
        public string ExtraCriteria { get; set; }

        public List<String> QuestionnaireTypes { get; set; }

        #endregion

        private static int _allCampusCount = Int32.Parse(ConfigurationManager.AppSettings["AWARD_SUMMARY_ALL_CAMPUS_COUNT"]);
        private static string _allCampusLabel = ConfigurationManager.AppSettings["AWARD_SUMMARY_ALL_CAMPUS_LABEL"];
        private static string _allProgramLabel = ConfigurationManager.AppSettings["AWARD_SUMMARY_ALL_PROGRAM_LABEL"];

        public AwardSelection()
        {
            this.NumberOfAttachments = 0;
            this.AttachmentsRequired = new List<AwardAttachment>();
            this.EligibleCampuses = new List<string>();
            this.EligibleCampusNames = new List<string>();
            this.EligiblePrograms = new List<string>();
            this.EligibleProgramNames = new List<string>();
            this.EssayQuestions = new List<string>();

            this.Specificity = new List<string>();
            this.SpecialCriteria = new List<string>();

            this.HasCampusRestrictions = false;
            this.HasProgramRestrictions = false;

            this.LogoFile = string.Empty;

            this.StandardPayment = false;
            this.OtherInfo = string.Empty;
            this.ExtraCriteria = string.Empty;
        }

        #region Helper Methods

        public string PlurilizeAwardType()
        {
            string awardType = this.AwardType;
            if (!String.IsNullOrEmpty(awardType))
            {
                _plurilizer.TryGetValue(this.AwardType, out awardType);
            }

            return awardType;
        }

        public string GetSummary()
        {
            string summaryTemplate = ConfigurationManager.AppSettings["AWARD_SUMMARY_TEMPLATE_SINGULAR"];

            if (this.NumberOfAwards > 1)
            {
                summaryTemplate = ConfigurationManager.AppSettings["AWARD_SUMMARY_TEMPLATE_PLURAL"];
            }

            string awardType = this.AwardType;
            if (this.NumberOfAwards > 1) { awardType = _plurilizer[awardType]; }

            string specialCriteria = string.Empty;
            if (this.SpecialCriteria.Count > 0)
            {


                if (this.SpecialCriteria.Contains(AwardSelection._african) &&
                    this.SpecialCriteria.Contains(AwardSelection._firstNations))
                {
                    // Exception
                    specialCriteria = " " + AwardSelection._african + " and/or " + AwardSelection._firstNations;
                }
                else
                {



                    int criteriaCount = 1;
                    specialCriteria = " ";
                    foreach (string s in this.SpecialCriteria)
                    {
                        if (_displayExclusions.ContainsKey(s) && _displayExclusions[s])
                            continue;
                        
                        string formattedValue = _displayExceptions.ContainsKey(s.ToLower()) ? _displayExceptions[s.ToLower()].ToLower() : s.ToLower();


                        if (criteriaCount == this.SpecialCriteria.Count && this.SpecialCriteria.Count > 1)
                        {
                            specialCriteria = specialCriteria.TrimEnd(", ".ToCharArray());
                            specialCriteria += " and ";
                        }
                        specialCriteria += formattedValue + ", ";
                        criteriaCount++;
                    }
                    specialCriteria = specialCriteria.TrimEnd(", ".ToCharArray());                    
                }
            }


            string campusList = _allCampusLabel;
            if (this.HasCampusRestrictions)
            {               
                campusList = string.Empty;
                int cCount = 1;
                foreach (string c in this.EligibleCampusNames)
                {
                    if (cCount == this.EligibleCampusNames.Count && this.EligibleCampusNames.Count != 1)
                    {
                        campusList = campusList.TrimEnd(", ".ToCharArray());
                        campusList += " or ";
                    }

                    campusList += c + ", ";
                    cCount++;
                }
                campusList = campusList.TrimEnd(", ".ToCharArray());
            }

            string programList = _allProgramLabel;
            if (this.HasProgramRestrictions)
            {
                if (this.EligiblePrograms.Count > 5)
                {
                    programList = "specific programs";
                }
                else
                {
                    programList = " the ";
                    int pCount = 1;
                    foreach (string p in this.EligibleProgramNames)
                    {
                        if (pCount == this.EligibleProgramNames.Count && this.EligibleProgramNames.Count != 1)
                        {
                            programList = programList.TrimEnd(", ".ToCharArray());
                            programList += " or ";
                        }

                        programList += p + ", ";
                        pCount++;
                    }
                    programList = programList.TrimEnd(", ".ToCharArray()) ;
                    if (this.EligiblePrograms.Count == 1) { programList += " program"; }
                    else { programList += " programs"; }
                }
            }


            string wordNumber = string.Empty;
            if (this.NumberOfAwards > 0)
            {
                _wordNumbers.TryGetValue(this.NumberOfAwards, out wordNumber);
                wordNumber = _wordNumbers[this.NumberOfAwards];
            }

            string summary 
                = String.Format(summaryTemplate, wordNumber,
                "$" + this.Amount, awardType.ToLower(), this.AcademicLoad.Equals("All") ? "" : this.AcademicLoad.ToLower(), specialCriteria, 
                                campusList, programList);

            return summary;
        }

        public string GetFormattedSpecialCriteria()
        {
            StringBuilder specialRequirementBuilder = new StringBuilder();

            int counter = 0;
            foreach (var option in SpecialCriteria)
            {
                if (counter < specialRequirementBuilder.Length - 1)
                {
                    specialRequirementBuilder.Append(" &bull; ");
                }
//                string formatttedValue = option;
//                _displayExceptions.TryGetValue(option, out formatttedValue);

                string formatttedValue = _displayExceptions.ContainsKey(option) ? _displayExceptions[option] : option;

                specialRequirementBuilder.Append(formatttedValue);
                counter++;
            }
            return specialRequirementBuilder.ToString();
        }

        #endregion
    }
}