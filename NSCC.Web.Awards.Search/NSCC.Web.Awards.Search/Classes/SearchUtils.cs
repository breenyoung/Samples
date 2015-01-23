using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using NSCC.Web.Awards.Classes;

namespace NSCC.Web.Awards.Search.Classes
{
    public class SearchUtils
    {
        private static readonly string KeywordKey = System.Configuration.ConfigurationManager.AppSettings["QUERYSTRING_KEYWORD_KEY"].ToString();
        private static readonly string ProgramKey = System.Configuration.ConfigurationManager.AppSettings["QUERYSTRING_PROGRAM_KEY"].ToString();
        private static readonly string CampusKey = System.Configuration.ConfigurationManager.AppSettings["QUERYSTRING_CAMPUS_KEY"].ToString();
        private static readonly string DeliveryKey = System.Configuration.ConfigurationManager.AppSettings["QUERYSTRING_DELIVERY_KEY"].ToString();
        private static readonly string YearKey = System.Configuration.ConfigurationManager.AppSettings["QUERYSTRING_YEAR_KEY"].ToString();
        private static readonly string SpecialKey = System.Configuration.ConfigurationManager.AppSettings["QUERYSTRING_SPECIAL_KEY"].ToString();

        public static AwardSearch GetSearchFromQueryString(NameValueCollection querystring)
        {
            
            AwardSearch search = new AwardSearch();
            if (!String.IsNullOrEmpty(querystring[KeywordKey])) { search.Keyword = DecodeString(querystring[KeywordKey].ToString());}
            if (!String.IsNullOrEmpty(querystring[ProgramKey])) { search.Program = DecodeString(querystring[ProgramKey].ToString()); }
            if (!String.IsNullOrEmpty(querystring[CampusKey])) { search.Campus = DecodeString(querystring[CampusKey].ToString()); }
            if (!String.IsNullOrEmpty(querystring[DeliveryKey])) { search.ProgramDelivery = DecodeString(querystring[DeliveryKey].ToString()); }
            if (!String.IsNullOrEmpty(querystring[YearKey])) { search.ProgramYear = DecodeString(querystring[YearKey].ToString()); }

            /*
            if (!String.IsNullOrEmpty(querystring[SpecialKey]))
            {
                string[] specialCriterias 
                    = querystring[SpecialKey].Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < specialCriterias.Length; i++)
                {
                    search.SpecialCriteria.Add(DecodeString(specialCriterias[i]));
                }
            }
            */

            return search;
        }

        public static string GetQueryStringFromSearch(AwardSearch search)
        {
            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrEmpty(search.Keyword)) { sb.Append(KeywordKey + "=" + EncodeString(search.Keyword) + "&"); }
            if (!String.IsNullOrEmpty(search.Program)) { sb.Append(ProgramKey + "=" + EncodeString(search.Program) + "&"); }
            if (!String.IsNullOrEmpty(search.Campus)) { sb.Append(CampusKey + "=" + EncodeString(search.Campus) + "&"); }
            if (!String.IsNullOrEmpty(search.ProgramDelivery)) { sb.Append(DeliveryKey + "=" + EncodeString(search.ProgramDelivery) + "&"); }
            if (!String.IsNullOrEmpty(search.ProgramYear)) { sb.Append(YearKey + "=" + EncodeString(search.ProgramYear) + "&"); }

            /*
            if (search.SpecialCriteria.Count > 0)
            {
                string criteria = string.Empty;
                foreach (string s in search.SpecialCriteria) { criteria += EncodeString(s) + "*"; }
                criteria = criteria.TrimEnd("*".ToCharArray());
                sb.Append(SpecialKey + "=" + criteria + "&");
            }
            */

            string finalQuery = sb.ToString().TrimEnd("&".ToCharArray());

            return finalQuery;
        }

        private static string EncodeString(string input)
        {
            return HttpUtility.UrlEncode(input);
        }

        private static string DecodeString(string input)
        {
            return HttpUtility.UrlDecode(input);
        }
    }
}