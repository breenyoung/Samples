<%@ Page Title="Nova Scotia Community College - Scholarships &amp; Bursaries" Language="C#" MasterPageFile="~/MasterPages/Nscc2013.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NSCC.Web.Awards.Search.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadTag" runat="server">
    
    <script type="text/javascript" src="/inc/js/jquery-ui-1.7.3.custom.min.js"></script>
    <script type="text/javascript" src="/inc/js/jquery.autocomplete.min.js"></script>
    <script type="text/javascript" src="/inc/js/jquery.dataTables.min.js"></script>  
    <script type="text/javascript" src="/inc/js/nscc.globals.js"></script>
    <script type="text/javascript" src="/inc/js/nscc.web.awards.search.js"></script>
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
    
    <link rel="stylesheet" href="/inc/css/jqueryui-nscc-theme/jquery-ui-1.7.2.custom.css" type="text/css" />   
    <link rel="stylesheet" href="/inc/css/jquery.autocomplete/jquery.autocomplete.css" type="text/css" />
    <link rel="stylesheet" href="/inc/css/jquery.datatables.css" type="text/css" />        
    <link rel="stylesheet" href="/inc/css/testdrive.css" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="GlobalContainer" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SideNav" runat="server">
    <!-- #include virtual="/inc/navigation/Admissions_Awards.html" -->
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CookieTrail" runat="server">
    <p><a href="/">Home</a> &raquo; <a href="/admissions/">Admissions</a> &raquo; Scholarships &amp; Bursaries</p>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
    
<h1>Scholarships, Bursaries &amp; Awards</h1>
<p>Education and living expenses can be a challenge for many students. That's why we've created a student awards program that provides financial support while recognizing the diversity and needs of our students and celebrates their achievements.</p>    
    
<p>NSCC offers many different types of awards for students - some are specific to a campus, program, or year of study, while others are open to everyone. Awards are available throughout the year (with specific application deadlines in the Fall, Winter and Spring).</p>

<h2>Search Awards</h2>
    <div id="defaultAwardSearch" class="outer-border">   
        
        <asp:Panel runat="server" DefaultButton="btnSubmit">
            
            <label for="tbAwardName">Keyword (Awards Title)</label>
            <asp:TextBox runat="server" ID="tbAwardName" MaxLength="100" />
            
            <label for="ddlbCampus">Campus</label>
            <select id="ddlbCampus" name="ddlbCampus">
            </select>
                    
            <label for="tbProgram">Program</label>
            <input type="text" id="tbProgram" name="tbProgram" /><br />
            <div id="showAllPrograms"><a href="#" id="hlShowAllPrograms">All Programs</a>
		    <span>
			    <span id="spnLinkDivide" class="nodisplay"> | </span>
			    <a href="#" id="hlShowCampusPrograms" class="nodisplay">##CAMPUS## Programs</a>
		    </span>
            </div>

        
            <label for="ddlbProgramDelivery">Program Delivery</label>
            <asp:DropDownList runat="server" ID="ddlbProgramDelivery">
                <asp:ListItem Value="">Select Delivery...</asp:ListItem>
                <asp:ListItem Value="Full-time">Full-time</asp:ListItem>
                <asp:ListItem Value="Part-time">Part-time</asp:ListItem>
            </asp:DropDownList>
        
            <label for="ddlbProgramYear">Program Year</label>
            <asp:DropDownList runat="server" ID="ddlbProgramYear">
                <asp:ListItem Value="">Select Year...</asp:ListItem>
                <asp:ListItem Value="Year 1">Year 1</asp:ListItem>
                <asp:ListItem Value="Year 2">Year 2</asp:ListItem>
                <asp:ListItem Value="Year 3">Year 3</asp:ListItem>
            </asp:DropDownList>       
        
            <!--
            <label for="cblSpecialCriteria">Special Criteria</label>
            <asp:CheckBoxList runat="server" ID="cblSpecialCriteria" RepeatColumns="2" RepeatLayout="Table">
                <asp:ListItem Value="African Nova Scotian">African Nova Scotian</asp:ListItem>
                <asp:ListItem Value="Female Only">Female</asp:ListItem>
                <asp:ListItem Value="First Nations">First Nations</asp:ListItem>
                <asp:ListItem Value="Learning Disability">Learning Disability</asp:ListItem>
                <asp:ListItem Value="Mature Student">Mature Student</asp:ListItem>
            </asp:CheckBoxList>
            -->
                
            <asp:LinkButton runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Cssclass="btnSubmit">Search</asp:LinkButton>                                                                
        </asp:Panel>
    </div>
    
<h2>Awards Questions</h2>
<p>1-855-825-9060<br />
<script type="text/javascript"><!--
function escramble()
{
 var a,b,c,d,e
 a='<a href=\"mai'
 b='awards'
 c='\">'
 a+='lto:'
 b+='@'
 e='</a>'
 b+='nscc'
 b+='.'
 b+='ca'
 d=b
 document.write(a+b+c+d+e)
}
escramble()//--></script></p>
<p><a href="http://facebook.com/NSCCStudentAwards"><img src="/img/Icons/icon_facebook_35x35.gif" width="35" height="35" border="0" hspace="0" vspace="0" alt="Facebook" /></a> &nbsp;&nbsp; <a href="http://twitter.com/@NSCCAwards"><img src="/img/Icons/icon_twitter_35x35.gif" width="35" height="35" border="0" hspace="0" vspace="0" alt="Twitter" /></a>
    
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="RatingWidget" runat="server">
    <!-- Content Rating Widget -->
    <!--#include virtual="/inc/PageRatingWidget/PageRatingWidget.html"-->
    <!-- End Content Rating Widget -->
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="HiddenElements" runat="server">
    <asp:HiddenField runat="server" ID="hdnCampus" Value=""/>
    <asp:HiddenField runat="server" ID="hdnProgram" Value=""/>
    <asp:HiddenField runat="server" ID="hdnCampusName" Value=""/>
    <asp:HiddenField runat="server" ID="hdnProgramName" Value=""/>
    
    <!-- START DIVS USED FOR MODAL DIALOGS -->
    <div id="divAllPrograms" title="All Programs" class="allprograms">
        <table id="tblAllPrograms" border="0">
            <tbody id="tbodyAllPrograms"></tbody>
        </table>
        <a href="#" id="btnAllProgramsCancel"><img src="/img/DesignElements/btn-back-to-application.png" alt="Back to Search" class="btnDialog"/></a>
    </div>    

    <div id="divCampusPrograms" title="Campus Programs" class="allprograms">
        <table id="tblCampusPrograms" border="0">
            <thead><tr><th></th></tr></thead>
            <tbody id="tbodyCampusPrograms"></tbody>
        </table>
        <a href="#" id="btnCampusProgramsCancel" class="btnCampusProgramsCancel"><img src="/img/DesignElements/btn-back-to-application.png" alt="Back to Search" class="btnDialog" /></a>
    </div>    
    <!-- END DIVS USED FOR MODAL DIALOGS -->    

</asp:Content>
