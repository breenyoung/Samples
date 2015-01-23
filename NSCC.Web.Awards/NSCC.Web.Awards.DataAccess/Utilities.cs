using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using NSCC.Web.Awards.Classes;


namespace NSCC.Web.Awards.DataAccess
{
    public class Utilities
    {

        private static readonly Dictionary<string, string> QuestionnaireMap = new Dictionary<string, string>()
        {
            { "Regular", "REFQUESTION1" },
            { "Regular2", "REFQUESTION2" },
            { "Faculty", "REFQUESTION3" },
            { "Faculty2", "REFQUESTION4" },
            { "NSCC", "REFQUESTION5" },
            { "Employer/Community Organization", "REFQUESTION6" }
        };

        private static readonly Dictionary<string, string> LetterMap = new Dictionary<string, string>()
        {
            { "Regular", "REFLETTER" },
            { "Leadership", "REFLETTER2" },
            { "Faculty", "REFLETTER3" },
            { "Disability Resource Facilitator", "REFLETTER4" },
            { "Commitment to Field", "REFLETTER5" },
            { "Community Involvement", "REFLETTER6" }
        }; 


        public static AwardSelection DynamicRowToAwardSelection(dynamic dynamicRow)
        {
            AwardsSearchDal asd = new AwardsSearchDal();

            AwardSelection newAward = new AwardSelection();
            
            newAward.Code = dynamicRow.ID;
            newAward.Description = dynamicRow.Description;
            newAward.DisplayName = dynamicRow.Title;
            newAward.RequireIncomeInfo = dynamicRow.FinancialNeed;

            
            newAward.Deadline = dynamicRow.Deadline;

            int numAwards = 0;
            Int32.TryParse(dynamicRow.AwardsNumber, out numAwards);
            newAward.NumberOfAwards = numAwards;

            newAward.Amount = dynamicRow.Amount;
            newAward.StudentStatusYear = dynamicRow.StudentStatusYear;
            newAward.AcademicLoad = dynamicRow.AcademicLoad;
            newAward.OtherCriteria = dynamicRow.OtherCriteria;

            if (dynamicRow.AwardType != null) { newAward.AwardType = dynamicRow.AwardType; }
            if (dynamicRow.Specificity != null) { newAward.Specificity = ParseSharepointMultiField(dynamicRow.Specificity); }
            if (dynamicRow.SpecialCriteria != null) { newAward.SpecialCriteria = ParseSharepointMultiField(dynamicRow.SpecialCriteria); }

            if (dynamicRow.Campus != null)
            {
                int allCampusCount = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["AWARD_SUMMARY_ALL_CAMPUS_COUNT"]);

                newAward.EligibleCampuses = ParseSharepointMultiField(dynamicRow.Campus);

                // Needed because we no longer store all campuses when it applies to all'
                if (newAward.EligibleCampuses.Count == allCampusCount)
                {
                    List<CampusVo> allCampuses = asd.GetCampuses();
                    foreach (CampusVo cv in allCampuses)
                    {
                        newAward.EligibleCampusNames.Add(cv.CampusDescr);
                    }
                }
                else
                {
                    newAward.HasCampusRestrictions = true;
                    foreach (string c in newAward.EligibleCampuses)
                    {
                        CampusVo cv = asd.GetCampusByCode(c);
                        if (cv != null) { newAward.EligibleCampusNames.Add(cv.CampusDescr); }
                    }                    
                }
            }

            // Essay Questions
            if (dynamicRow.EssayQuestions != null) { newAward.EssayQuestions = ParseSharepointMultiField(dynamicRow.EssayQuestions); }
            
            // Programs handling
            if (dynamicRow.ProgramCodes != null)
            {
                int allProgramCount =
                    Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["AWARD_SUMMARY_ALL_PROGRAM_COUNT"]);

                newAward.EligiblePrograms = ParseSharepointMultiField(dynamicRow.ProgramCodes);

                if (newAward.EligiblePrograms.Count == allProgramCount)
                {
                    List<ProgramVo> allPrograms = asd.GetAllPrograms();
                    foreach (ProgramVo pv in allPrograms)
                    {
                        newAward.EligiblePrograms.Add(pv.ProgramCode);
                        newAward.EligibleProgramNames.Add(pv.ProgramDescr);
                    }
                }
                else
                {
                    newAward.HasProgramRestrictions = true;
                    foreach (string p in newAward.EligiblePrograms)
                    {
                        ProgramVo pv = asd.GetProgramByCode(p);
                        if (pv != null) { newAward.EligibleProgramNames.Add(pv.ProgramDescr); }
                    }                                        
                }
            }


            // Attachment handling
            // Codes:
            // REFQUESTION1
            // REFQUESTION2
            // REFQUESTION3
            // REFQUESTION4
            // REFLETTER
            // HIGHSCHOOLTRANSCRIPT

            List<string> questionnaireTypes = ParseSharepointMultiField(dynamicRow.ReferenceQuestionnaireType);
            List<string> letterTypes = ParseSharepointMultiField(dynamicRow.ReferenceLetterType);

            newAward.QuestionnaireTypes = questionnaireTypes;

            if (dynamicRow.ReferenceQuestionnaire != null)
            {
                int numRefQuestionnaires = 0;
                Int32.TryParse(dynamicRow.ReferenceQuestionnaire, out numRefQuestionnaires);

                if (numRefQuestionnaires > 0 && questionnaireTypes.Count > 0)
                {
                    if (numRefQuestionnaires > 1 && questionnaireTypes.Count == 1)
                    {
                        // Requires two of the same type (Regular or Faculty)
                        if (questionnaireTypes[0].Equals("Regular"))
                        {
                            newAward.AttachmentsRequired.Add(new AwardAttachment { AttachmentType = QuestionnaireMap["Regular"] });    
                            newAward.AttachmentsRequired.Add(new AwardAttachment { AttachmentType = QuestionnaireMap["Regular2"] });    
                        }
                        else if (questionnaireTypes[0].Equals("Faculty"))
                        {
                            newAward.AttachmentsRequired.Add(new AwardAttachment { AttachmentType = QuestionnaireMap["Faculty"] });    
                            newAward.AttachmentsRequired.Add(new AwardAttachment { AttachmentType = QuestionnaireMap["Faculty2"] });                                
                        }                        
                    }
                    else
                    {
                        foreach (string questionnaire in questionnaireTypes)
                        {
                            string outVal = string.Empty;
                            QuestionnaireMap.TryGetValue(questionnaire, out outVal);
                            if (!String.IsNullOrEmpty(outVal))
                            {
                                newAward.AttachmentsRequired.Add(new AwardAttachment { AttachmentType = outVal });
                            }
                        }
                    }
                }
            }

            if(letterTypes.Count > 0)
            {
                foreach (string letterType in letterTypes)
                {
                    string outVal = string.Empty;
                    LetterMap.TryGetValue(letterType, out outVal);
                    if (!String.IsNullOrEmpty(outVal))
                    {
                        newAward.AttachmentsRequired.Add(new AwardAttachment { AttachmentType = outVal });    
                    }                    
                }
            }


            if (dynamicRow.HighSchool != null && dynamicRow.HighSchool)
            {
                newAward.AttachmentsRequired.Add(new AwardAttachment { AttachmentType = "HIGHSCHOOLTRANSCRIPT" });                
            }
            newAward.NumberOfAttachments = newAward.AttachmentsRequired.Count;


            newAward.LogoFile = dynamicRow.LogoFile;

            if (dynamicRow.StandardPayment != null && dynamicRow.StandardPayment.Equals("Yes"))
            {
                newAward.StandardPayment = true;
            }

            if (dynamicRow.OtherInfo != null) { newAward.OtherInfo = dynamicRow.OtherInfo; }
            if (dynamicRow.ExtraCriteria != null) { newAward.ExtraCriteria = dynamicRow.ExtraCriteria; }

            return newAward;

        }

        private static List<string> ParseSharepointMultiField(string input)
        {
            // Format: ;#Value 1;#Value 2;#

            List<string> output = new List<string>();

            if (!String.IsNullOrEmpty(input))
            {
                input = input.TrimEnd(";#".ToCharArray());

                output = new List<string>(input.Split(";#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            }

            return output;
        }
    }
}
