using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSCC.Web.Awards.Search.Classes
{
    public class HtmlUtils
    {

        public static string HtmlStrip(string input)
        {
            HtmlToText htt = new HtmlToText();
            string s = htt.ConvertHtml(input);
            return s.Trim();
        }

    }
}