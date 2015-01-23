<%@ Page Title="Nova Scotia Community College - Awards" Language="C#" MasterPageFile="~/MasterPages/AwardsApplication.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NSCC.Web.AwardsApplication.Awards.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadTag" runat="server">
    
    <script type="text/javascript" src="../inc/js/jquery-ui-1.7.3.custom.min.js"></script>
    <script type="text/javascript" src="../inc/js/nscc.globals.js"></script>    
    <script type="text/javascript" src="../inc/js/nscc.web.awards.list.js"></script>
    
    <link rel="stylesheet" href="../inc/css/jqueryui-nscc-theme/jquery-ui-1.7.2.custom.css" type="text/css" />   
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CookieTrail" runat="server">
    <p><a href="http://www.nscc.ca">Home</a> &raquo; Awards Application</p>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
        
    <p>        
    Welcome to the NSCC Student Awards Application. Please read through the following information before completing and submitting your application. 
    </p>
    
    <br/>
    
    <h2>How to apply</h2>
    <p>
        Before starting your application, it's important to make sure you have considered the items below and that you have all of the information needed to complete your application. 
    </p>
    <br/>
    <h2>Awards Application Checklist</h2>
    <p>
        <ul class="application_checklist">
            <li><span style="font-weight: bold;">Financial information.</span> Please review the <a href="http://www.nscc.ca/admissions/scholarships_and_bursaries/financial_checklist.pdf">financial list</a> to make sure you have the necessary information to complete this section.</li>
            <li><span style="font-weight: bold;">Full address and contact information.</span> If you move or change your mailing address, please contact NSCC Student Awards office immediately with your new contact information. We want to ensure you receive all communications from our office.</li>
            <li><span style="font-weight: bold;">A secure and accessible email address.</span> Our preferred way to communicate with you is via email. If you change your email address, please notify us immediately.</li>
            <li><span style="font-weight: bold;">Your student number.</span></li>
            <li><span style="font-weight: bold;">Award name(s).</span> Take some time to review the list of awards and keep track of the ones you are applying for.</li>
            <li><span style="font-weight: bold;">Supporting documents.</span> This may include reference questionnaire(s), reference letter(s), essay(s), transcript(s) and other documents as specified in the award description(s).  You will be required to attach all documents to your application. The <a href="http://www.nscc.ca/admissions/scholarships_and_bursaries/reference_questionnaire.pdf">reference questionnaire</a> can be found on this site. It must be completed by your reference and uploaded with your application.</li>            
        </ul>
    </p>
    
	<div class="left-col left">
		<h2>Scholarships, Bursaries & Awards</h2>
		<ul class="award_list" id="tblAwards">
            <asp:Repeater runat="server" ID="rpAwards" OnItemDataBound="rpAwards_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" ID="hlAdd"><asp:Image runat="server" ImageUrl="../img/designelements/icn-addAward.png"/></asp:HyperLink>
                        &nbsp;&nbsp;
                        <span class="awardTitle"><asp:Literal runat="server" ID="litTitle"/></span>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

    

	<div id="your_application_list">
        
        <script type="text/javascript">

            $(document).ready(function () {
                var msie6 = $.browser == 'msie' && $.browser.version < 7;

                if (!msie6) {
                    var top = $('#your_application_list').offset().top - parseFloat($('#your_application_list').css('margin-top').replace(/auto/, 0));
                    $(window).scroll(function (event) {
                        // what the y position of the scroll is
                        var y = $(this).scrollTop();

                        // whether that's below the form     &amp;&amp;(y &lt; 672)
                        if ((y >= top)) {
                            // if so, ad the fixed class
                            $('#your_application_list').addClass('fixed');

                        } else {

                            $('#your_application_list').removeClass('fixed');
                            // alert("2");

                        }
                    });
                }
            });
        </script>         
	    

        <div class="right-col right" id="basketContainer">     
	        <div class="basket_header">
		        Your Application List (<span id="basketCount">0</span>)
	        </div>
		    <div class="basket_empty" id="basketempty">No awards currently selected</div>
            <div class="list_container">
		    <ul class="basket_list" id="basketawards">
		    </ul>
        </div>
            <asp:LinkButton runat="server" ID="lbSubmit" CssClass="apply-btn" style="display: none;" OnClick="lbSubmit_Click" />		
        </div>
	</div>

</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="HiddenElements" runat="server">
    <asp:HiddenField runat="server" ID="hdnSelectedAwards" Value=""/>
    <asp:HiddenField runat="server" ID="hdnSessionState" Value=""/>

</asp:Content>

