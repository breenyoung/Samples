<%@ Page Title="Nova Scotia Community College - Scholarships &amp; Bursaries - {0}" Language="C#" MasterPageFile="~/MasterPages/Nscc2013.master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="NSCC.Web.Awards.Search.Detail" %>
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
    <p><a href="/">Home</a> &raquo; <a href="/admissions/">Admissions</a> &raquo; <a href="/admissions/scholarships_and_bursaries/">Scholarships &amp; Bursaries</a> &raquo; <asp:Literal runat="server" ID="litCrumbAwardName" /></p>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideNav" runat="server">
    <!-- #include virtual="/inc/navigation/Admissions_Awards.html" -->
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
    
    <h1><asp:Literal ID="litTitle" runat="server"/></h1>
    
    <div class="awardinfo">
        <p>
        <asp:Literal ID="litAmount" runat="server"/>
        &bull;
            <asp:Literal ID="litNumAwards" runat="server"/> <asp:Literal runat="server" ID="litAwardType" />
        <asp:Literal runat="server" ID="litSpecialCriteriaHeader" Visible="False">&bull; Special Criteria:</asp:Literal> 
        <asp:Literal runat="server" ID="litSpecialCriteria" Visible="False"/> 
        &bull;
        Application Deadline: <%= Deadline %>
        </p>
    </div>
    
    <div class="awardsummary">
        <p>        
            <asp:Literal id="litSummary" runat="server"/>
        </p>
    </div>

<div id="RightContentBlock">
    <ul class="sideLinks">
        <li class="applyLink"><a href="https://awardsapplication.nscc.ca/awards">Apply Online</a></li>
    </ul>
</div>
    <h2>Award Overview</h2>
    <asp:Literal ID="litDesc" runat="server"/>
    
    <h2>Eligibility Requirements</h2>
    <ul class="listheader">
        <li><asp:Literal ID="litAcademicLoad" runat="server"/> Students</li>
        <li runat="server" id="liNoProgramRestriction" Visible="False">
            Enrolled in any program
        </li>
        <li runat="server" id="liProgramRestrictions" Visible="False">
            Enrolled in one of the following programs: <asp:Literal runat="server" ID="litPrograms" />.
        </li>

        <li runat="server" id="liSpecialCriteria" Visible="False">
           Special Criteria: <asp:Literal runat="server" ID="litSpecialCriteriaList" />
        </li>

    </ul>

    <h2 runat="server" id="genericAssessmentCriteriaHeader" Visible="False">Assessment Criteria</h2>
    <asp:Literal ID="litOtherCriteria" runat="server" Visible="False"/>
    
    <h2>Application Details</h2>
    <ul class="listheader">
        <li>Application Deadline: <%= Deadline %>. You must submit an online application no later than <%= Deadline %>. The application deadline was extended (from October 18).</li>
        <asp:Repeater runat="server" ID="rpAttachments" OnItemDataBound="rpAttachments_ItemDataBound">
            <ItemTemplate>
                <li><asp:Literal runat="server" ID="litAttachment"/></li>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater runat="server" ID="rpEssayQuestions" OnItemDataBound="rpEssayQuestions_ItemDataBound">
            <ItemTemplate>
                <li>Complete Essay <%# Container.ItemIndex + 1 %>: <asp:Literal runat="server" ID="litEssayQuestion"/></li>
            </ItemTemplate>
        </asp:Repeater>
        <li id="htmlGenericFinancialInfo" runat="server" Visible="False">Complete Financial Information</li>
        <li>You must complete and/or upload all applicable required information (that applies to this award) in the Online Application.</li>
    </ul>
    
    <h2>Other Info</h2>
    <ul class="listheader">
        <li><asp:Literal runat="server" ID="litStandardPayment" /></li>
        <li runat="server" id="htmlGenericExtraCriteria" Visible="False"><asp:Literal runat="server" ID="litExtraCriteria" Visible="False" /></li>
    </ul>        

    <p class="donatedby" runat="server" id="pDonatedIntro" Visible="False">
        Award generously donated by<br />
        <!-- DB pulled img -->
        <asp:Image runat="server" ImageUrl="/img/awards/logos/{0}" ID="imgDonationLogo" Visible="False"/>
    </p>
<div class="outer-border btmMargin30 topMargin30 no-print">
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
