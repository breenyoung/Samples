<%@ Page Title="Nova Scotia Community College - Awards" Language="C#" MasterPageFile="~/MasterPages/AwardsApplication.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="NSCC.Web.Awards.Application.Awards.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadTag" runat="server">
        
    <link rel="stylesheet" type="text/css" href="../inc/css/awards.css"/>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="CookieTrail" runat="server">
    <p><a href="http://www.nscc.ca">Home</a> &raquo; Awards Application</p>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
          
    <p><asp:Literal runat="server" ID="litErrorMessage" /></p>
    
    <br/>
    
    <asp:HyperLink runat="server" NavigateUrl="~/Awards/Default.aspx">Awards Home</asp:HyperLink>

</asp:Content>


<asp:Content ID="Content6" ContentPlaceHolderID="HiddenElements" runat="server">
</asp:Content>