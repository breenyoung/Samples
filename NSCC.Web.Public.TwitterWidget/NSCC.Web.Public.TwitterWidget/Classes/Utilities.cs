using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Configuration;

using LinqToTwitter;

namespace NSCC.Web.Public.TwitterWidget.Classes
{
    public class Utilities
    {
        public Utilities()
        {

        }

        public List<Tweet> GetTweets(string twitterUser, int tweetCount, bool forceRefresh, int cacheDuration, out int hitsRemaining)
        {

            string cacheKey = "NSCCNewsTweets";
            List<Tweet> allTweets = new List<Tweet>();

            hitsRemaining = 0;

            if (HttpContext.Current.Cache[cacheKey] != null && !forceRefresh)
            {
                allTweets = (List<Tweet>)HttpContext.Current.Cache[cacheKey];
            }
            else
            {
                try
                {
                    var auth = new SingleUserAuthorizer
                    {
                        Credentials = new InMemoryCredentials
                        {
                            ConsumerKey = ConfigurationManager.AppSettings["TWITTER_CONSUMERKEY"].ToString(),
                            ConsumerSecret = ConfigurationManager.AppSettings["TWITTER_CONSUMERSECRET"].ToString(),
                            AccessToken = ConfigurationManager.AppSettings["TWITTER_ACCESSTOKENSECRET"].ToString(),
                            OAuthToken = ConfigurationManager.AppSettings["TWITTER_ACCESSTOKEN"].ToString()
                        }
                    };

                    TwitterContext twitterCtx = new TwitterContext(auth);
                    IQueryable<Status> statusTweets = from tweet in twitterCtx.Status
                                   where tweet.Type == StatusType.User
                                   && tweet.ScreenName == twitterUser
                                   && tweet.Count == tweetCount
                                   select tweet;

                    
                    foreach(Status s in statusTweets)
                    {
                        Tweet t = new Tweet();
                        t.StatusId = s.StatusID;
                        t.ScreenName = s.User.Identifier.ScreenName;
                        t.ProfileImageUrl = s.User.ProfileImageUrl;
                        t.Text = s.Text;

                        if (s.RetweetedStatus.User != null)
                        {
                            t.Retweeted = true;
                            t.RetweetScreenName = s.RetweetedStatus.User.Identifier.ScreenName;
                            t.RetweetProfileImageUrl = s.RetweetedStatus.User.ProfileImageUrl;
                        }

                        allTweets.Add(t);
                    }

                    hitsRemaining = twitterCtx.RateLimitRemaining;

                    if (twitterCtx != null)
                    {
                        twitterCtx.Dispose();
                        twitterCtx = null;
                    }

                    HttpContext.Current.Cache.Add(cacheKey,
                                                  allTweets,
                                                  null,
                                                  DateTime.Now.AddMinutes(cacheDuration),
                                                  Cache.NoSlidingExpiration,
                                                  CacheItemPriority.Normal,
                                                  null);
                }
                catch (Exception ex)
                {
                    // Twitter error, fallback to cache copy, also ignore the 'forceRefresh' value here as 
                    // we have no other place to look other then cache in this scenario

                    if (HttpContext.Current.Cache[cacheKey] != null)
                    {
                        allTweets = (List<Tweet>)HttpContext.Current.Cache[cacheKey];
                    }
                    else
                    {
                        // Return empty set if no cached copy
                        //allTweets = Enumerable.Empty<Status>().AsQueryable();
                        allTweets = new List<Tweet>();
                    }
                }
            }

            return allTweets;
        }

        public static Help GetRateLimits()
        {

            Help rateLimits = null;

            try
            {
                var auth = new SingleUserAuthorizer
                {
                    Credentials = new InMemoryCredentials
                    {
                        ConsumerKey = ConfigurationManager.AppSettings["TWITTER_CONSUMERKEY"].ToString(),
                        ConsumerSecret = ConfigurationManager.AppSettings["TWITTER_CONSUMERSECRET"].ToString(),
                        AccessToken = ConfigurationManager.AppSettings["TWITTER_ACCESSTOKENSECRET"].ToString(),
                        OAuthToken = ConfigurationManager.AppSettings["TWITTER_ACCESSTOKEN"].ToString()
                    }
                };

                var twitterCtx = new TwitterContext(auth);
                rateLimits =
                     (from help in twitterCtx.Help
                      where help.Type == HelpType.RateLimits 
                      && help.Resources == "statuses"
                      select help)
                     .SingleOrDefault();               
            }
            catch (Exception ex)
            {

            }

            return rateLimits;
        }


        private bool HasExceededRateLimit()
        {


            return false;
        }

    }
}