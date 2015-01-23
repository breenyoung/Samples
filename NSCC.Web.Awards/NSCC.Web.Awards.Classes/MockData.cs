using System.Collections.Generic;

namespace NSCC.Web.Awards.Classes
{
    public class MockData
    {

        private readonly List<string> _allCampuses = new List<string>{"AKERL", "ANNAP","BURRI","CUMBE","INSTI","KINGS","LUNEN","MARCO","PICTO","SHELB","STRAT","TRURO","WATER"};
        private readonly List<string> _allPrograms = new List<string> { "ADDICO", "AGEOSEM1", "AIRMAINAVS", "AIRMAINENG", "AIRMAINSTR", "AMSIGNLANG", "ARCHENGTCN", "ARTMUSBUS", "AUTOCOLREP", "AUTOSERVRE", "BAKPASTART", "BEHAVINTER", "BLDSYSTCN", "BOULANGER", "BRICKLAYIN", "BUSADM-YR1", "CABCARP", "CARPENTDIP", "CERTWELD", "CIVENGTECH", "COMDISABSP", "COMELECTCN", "CONSTMGTD", "CONTCARE", "COOKING", "COSMETOL", "CULINARTS", "DEAFSTDIES", "DENTALASII", "DIGIANIM", "DIREPINMAR", "DRAFTINGAR", "DRAFTINGME", "EARCHIEDUC", "ELECONIN", "ELECONINDI", "ELEENGTCN", "ELEENGTECH", "ELEMECTCN", "ELTRENTECH", "ENERSUSENG", "ENVENGTECH", "ESTHETICS", "GASINSSERV", "GEOMENTECH", "GEOSCIYR1", "GEOTHERMAL", "GRAPHICDES", "GRAPROD", "HDEQTTREP", "HDTRUCKDIP", "HEAVYEQOP", "HEINFOMAN", "HERCARPENT", "HORTLANDTG", "HUMRESMAN", "HUSVNOCONC", "INDENGTECH", "INDINSTRU", "INDMEC", "INMOGRAPHS", "INTERBUSIN", "IT-NOCONC", "LAWSECURIT", "LIBINFTECH", "MACSHOPDIP", "MARENGTECH", "MARGEOM", "MARINDRIG", "MARNAVTECH", "MECENGTECH", "MEDCOMARTS", "MEDLABTECH", "MEDOFFAS", "MENTHEALTH", "METALFAB", "MOTOPOWER", "MTRAN", "MUSARTS", "NATRESETD", "OCHESAFETY", "OFADSIMGT", "OFFADMIN", "OTAPTA", "PARASERV", "PHARMTECH", "PHOTODIGI", "PIPETRADES", "PLUMBING", "POWENGTECH", "PRACNURDIP", "PROCOPERAT", "PUBRELAT", "RADTELARTS", "RECLEAD", "RECORDARTS", "REFAIRCOND", "SCREENARTS", "STEAMPIPE", "SURVTECH", "TMAN-Y1", "UTILLINWRK", "WELDINGDIP", "WELDINSQUA" }; 



        readonly AwardAttachment _refquest1 = new AwardAttachment { AttachmentType = "REFQUESTION1" };
        readonly AwardAttachment _refquest2 = new AwardAttachment { AttachmentType = "REFQUESTION2" };
        readonly AwardAttachment _refletter = new AwardAttachment { AttachmentType = "REFLETTER" };
        readonly AwardAttachment _highschool = new AwardAttachment { AttachmentType = "HIGHSCHOOLTRANSCRIPT" };

        public List<AwardSelection> GetMockAwards()
        {
            List<AwardSelection> awards = new List<AwardSelection>();

            AwardSelection a1 = new AwardSelection
                {
                    Code = "A1",
                    DisplayName = "JR Eisener Contracting Limited Award",
                    Description = "DESC1",
                    RequireIncomeInfo = true
                };
            a1.EligibleCampuses = _allCampuses;
            a1.EligiblePrograms = _allPrograms;
            awards.Add(a1);


            AwardSelection a2 = new AwardSelection
                {
                    Code = "A2",
                    DisplayName = "PCL Constructors Canada Inc. Award",
                    Description = "DESC2",
                    RequireIncomeInfo = true
                };
            a2.EligibleCampuses = _allCampuses;
            a2.EligiblePrograms = _allPrograms;
            a2.AttachmentsRequired.Add(_highschool);
            awards.Add(a2);

            AwardSelection a3 = new AwardSelection
                {
                    Code = "A3",
                    DisplayName = "Rogers Radio & Broadcasting Award",
                    Description = "DESC3",
                    RequireIncomeInfo = true
                };
            a3.EligibleCampuses = _allCampuses;
            a3.EligiblePrograms = _allPrograms;
            a3.AttachmentsRequired.Add(_refquest1);
            awards.Add(a3);

            AwardSelection a4 = new AwardSelection
                {
                    Code = "A4",
                    DisplayName = "Allan R. Fleming Applied Arts Award",
                    Description = "DESC4",
                    RequireIncomeInfo = true
                };
            a4.EligibleCampuses = _allCampuses;
            a4.EligiblePrograms = _allPrograms;
            a4.AttachmentsRequired.Add(_refquest1);
            a4.AttachmentsRequired.Add(_refquest2);
            awards.Add(a4);


            AwardSelection a5 = new AwardSelection
            {
                Code = "A5",
                DisplayName = "Atlantic Credit Unions Bursary",
                Description = "DESC5",
                RequireIncomeInfo = true
            };
            a5.EligibleCampuses = _allCampuses;
            a5.EligiblePrograms = _allPrograms;
            a5.AttachmentsRequired.Add(_refletter);
            awards.Add(a5);

            AwardSelection a6 = new AwardSelection
                {
                    Code = "A6",
                    DisplayName = "Bird Construction Award",
                    Description = "DESC6",
                    RequireIncomeInfo = true
                };
            a6.EligibleCampuses = _allCampuses;
            a6.EligiblePrograms = _allPrograms;
            a6.AttachmentsRequired.Add(_refletter);
            a6.AttachmentsRequired.Add(_highschool);
            awards.Add(a6);

            AwardSelection a7 = new AwardSelection
            {
                Code = "A7",
                DisplayName = "C Vanessa Hammock Award",
                Description = "DESC7",
                RequireIncomeInfo = true
            };
            a7.EligibleCampuses = _allCampuses;
            a7.EligiblePrograms = _allPrograms;
            a7.AttachmentsRequired.Add(_refletter);
            a7.AttachmentsRequired.Add(_refquest1);
            a7.AttachmentsRequired.Add(_refquest2);
            awards.Add(a7);

            AwardSelection a8 = new AwardSelection
            {
                Code = "A8",
                DisplayName = "Dr. Jack Buckley Scholarship",
                Description = "DESC8",
                RequireIncomeInfo = true
            };
            a8.EligibleCampuses = _allCampuses;
            a8.EligiblePrograms = _allPrograms;
            a8.AttachmentsRequired.Add(_refletter);
            a8.AttachmentsRequired.Add(_refquest1);
            awards.Add(a8);

            AwardSelection a9 = new AwardSelection
            {
                Code = "A9",
                DisplayName = "Halifax Port Authority Bursary",
                Description = "DESC9",
                RequireIncomeInfo = true
            };
            a9.EligibleCampuses = _allCampuses;
            a9.EligiblePrograms = _allPrograms;
            a9.AttachmentsRequired.Add(_refletter);
            a9.AttachmentsRequired.Add(_refquest1);
            a9.AttachmentsRequired.Add(_refquest2);
            a9.AttachmentsRequired.Add(_highschool);
            awards.Add(a9);


            AwardSelection a10 = new AwardSelection
            {
                Code = "A10",
                DisplayName = "RBC Award",
                Description = "DESC10",
                RequireIncomeInfo = true
            };
            a10.EligibleCampuses = _allCampuses;
            a10.EligiblePrograms = _allPrograms;
            a10.EssayQuestions.Add("QUESTION2");
            a10.AttachmentsRequired.Add(_refletter);
            a10.AttachmentsRequired.Add(_refquest1);
            a10.AttachmentsRequired.Add(_refquest2);
            a10.AttachmentsRequired.Add(_highschool);
            awards.Add(a10);


            AwardSelection a11 = new AwardSelection
            {
                Code = "A11",
                DisplayName = "Scotiabank Award",
                Description = "DESC11",
                RequireIncomeInfo = false
            };
            a11.EligibleCampuses = _allCampuses;
            a11.EligiblePrograms = _allPrograms;
            a11.AttachmentsRequired.Add(_refletter);
            a11.AttachmentsRequired.Add(_refquest1);
            a11.AttachmentsRequired.Add(_refquest2);
            a11.AttachmentsRequired.Add(_highschool);
            awards.Add(a11);

            AwardSelection a12 = new AwardSelection
            {
                Code = "A12",
                DisplayName = "Stevens Group Award",
                Description = "DESC12",
                RequireIncomeInfo = false
            };
            a12.EligibleCampuses = _allCampuses;
            a12.EligiblePrograms = _allPrograms;
            a12.EssayQuestions.Add("QUESTION3");
            awards.Add(a12);

            AwardSelection a13 = new AwardSelection
            {
                Code = "A13",
                DisplayName = "Saxton Family Award",
                Description = "DESC13",
                RequireIncomeInfo = true
            };
            a13.EligibleCampuses = new List<string>{"AKERL", "BURRI"};
            a13.EligiblePrograms = _allPrograms;
            a13.AttachmentsRequired.Add(_refletter);
            a13.AttachmentsRequired.Add(_refquest1);
            a13.AttachmentsRequired.Add(_refquest2);
            a13.AttachmentsRequired.Add(_highschool);            
            awards.Add(a13);

            AwardSelection a14 = new AwardSelection
            {
                Code = "A14",
                DisplayName = "Jeff Todd Memorial Award",
                Description = "DESC14",
                RequireIncomeInfo = true
            };
            a14.EligibleCampuses = new List<string> { "AKERL" };
            a14.EligiblePrograms = _allPrograms;
            a14.EssayQuestions.Add("QUESTION4");
            a14.AttachmentsRequired.Add(_refletter);
            a14.AttachmentsRequired.Add(_refquest1);
            awards.Add(a14);

            AwardSelection a15 = new AwardSelection
            {
                Code = "A15",
                DisplayName = "Ryan MacAskill Memorial Award",
                Description = "DESC15",
                RequireIncomeInfo = true
            };
            a15.EligibleCampuses = new List<string> { "KINGS" };
            a15.EligiblePrograms = new List<string> { "BAKPASTART" };
            a15.AttachmentsRequired.Add(_highschool);
            awards.Add(a15);

            AwardSelection a16 = new AwardSelection
            {
                Code = "A16",
                DisplayName = "Canadian Hospitality Foundation Culinary (1-year) Scholarship",
                Description = "DESC16",
                RequireIncomeInfo = true
            };
            a16.EligibleCampuses = _allCampuses;
            a16.EligiblePrograms = new List<string> { "BAKPASTART", "BOULANGER" };
            a16.EssayQuestions.Add("QUESTION2");
            a16.AttachmentsRequired.Add(_refletter);
            a16.AttachmentsRequired.Add(_refquest1);
            a16.AttachmentsRequired.Add(_highschool);
            awards.Add(a16);

            return awards;
        }
    }
}