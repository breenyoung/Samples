<%@ Page Title="Nova Scotia Community College - Awards" Language="C#" MasterPageFile="~/MasterPages/AwardsApplication.master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="NSCC.Web.AwardsApplication.Awards.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadTag" runat="server">
        
    <link rel="stylesheet" type="text/css" href="../inc/css/awards.css"/>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="CookieTrail" runat="server">
    <p><a href="http://www.nscc.ca">Home</a> &raquo; Awards Application</p>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
          
    <p>
        <img src="../img/designelements/student_awards_1.jpg"/>
    </p>
    
    <br/>

    <p><asp:Literal runat="server" ID="litSuccessMessage" /></p>
    
    <br/>

    <ul>
        <asp:Repeater runat="server" ID="rpSelectedAwards" OnItemDataBound="rpSelectedAwards_ItemDataBound">
            <ItemTemplate><li><asp:Literal runat="server" ID="litAwardName"/></li></ItemTemplate>
        </asp:Repeater>
    </ul>
    
    <br/>
     
    <h2>What Happens Next?</h2>

    <p>
        After you apply for award(s), you will be sent an email confirmation. Please retain this email receipt for your records. The selection process takes 4-6 weeks after the application deadline closes. 
    </p>
    
    <br/>

    <h2>Additional Applications</h2>
    <p>
        If you wish to return to the site and apply for additional awards at a later date, you may do so. However, based on the award, you may be asked to supply demographic and financial information as well as essay answers once again.  If so, information will not be transferred from an earlier submission and it will be your responsibility to ensure you complete the application again. 
    </p>
    
    <br/>

    <h2>Validation of Information</h2>
    <p>
        In some cases, you may be asked to validate the information you have included in your application to ensure you meet the award(s) eligibility requirements. Citizenship, native status, and documented disability are some examples.          
    </p>
    
    <br/>

    <h2>Further Information</h2>
    <p>
        If you wish to withdraw your application or you have general questions which are not addressed on this site, please contact the Student Awards office by phone at 1-855-825-9060 or by email at <a href="mailto:awards@nscc.ca">awards@nscc.ca</a>.
    </p>
    
    <br/>

    <p>
        Thank you for applying for a Nova Scotia Community College Student Award. 
    </p>

</asp:Content>


<asp:Content ID="Content6" ContentPlaceHolderID="HiddenElements" runat="server">
</asp:Content>

