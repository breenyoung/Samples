using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSCC.Web.Public.TwitterWidget.Classes
{
    [Serializable]
    public class Tweet
    {
        public string StatusId { get; set; }
        public string Text { get; set; }
        public string ScreenName { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool Retweeted { get; set; }
        public string RetweetScreenName { get; set; }
        public string RetweetProfileImageUrl { get; set; }
    }
}