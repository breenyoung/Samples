<%@ Page Language="C#" %>
<%@ Register TagPrefix="uc" Namespace="NSCC.Web.Public.TwitterWidget" Assembly="NSCC.Web.Public.TwitterWidget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=351576814d99efe8" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
			<uc:TwitterFeed id="twitterFeed" runat="server" TwitterUser="NSCCNews" TweetCount="3" 
			MaxTweetLength="50" ParseTweets="True" CacheDuration="60" ForceRefresh="False" OpenLinksInNewWindow="True"/>
    
    </div>
    </form>
</body>
</html>
