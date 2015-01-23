<%@ Control Language="C#" %>
<div id="twitter-feed">
    <asp:Repeater ID="rpItems" runat="server">
        <ItemTemplate>
		    <div id="divTweetContainer" runat="server">
			    <div class="inner-border">
                    <asp:HyperLink ID="hlTwitterUser" runat="server" NavigateUrl="http://twitter.com/{0}">
                        <asp:Image ID="imgTwitterProfile" runat="server" CssClass="float-l" />
                    </asp:HyperLink>				    
				    <p>
                        <strong><asp:Literal ID="litTweetAuthor" runat="server" /></strong>
                        <asp:HyperLink ID="hlTweetText" runat="server" NavigateUrl="http://www.twitter.com/{0}/status/{1}" />
                        <asp:Literal ID="litTweetText" runat="server" />
                        <asp:HyperLink ID="hlMoreLink" runat="server" NavigateUrl="http://www.twitter.com/{0}/status/{1}" Visible="false">more</asp:HyperLink>
                    </p>
			    </div>
		    </div>
        </ItemTemplate>
    </asp:Repeater>
</div>