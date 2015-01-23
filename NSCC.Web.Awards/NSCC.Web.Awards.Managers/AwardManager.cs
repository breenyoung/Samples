using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using NSCC.Web.Awards.DataAccess;
using NSCC.Web.Awards.Managers.AwardsWs;
using AwardSelection = NSCC.Web.Awards.Classes.AwardSelection;
using AwardAttachment = NSCC.Web.Awards.Classes.AwardAttachment;

namespace NSCC.Web.Awards.Managers
{
    public class AwardManager
    {
        private readonly string _sessionKey = ConfigurationManager.AppSettings["AWARDS_SESSION_KEY"];
        private readonly string _cacheKey = ConfigurationManager.AppSettings["AWARDS_CACHE_KEY"];
        private readonly string _cacheDuration = ConfigurationManager.AppSettings["AWARDS_CACHE_DURATION"];

        public AwardSelection GetAwardById(string code, bool forceRefresh, bool directDataAccess)
        {
            List<AwardSelection> awards = GetAllAwards(forceRefresh, directDataAccess);

            AwardSelection selected = awards.SingleOrDefault(a => a.Code.Equals(code));

            return selected;
        }


        public List<AwardSelection> GetAllAwards(bool forceRefresh, bool directDataAccess)
        {
            List<AwardSelection> awards = new List<AwardSelection>();

            if (HttpContext.Current.Cache[_cacheKey] != null && !forceRefresh)
            {
                awards = (List<AwardSelection>) HttpContext.Current.Cache[_cacheKey];
            }
            else
            {

                if (directDataAccess)
                {
                    awards = this.GetAllAwards(); // Direct from db
                }
                else
                {
                    // Get from WS
                    AwardsWs.Service1 svc = new AwardsWs.Service1();
                    awards = GeneratedClassToAwardSelection(svc.GetAllAwards());
                }

                int cacheDuration;
                if (!Int32.TryParse(_cacheDuration, out cacheDuration)) { cacheDuration = 500; /* In minutes*/ }

                HttpContext.Current.Cache.Add(_cacheKey,
                                              awards,
                                              null,
                                              DateTime.Now.AddMinutes(cacheDuration),
                                              Cache.NoSlidingExpiration,
                                              CacheItemPriority.Normal,
                                              null);

            }

            return awards;
        }

        private List<AwardSelection> GetAllAwards()
        {
            AwardsDal dal = new AwardsDal();

            return  dal.GetAllAwards();
        }

        public List<AwardSelection> GetAwardsFromSession()
        {
            if (HttpContext.Current.Session[_sessionKey] != null)
            {
                List<AwardSelection> selectedAwards = (List<AwardSelection>)HttpContext.Current.Session[_sessionKey];
                return selectedAwards;
            }

            return new List<AwardSelection>();
        }

        public void AddAwardsToSession(List<AwardSelection> awards)
        {
            HttpContext.Current.Session.Add(_sessionKey, awards);            
        }

        public void RemoveAllAwardsFromSession()
        {
            if (HttpContext.Current.Session[_sessionKey] != null)
            {
                HttpContext.Current.Session.Remove(_sessionKey);
            }            
        }

        public void RemoveAwardFromSession(string code)
        {
            if (HttpContext.Current.Session[_sessionKey] != null)
            {
                List<AwardSelection> selectedAwards = (List<AwardSelection>)HttpContext.Current.Session[_sessionKey];

                List<AwardSelection> modifiedAwards = new List<AwardSelection>();
                foreach (AwardSelection a in selectedAwards)
                {
                    if (!a.Code.Equals(code))
                    {
                        modifiedAwards.Add(a);
                    }
                }

                HttpContext.Current.Session.Add(_sessionKey, modifiedAwards);
            }
        }

        private List<AwardSelection> GeneratedClassToAwardSelection(AwardsWs.AwardSelection[] generated)
        {
            List<AwardSelection> awards = new List<AwardSelection>();

            for (int i = 0; i < generated.Length; i++)
            {
                AwardSelection a = new AwardSelection();
                AwardsWs.AwardSelection g = generated[i];

                a.Code = g.Code;
                a.DisplayName = g.DisplayName;
                a.Description = g.Description;
                a.RequireIncomeInfo = g.RequireIncomeInfo;

                if (g.EligibleCampuses != null) { a.EligibleCampuses = new List<string>(g.EligibleCampuses); }
                if (g.EligiblePrograms != null) { a.EligiblePrograms = new List<string>(g.EligiblePrograms); }
                if (g.EssayQuestions != null) { a.EssayQuestions = new List<string>(g.EssayQuestions); }

                if (g.AttachmentsRequired != null)
                {
                    a.NumberOfAttachments = g.AttachmentsRequired.Length;
                    for (int j = 0; j < g.AttachmentsRequired.Length; j++)
                    {
                        AwardAttachment newAttach = new AwardAttachment();
                        newAttach.AttachmentType = g.AttachmentsRequired[j].AttachmentType;
                        a.AttachmentsRequired.Add(newAttach);
                    }
                }

                awards.Add(a);
            }

            return awards;

        }
     
    }
}