using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.IO;
using System.Reflection;
using System.Web.Caching;

using CodeGolem;
using LinqToTwitter;
using NSCC.Web.Public.TwitterWidget.Classes;

namespace NSCC.Web.Public.TwitterWidget
{
    public partial class TwitterFeed : EmbeddedUserControl
    {
        [MarkupControl]
        [MarkupControlEvent("ItemDataBound", "rpItems_DataBound")]
        private Repeater rpItems;

        public string TwitterUser { get; set; }
        public int TweetCount { get; set; }
        public int MaxTweetLength { get; set; }
        public bool ParseTweets { get; set; }
        public bool ForceRefresh { get; set; }
        public int CacheDuration { get; set; } // In Minutes
        public bool OpenLinksInNewWindow { get; set; }

        private int itemCount = 0;

        public TwitterFeed()
            : base("TwitterFeed.ascx")
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                GetTweets();

                /*
                LinqToTwitter.Help help = NSCC.Web.Public.TwitterWidget.Classes.Utilities.GetRateLimits();                
                foreach (var category in help.RateLimits)
                {
                    Response.Write("Category: " + category.Key + "<br/>");

                    foreach (var limit in category.Value)
                    {
                        Response.Write("Resource: " + limit.Resource + " Remaining: " + limit.Remaining + " Reset: " + limit.Reset + " Limit: " + limit.Limit + "<br/>");
                    }
                }                
                */
            }
        }

        protected void rpItems_DataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {               

                Tweet tweet = (Tweet)e.Item.DataItem;
                HtmlGenericControl divTweetContainer = (HtmlGenericControl)e.Item.FindControl("divTweetContainer");
                HyperLink hlTwitterUser = (HyperLink)e.Item.FindControl("hlTwitterUser");
                Image imgTwitterProfile = (Image)e.Item.FindControl("imgTwitterProfile");
                Literal litTweetAuthor = (Literal)e.Item.FindControl("litTweetAuthor");
                HyperLink hlTweetText = (HyperLink)e.Item.FindControl("hlTweetText");
                Literal litTweetText = (Literal)e.Item.FindControl("litTweetText");
                //Literal litTweetTime = (Literal)e.Item.FindControl("litTweetTime");
                HyperLink hlMoreLink = (HyperLink)e.Item.FindControl("hlMoreLink");


                if ((e.Item.ItemIndex + 1) == itemCount) { divTweetContainer.Attributes.Add("class", "outer-border twitter-btm"); }
                else { divTweetContainer.Attributes.Add("class", "outer-border"); }

                string tweetText = tweet.Text;
                                
                if (tweetText.Length > this.MaxTweetLength)
                {
                    tweetText = tweetText.Substring(0, this.MaxTweetLength) + " ... ";
                    hlMoreLink.NavigateUrl = String.Format(hlMoreLink.NavigateUrl, tweet.ScreenName, tweet.StatusId);
                    hlMoreLink.Visible = true;
                }                

                if (this.ParseTweets) { hlTweetText.Visible = false; litTweetText.Text = TwitterExtensions.TextAsHtml(tweetText, this.OpenLinksInNewWindow); }
                else { litTweetText.Visible = false; hlTweetText.NavigateUrl = String.Format(hlTweetText.NavigateUrl, tweet.ScreenName, tweet.StatusId); hlTweetText.Text = tweetText; }

                if (tweet.Retweeted)
                {
                    litTweetAuthor.Text = tweet.RetweetScreenName;
                    hlTwitterUser.NavigateUrl = String.Format(hlTwitterUser.NavigateUrl, tweet.RetweetScreenName);
                    imgTwitterProfile.ImageUrl = tweet.RetweetProfileImageUrl;
                }
                else
                {
                    litTweetAuthor.Text = tweet.ScreenName;
                    hlTwitterUser.NavigateUrl = String.Format(hlTwitterUser.NavigateUrl, tweet.ScreenName);
                    imgTwitterProfile.ImageUrl = tweet.ProfileImageUrl;
                }

                if (this.OpenLinksInNewWindow)
                {
                    hlMoreLink.Target = "_blank";
                    hlTweetText.Target = "_blank";
                    hlTwitterUser.Target = "_blank";
                }
                                
                //TimeSpan tweetedAgo = DateTime.Now.Subtract(tweet.CreatedAt);
                //litTweetTime.Text = tweet.CreatedAt.ToString(); // tweetedAgo.Hours.ToString();
            }
        }

        private void GetTweets()
        {
            int hitsRemaining = 0;

            NSCC.Web.Public.TwitterWidget.Classes.Utilities u = new NSCC.Web.Public.TwitterWidget.Classes.Utilities();

            List<Tweet> statusTweets 
                = u.GetTweets(this.TwitterUser, this.TweetCount, this.ForceRefresh, this.CacheDuration, out hitsRemaining);

            itemCount = statusTweets.Count();
            rpItems.DataSource = statusTweets;
            rpItems.DataBind();
        }
    }
}