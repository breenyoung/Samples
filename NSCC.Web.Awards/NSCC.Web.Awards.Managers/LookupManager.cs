using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using NSCC.Web.Awards.Classes;


namespace NSCC.Web.Awards.Managers
{
    public class LookupManager
    {
        private readonly string _provinceCacheKey = ConfigurationManager.AppSettings["AWARDS_PROVINCE_CACHE_KEY"];

        public List<Province> GetProvinces()
        {
            List<Province> provinces = new List<Province>();

            if (HttpContext.Current.Cache[_provinceCacheKey] != null)
            {
                provinces = (List<Province>)HttpContext.Current.Cache[_provinceCacheKey];
            }
            else
            {
                provinces.Add(new Province { Code = "AB", Name = "Alberta" });
                provinces.Add(new Province { Code = "BC", Name = "British Columbia" });
                provinces.Add(new Province { Code = "MB", Name = "Manitoba" });
                provinces.Add(new Province { Code = "NB", Name = "New Brunswick" });
                provinces.Add(new Province { Code = "NL", Name = "Newfoundland and Labrador" });
                provinces.Add(new Province { Code = "NT", Name = "Northwest Territories" });
                provinces.Add(new Province { Code = "NS", Name = "Nova Scotia" });
                provinces.Add(new Province { Code = "NU", Name = "Nunavut" });
                provinces.Add(new Province { Code = "ON", Name = "Ontario" });
                provinces.Add(new Province { Code = "PE", Name = "Prince Edward Island" });
                provinces.Add(new Province { Code = "PQ", Name = "Quebec" });
                provinces.Add(new Province { Code = "SK", Name = "Saskatchewan" });
                provinces.Add(new Province { Code = "YT", Name = "Yukon" });

                HttpContext.Current.Cache.Add(_provinceCacheKey,
                                              provinces,
                                              null,
                                              Cache.NoAbsoluteExpiration,
                                              Cache.NoSlidingExpiration,
                                              CacheItemPriority.Normal,
                                              null);
            }

            return provinces;
        }

        public Province GetProvinceByCode(string code)
        {
            List<Province> provinces = this.GetProvinces();

            return provinces.SingleOrDefault(p => p.Code.Equals(code.ToUpper()));
        }
    }
}