    <%@ Page Title="Nova Scotia Community College - Awards" Language="C#" MasterPageFile="~/MasterPages/AwardsApplication.master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="NSCC.Web.AwardsApplication.Awards.Application" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadTag" runat="server">
    <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js"></script>        
    <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/additional-methods.min.js"></script>
    <script type="text/javascript" src="../inc/js/jquery-ui-1.7.3.custom.min.js"></script>
    <script type="text/javascript" src="../inc/js/jquery.autocomplete.min.js"></script>
    <script type="text/javascript" src="../inc/js/jquery.dataTables.min.js"></script>      
    <script type="text/javascript" src="../inc/js/jquery.qtip.min.js"></script>
        
    <script type="text/javascript" src="../inc/js/nscc.globals.js"></script>
    <script type="text/javascript" src="../inc/js/nscc.web.awards.application.js"></script>
    
    
    <link rel="stylesheet" href="../inc/css/jquery.qtip2/jquery.qtip.min.css" type="text/css"/>
    <link rel="stylesheet" href="../inc/css/jqueryui-nscc-theme/jquery-ui-1.7.2.custom.css" type="text/css" />   
    <link rel="stylesheet" href="../inc/css/jquery.autocomplete/jquery.autocomplete.css" type="text/css" />    
    <link rel="stylesheet" href="../inc/css/jquery.datatables.css" type="text/css" />     
    <link rel="stylesheet" type="text/css" href="../inc/css/Forms.css"/>
<!--     <link rel="stylesheet" type="text/css" href="../inc/css/awards.css"/>  -->
    

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="CookieTrail" runat="server">
    <p><a href="http://www.nscc.ca">Home</a> &raquo; Awards Application</p>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
    
    <div id="divCannotProceed" style="display: none;">
        <p>This form cannot be completed with the current award combination, please <asp:HyperLink runat="server" NavigateUrl="Default.aspx">go back</asp:HyperLink> and revise your choices</p>

         <p><span class="reqnote">Required fields</span> are marked with a red arrow ( <img src="../img/DesignElements/img-arrow.gif" class="inlineImg" alt="arrow" /> )</p>
    </div>
        
   
    

    <div id="frmBlue">    
        
        <div id="selectedAwards" class="">

        	<script type="text/javascript">

        	    $(document).ready(function() {
        	        var msie6 = $.browser == 'msie'&& $.browser.version < 7;
			  
        	        if (!msie6) {
        	            var top = $('#selectedAwards').offset().top - parseFloat($('#selectedAwards').css('margin-top').replace(/auto/, 0));
        	            $(window).scroll(function (event) {
        	                // what the y position of the scroll is
        	                var y = $(this).scrollTop();
				  
        	                // whether that's below the form     &amp;&amp;(y &lt; 672)
        	                if ((y >= top)) {
        	                    // if so, ad the fixed class
        	                    $('#selectedAwards').addClass('fixed');

        	                } else {
					  
                            $('#selectedAwards').removeClass('fixed');
        	                // alert("2");

        	            }
        	            });
        	    }  
        	    });
        	</script>
        	
            
        <div class="right-col right" id="basketContainer">     
	        <div class="basket_header">
		        Your Application List (<asp:Literal runat="server" ID="litNumAwards" />)
	        </div>
	        <div class="list_container">
		    <ul class="basket_list" id="basketawards">
                <asp:Repeater runat="server" ID="rpSelectedAwards" OnItemDataBound="rpSelectedAwards_ItemDataBound">
                    <ItemTemplate>
                        <li>
                                       
                        <asp:LinkButton runat="server" ID="lbRemove" OnClick="lbRemove_Click" CausesValidation="False"><asp:Image runat="server" ImageUrl="../img/designelements/icn-removeAward.png"/></asp:LinkButton>
                         <asp:Literal runat="server" ID="litAwardName" />    
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
		    </ul>
		</div>
        </div>            
                
        </div>        
        <div class="left-col left">	
	    <table cellpadding="0" cellspacing="0" id="tblMain">
		    <tbody>
			    <tr class="tblHdr">
				    <td colspan="2">Personal Information</td>
			    </tr>						
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> First Name:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbFirstName" MaxLength="100" /><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Last Name:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbLastName" MaxLength="100" /><strong class="errmsg"></strong></td>
			    </tr>

			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Student Number:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbStudentNumber" MaxLength="8" /><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Email:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbEmail" MaxLength="100" /><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Address 1:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbAddress1" MaxLength="100" /><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Address 2:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbAddress2" MaxLength="100" /><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> City:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbCity" MaxLength="100" /><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Province:</td>
				    <td class="fldData">
				        <asp:DropDownList runat="server" ID="ddlbProvince"/>
                        <strong class="errmsg"></strong>
				    </td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Postal Code:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbPostalCode" MaxLength="10" /><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Phone 1:</td>
				    <td class="fldData">
				        <asp:TextBox runat="server" ID="tbPhone1" MaxLength="30" />
                        <strong class="errmsg"></strong>
				    </td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Phone 2:</td>
				    <td class="fldData">
				        <asp:TextBox runat="server" ID="tbPhone2" MaxLength="30" />
				        <strong class="errmsg"></strong>
				    </td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Campus:</td>
				    <td class="fldData"><select id="ddlbCampus" name="ddlbCampus"></select><strong class="errmsg"></strong></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Program:</td>
				    <td class="fldData">
                        <input type="text" id="tbProgram" name="tbProgram" class="lrgField" autocompletetype="Disabled" autocomplete="off" disabled="disabled" maxlength="100" />		        
                        <strong class="errmsg"></strong>
                        <a href="#" id="hlShowCampusPrograms" style="display:none;">##CAMPUS## Programs</a>
				    </td>
			    </tr>
			    <tr class="tblHdr">
				    <td colspan="2">Financial Information</td>
			    </tr>						
			    <tr class="tblHdr" id="trIncome">
				    <td colspan="2">Income</td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Pre Study:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomePreStudy" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="Pre-study period is the 8 weeks prior to the first day of classes in which you are enrolled.
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Family:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeFamily" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="This is considered as your parent(s)/guardian(s) contribution to your studies.
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Spouse / Partner:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeSpousePartner" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="This should be the gross income for your spouse or common law partner (gross income = income before tax deductions)
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Scholarships / Bursaries / Awards:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeScolarships" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="If you have received other scholarships, bursaries, awards then add them up and place the total here.
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Sponsorship or funding from an organization / government:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeSponsorship" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="Any monies received as sponsorship from an organization or government department (Employment Insurance, Department of Community Service, etc.)
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Student Loan:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeStudentLoan" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="Consider any government provincial and/or national loans/grants received.
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Other Loan:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeOtherLoan" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="This may include lines of credit, loan from a relative, etc. 
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>  			    
                <tr>
				    <td class="fldLabel"> Savings:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeSavings" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="This may include past accumulated savings, RESPs, etc. 
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Study Period Income:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeStudyPeriodIncome" Text="0" Width="50" CssClass="incometotal" />&nbsp;<a href="#" class="popuphelp" title="Study period is the ten month period you are enrolled in classes. Any anticipated part-time job income should be reported here. 
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Other Income:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbIncomeOtherIncome" Text="0" Width="50" CssClass="incometotal" /></td>
			    </tr>  
			    <tr class="tblHdr">
				    <td colspan="2">Total Income: <span id="spnTotalIncome">0</span></td>
			    </tr>
			    <tr class="tblHdr" id="trExpenses">
				    <td colspan="2">Expenses</td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Tuition:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseTuition" Text="0" Width="50" CssClass="nomultiply" />&nbsp;<a href="#" class="popuphelp" title="Consider full tuition due for the year, not including the costs listed below
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Student Health and Dental Benefits:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseHealthDental" Text="0" Width="50" CssClass="nomultiply" />&nbsp;<a href="#" class="popuphelp" title="Put $0 if you opted out of these benefits"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel">  Student Association Fee:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseStudentAssociationFee" Text="0" Width="50" CssClass="nomultiply" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> U-Pass:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseUPass" Text="0" Width="50" CssClass="nomultiply" />&nbsp;<a href="#" class="popuphelp" title="For Metro students only
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Textbooks:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseTextbooks" Text="0" Width="50" CssClass="nomultiply" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Parking:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseParking" Text="0" Width="50" CssClass="nomultiply" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Portfolio Supplies:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpensePortfolioSupplies" Text="0" Width="50" CssClass="nomultiply" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> General Supplies:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseGeneralSupplies" Text="0" Width="50" CssClass="nomultiply" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Tools:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseTools" Text="0" Width="50" CssClass="nomultiply" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Safety Certifications:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseSafetyCertifications" Text="0" Width="50" CssClass="nomultiply" />&nbsp;<a href="#" class="popuphelp" title="This includes CPR/Immunizations/Background Checks, etc. required for your program of study
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Safety Supplies:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseSafetySupplies" Text="0" Width="50" CssClass="nomultiply" />&nbsp;<a href="#" class="popuphelp" title="This includes Clothing, eyewear, shoes, etc. required for your program of study
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Medical:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseMedical" Text="0" Width="50" CssClass="nomultiply" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Other:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseOther" Text="0" Width="50" CssClass="nomultiply" />&nbsp;<a href="#" class="popuphelp" title="This covers any essential need not already covered above.
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Rent / Mortgage:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseRentMortgage" Text="0" Width="50" CssClass="multiply"  />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseRentMortgageMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months</td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Phone:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpensePhone" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpensePhoneMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months</td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Internet:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseInternet" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseInternetMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="Put $0 if included in rent
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Electricity:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseElectricity" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseElectricityMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="Put $0 if included in rent
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Heat:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseHeat" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseHeatMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="Put $0 if included in rent
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Insurance:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseInsurance" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseInsuranceMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="This includes any insurance payments for car, home, tenants insurance
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Groceries:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseGrocery" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseGroceryMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months</td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Debt Payments:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseDebtPayments" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseDebtPaymentsMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="This includes loans, student loans, credit cards, etc.
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Family Care:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseFamilyCare" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseFamilyCareMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="This includes daycare, elder care, etc. 
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Transportation:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpenseTransportation" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpenseTransportationMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="This includes bus fare, gas, car payment, etc.
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Personal:</td>
				    <td class="fldData"><asp:TextBox runat="server" ID="tbExpensePersonal" Text="0" Width="50" CssClass="multiply" />&nbsp; a month &nbsp;<asp:TextBox runat="server" ID="tbExpensePersonalMultiply" Text="0" Width="50" ReadOnly="True" CssClass="multiplyresult" />&nbsp; for 10 months&nbsp;<a href="#" class="popuphelp" title="This includes laundry, toiletries, clothing, etc. 
"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
			    </tr>                                 
			    <tr class="tblHdr">
				    <td colspan="2">Total Expenses: <span id="spnTotalExpenses">0</span></td>
			    </tr>                
			    <tr class="tblHdr" id="trFinancialNeed">
				    <td colspan="2">Your financial need is <span id="spnFinancialNeed">0</span> (number is calculated based on system subtracting expenses from revenue)</td>
			    </tr>                 
			    <tr class="tblHdr">
				    <td colspan="2">Essay Questions</td>
			    </tr>
                <tr id="trQUESTION1">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Why do you feel you are a good candidate to receive a student award and how will it impact your success as a student?&nbsp;<a href="#" class="popuphelp" title="Think about what sets you apart from others and how you will benefit from receiving this award. Tell us about the ways it will help you."><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion1" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trQUESTION2" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Provide us with an overview of: why you chose your program/field of study, your career objectives and how an NSCC education and previous experience has prepared you for this career; and why you believe you will succeed in your chosen profession upon graduation.&nbsp;<a href="#" class="popuphelp" title="What went into your decision to choose your field of study and how will your program help you achieve your goals in the future? Why do you think you will be successful?"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion2" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trQUESTION3" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Briefly detail your educational goals and career aspirations and provide a summary of your participation in extra-curricular activities and/or community service/involvement.&nbsp;<a href="#" class="popuphelp" title="Tell us about what goals you have for your education and your future career. In doing so, reflect on any experiences you’ve had with extra-curricular (school) and/or community activities."><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion3" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trQUESTION4" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Briefly detail your educational achievements at NSCC and provide insight into any barriers you have had to overcome in relation to your disability.&nbsp;<a href="#" class="popuphelp" title="What successes have you had so far at NSCC? Reflect on any hurdles you may have encountered in the past because of your disability and tell us how you have succeeded despite these."><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion4" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trQUESTION5" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Why is water resource important to you? Please articulate the importance of access to clean water and identify issues surrounding the management of water supply both domestically and in developing countries.&nbsp;<a href="#" class="popuphelp" title="Think about the importance of water resource and tell us why having access to clean water is important. Also, what issues are threatening water resource here in Canada and abroad?"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion5" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>                
                <tr id="trQUESTION6" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Outline, in a brief essay, the challenges and obstacles you have overcome in order to obtain your education. How has being an NSCC student reshaped the direction of your life? How will this award make a significant impact on your goals?&nbsp;<a href="#" class="popuphelp" title="Think about the barriers you have been faced with in the past that may have deterred you from continuing your education."><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion6" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>                
                <tr id="trQUESTION7" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Please describe your affiliation to the Credit Union system.&nbsp;<a href="#" class="popuphelp" title="Are you a member of a Credit Union? Do you or a relative work or volunteer in the credit union system? Think about any ways you might be associated."><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion7" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>                
                <tr id="trQUESTION8" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Outline the importance of completing the ALP program and your goals in continuing your education.&nbsp;<a href="#" class="popuphelp" title="Think about how the ALP program has helped you get to where you are and where you want to go in the future."><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion8" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>                
                <tr id="trQUESTION9" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Please describe one example of how you shared your story to help others better understand and accept people living with mental health disabilities.&nbsp;<a href="#" class="popuphelp" title="Think about a time when you may have let others know about your disability so that they would have a better understanding about it."><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion9" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>                
                <tr id="trQUESTION10" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Describe why you want to achieve your red seal certification?&nbsp;<a href="#" class="popuphelp" title="Why is getting a red seal important to you? How will it help you in your future career?"><asp:Image runat="server" ImageUrl="../img/designelements/icn-formHint.png"/></a></td>
                    <td class="fldData"><asp:TextBox runat="server" ID="tbQuestion10" TextMode="MultiLine" Columns="42" Rows="10" /><strong class="errmsg"></strong></td>
                </tr>                
			    <tr class="tblHdr" id="trAttachmentHeader" style="display:none;">
				    <td colspan="2">Attachments</td>
			    </tr>
                <tr id="trREFQUESTION1" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Questionnaire - Regular</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFQUESTION1"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFQUESTION2" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Questionnaire - Regular</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFQUESTION2"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFQUESTION3" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Questionnaire - Completed by Faculty</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFQUESTION3"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFQUESTION4" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Questionnaire - Completed by Faculty</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFQUESTION4"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFQUESTION5" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Questionnaire - Completed by NSCC</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFQUESTION5"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFQUESTION6" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Questionnaire - Completed by Employer or Community Organization</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFQUESTION6"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFLETTER" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Letter - Regular</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFLETTER"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFLETTER2" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Letter - Leadership</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFLETTER2"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFLETTER3" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Letter - Completed by Faculty</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFLETTER3"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFLETTER4" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Letter - Completed by Disablility Resource Facilitator</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFLETTER4"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFLETTER5" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Letter - Committement to FIeld</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFLETTER5"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trREFLETTER6" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> Reference Letter - Community Involvement</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachREFLETTER6"/><strong class="errmsg"></strong></td>
                </tr>
                <tr id="trHIGHSCHOOLTRANSCRIPT" style="display:none;">
                    <td class="fldLabel"><img src="/img/DesignElements/img-arrow.gif" alt="reqflag" class="reqFlag" /> High School Transcript (unofficial)</td>
                    <td class="fldData"><asp:FileUpload runat="server" ID="fuAttachHIGHSCHOOLTRANSCRIPT"/><strong class="errmsg"></strong></td>
                </tr>

                <tr class="tblFtr">
                    <td colspan="2">
                        <h3>Application Declaration</h3> <br/>
                        <p>This personal information is being collected under the authority of the Nova Scotia Community College (NSCC) and is protected by the Personal Information Protection and Electronic Documents Act (PIPEDA) and the Nova Scotia Freedom of Information and Protection of Privacy (FOIPOP).  It will be used for the purposes of award selection, statistical purposes, promotion, and administration by NSCC and the NSCC Foundation. If selected, any information (with the exception of the financial information section) may be disclosed to the donor of the award, published in the NSCC Foundation awards programs, and may be used in other media outlets or NSCC publications. If requested and agreed upon by the award recipient, contact information may be disclosed to the donor of the award. To read more about NSCC’s privacy policy, visit: <a href="http://www.nscc.ca/privacy.asp" target="_BLANK">http://www.nscc.ca/privacy.asp</a>.</p>    
                        <br /><p>By checking the box below, you agree that the information you provide in your application is true to the best of your knowledge and you understand that if selected, you may be required to submit relevant supporting documents as deemed necessary by the award selections committee (copies of utility bills, rental lease agreements, etc.). If at any time you no longer meet award criteria or eligibility requirements, due to withdrawal or other reasons, any payment of an NSCC award will be withheld.</p>
                        <asp:CheckBox runat="server" ID="cbAgreeToTerms" Text="Yes, I agree to these terms."/>
                        <strong class="errmsg" style="text-align: center;"></strong>
                    </td>
                </tr>

                <tr class="tblFtr">   						                
                    <td colspan="2">
                    <asp:LinkButton runat="server" ID="lbCancel" OnClick="lbCancel_Click">Cancel</asp:LinkButton>                                                
                    <asp:LinkButton runat="server" ID="btnSubmit" OnClick="btnSubmit_click" CssClass="btn-submission-lrg" />                                                                
                    </td>    
                </tr>

		    </tbody>
	    </table>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="HiddenElements" runat="server">
    <asp:HiddenField runat="server" ID="hdnCampus" Value=""/>
    <asp:HiddenField runat="server" ID="hdnProgram" Value=""/>
    <asp:HiddenField runat="server" ID="hdnCampusName" Value=""/>
    <asp:HiddenField runat="server" ID="hdnProgramName" Value=""/>
    <asp:HiddenField runat="server" ID="hdnTotalIncome" Value="0"/>
    <asp:HiddenField runat="server" ID="hdnTotalExpenses" Value="0"/>
    <asp:HiddenField runat="server" ID="hdnFinancialNeed" Value="0"/>
    
    
    <!-- START DIVS USED FOR MODAL DIALOGS -->
    <div id="divCampusPrograms" title="Campus Programs" class="allprograms">
        <table id="tblCampusPrograms" border="0" style="width: 565px;">
            <thead><tr><th></th></tr></thead>
            <tbody id="tbodyCampusPrograms"></tbody>
        </table>
        <a href="#" id="btnCampusProgramsCancel" class="btnCampusProgramsCancel"><img src="../img/DesignElements/btn-back-to-application.png" alt="Back to Application" class="btnDialog" /></a>
    </div>    
    <!-- END DIVS USED FOR MODAL DIALOGS -->

</asp:Content>


