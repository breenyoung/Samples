<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Nscc2013.master" AutoEventWireup="true" CodeBehind="az.aspx.cs" Inherits="NSCC.Web.Awards.Search.az" %>
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
    <p><a href="/">Home</a> &raquo; <a href="/admissions/">Admissions</a> &raquo; <a href="/admissions/scholarships_and_bursaries/">Scholarships &amp; Bursaries</a> &raquo; A to Z: Awards</p>    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideNav" runat="server">
    <!-- #include virtual="/inc/navigation/Admissions_Awards.html" -->    
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
    
    <p>
        Some intro text
    </p>
    

    <asp:repeater ID="rpAwards" runat="server" OnItemDataBound="rpAwards_ItemDataBound">
        <ItemTemplate>
            <div class="awardResultSummary">                
                <asp:HyperLink runat="server" ID="hlLink" NavigateUrl="Detail.aspx?I={0}" />
                <asp:Literal runat="server" ID="litAmount" /> &bull; <asp:Literal runat="server" ID="litNumAwards" /> <asp:Literal runat="server" ID="litAwardType" /> <asp:Literal runat="server" ID="litSpecialCriteriaHeader" Visible="False">&bull; Special Criteria:</asp:Literal> <asp:Literal runat="server" ID="litSpecialCriteria" Visible="False"/> &bull; Application Deadline: <asp:Literal runat="server" ID="litDeadline" /> ... <asp:Literal runat="server" ID="litSummary" />
            </div>
        </ItemTemplate>
    </asp:repeater>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="RatingWidget" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="HiddenElements" runat="server">
</asp:Content>
