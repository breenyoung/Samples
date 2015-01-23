<%@ Page Title="Nova Scotia Community College - Scholarships &amp; Bursaries - Search Results: Awards" Language="C#" MasterPageFile="~/MasterPages/Nscc2013.master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="NSCC.Web.Awards.Search.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadTag" runat="server">
    <script type="text/javascript">
        $(document).ready(function () 
        { 
            NsccTopNavControl.setNav(
            [
                    {selector: "#topmenu .Admissions", styleClass: "selected"},
                    {selector: "#SideNavLevellist .Scholarships", styleClass: "selected"}
            ]
            ); 
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="GlobalContainer" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CookieTrail" runat="server">
    <p><a href="/">Home</a> &raquo; <a href="/admissions/">Admissions</a> &raquo; <a href="/admissions/scholarships_and_bursaries/">Scholarships &amp; Bursaries</a> &raquo; Search Results: Awards</p>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideNav" runat="server">
    <!-- #include virtual="/inc/navigation/Admissions_Awards.html" -->
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
<h1>Scholarships, Bursaries &amp; Awards</h1>
    
<h2 class="AwardsH2">Search Results: Awards</h2>

    <div class="awardsResults">
        <%= NumResults %> <%= ResultsLabel %> |
        <asp:HyperLink runat="server" ID="hlBackTop" NavigateUrl="Default.aspx?{0}">Back to Search</asp:HyperLink>
    </div>
    
    <div class="awardsTerms">
        <strong><asp:Literal ID="litSearchTermsLabel" runat="server">Search Terms:</asp:Literal></strong>
        <asp:Repeater runat="server" ID="rpSearchTerms" OnItemDataBound="rpSearchTerms_ItemDataBound">
            <ItemTemplate>
                <span><asp:Literal runat="server" ID="litSearchParameter" /></span>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    

        <asp:Repeater runat="server" ID="rpResults" OnItemDataBound="rpResults_ItemDataBound">
            <ItemTemplate>
                <div class="awardResultSummary">                
                    <asp:HyperLink runat="server" ID="hlLink" NavigateUrl="Detail.aspx?I={0}" /><br />
                    <asp:Literal runat="server" ID="litAmount" /> &bull; <asp:Literal runat="server" ID="litNumAwards" /> <asp:Literal runat="server" ID="litAwardType" /> <asp:Literal runat="server" ID="litSpecialCriteriaHeader" Visible="False">&bull; Special Criteria:</asp:Literal> <asp:Literal runat="server" ID="litSpecialCriteria" Visible="False"/> &bull; Application Deadline: <asp:Literal runat="server" ID="litDeadline" /> ... <asp:Literal runat="server" ID="litSummary" />            
                </div>
            </ItemTemplate>
        </asp:Repeater>

    <div class="awardsResults resultsBtm">
        <%= NumResults %> <%= ResultsLabel %> |
        <asp:HyperLink runat="server" ID="hlBackBottom" NavigateUrl="Default.aspx?{0}">Back to Search</asp:HyperLink>
    </div>
<div class="outer-border btmMargin30 no-print">
    <div class="gen-nextsteps">
    <h2>Next Steps</h2> 
    <ol>
        <li class="num-one-pink"><div><h3>Apply</h3><a href="/admissions/scholarships_and_bursaries/applying.asp">Application Instructions &amp; Tips</a> &bull; <a href="https://awardsapplication.nscc.ca/awards/" onclick="javascript: pageTracker._trackPageview('/ExternalLink/awardsapplication.nscc.ca/awards/'); ">Apply Online</a></div></li>
        <li class="num-two-pink"><div><h3>Application Support Documents</h3><a href="/admissions/scholarships_and_bursaries/FAQ.pdf" onclick="javascript: pageTracker._trackPageview('/download/FAQ.pdf'); " target="_blank">FAQ</a> &bull; <a href="/admissions/scholarships_and_bursaries/financial_checklist.pdf" onclick="javascript: pageTracker._trackPageview('/download/financial_checklist.pdf'); " target="_blank">Financial Checklist</a> &bull; <a href="/admissions/scholarships_and_bursaries/reference_questionnaire.pdf" onclick="javascript: pageTracker._trackPageview('/download/reference_questionnaire.pdf'); " target="_blank">Reference Questionnaire</a></div></li>
        <li class="num-three-pink"><div><h3>See All Awards (A-Z)</h3><a href="/admissions/scholarships_and_bursaries/Results.aspx?K=%25&amp;P=%25&amp;C=%25&amp;D=%25&amp;Y=%25">Awards (A-Z)</a> &bull; <a href="/admissions/scholarships_and_bursaries/entrance_awards.asp">Entrance Awards</a></div></li>
    </ol>
    </div>
</div>  
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="RatingWidget" runat="server">
    <!-- Content Rating Widget -->
    <!--#include virtual="/inc/PageRatingWidget/PageRatingWidget.html"-->
    <!-- End Content Rating Widget -->
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="HiddenElements" runat="server">
</asp:Content>
