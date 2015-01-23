<%@ Page Language="C#" MasterPageFile="~/MasterPages/PrintFriendly.Master" AutoEventWireup="true" CodeBehind="ApplicationPdf.aspx.cs" Inherits="NSCC.Web.AwardsApplication.Awards.ApplicationPdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadTag" runat="server">
    <script type="text/javascript" src="../inc/js/nscc.web.awards.pdf.js"></script>
    <link rel="stylesheet" type="text/css" href="../inc/css/Forms.css"/>
    <link rel="stylesheet" type="text/css" href="../inc/css/awards.css"/>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="GlobalContainer" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Body" runat="server">
    
    <h1>Award Application: <asp:Literal runat="server" ID="litAwardName" /></h1>

<div id="frmBlue">    
        
	    <table cellpadding="0" cellspacing="0" id="tblMain">
		    <tbody>
			    <tr class="tblHdr">
				    <td colspan="2">Personal Information</td>
			    </tr>						
			    <tr>
				    <td class="fldLabel">First Name:</td>
			        <td class="fldData"><asp:Literal runat="server" ID="litFirstName" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Last Name:</td>
			        <td class="fldData"><asp:Literal runat="server" ID="litLastName" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Student Number:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litStudentNumber" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Email:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litEmail" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Address 1:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litAddress1" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Address 2:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litAddress2" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">City:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litCity" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Province:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litProvince"/></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Postal Code:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litPostalCode" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Phone 1:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litPhone1" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Phone 2:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litPhone2" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Campus:</td>
			        <td class="fldData"><asp:Literal runat="server" ID="litCampus" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel">Program:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litProgram" /></td>
			    </tr>
			    <tr class="tblHdr" id="trIncome">
				    <td colspan="2">Income</td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Pre Study:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomePreStudy" /></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Family:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeFamily" /></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Spouse / Partner:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeSpousePartner" /></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Scholarships / Bursaries / Awards:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeScolarships" /></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Sponsorship or funding from an organization / government:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeSponsorship" /></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Student Loan:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeStudentLoan" /></td>
			    </tr>                
			    <tr>
				    <td class="fldLabel"> Other Loan:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeOtherLoan" /></td>
			    </tr>  			    
                <tr>
				    <td class="fldLabel"> Savings:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeSavings" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Study Period Income:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeStudyPeriodIncome" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Other Income:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litIncomeOtherIncome" /></td>
			    </tr>  
			    <tr>
			        <td class="fldLabel"> Total Income:</td>
			        <td class="fldData"><asp:Literal runat="server" ID="litTotalIncome" /></td>
			    </tr>
			    <tr class="tblHdr" id="trExpenses">
				    <td colspan="2">Expenses</td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Tuition:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseTuition" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Student Health and Dental Benefits:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseHealthDental" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel">  Student Association Fee:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseStudentAssociationFee" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> U-Pass:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseUPass" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Textbooks:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseTextbooks" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> Parking:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseParking" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Portfolio Supplies:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpensePortfolioSupplies" /></td>
			    </tr>  
			    <tr>
				    <td class="fldLabel"> General Supplies:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseGeneralSupplies" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Tools:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseTools" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Safety Certifications:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseSafetyCertifications" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Safety Supplies:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseSafetySupplies" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Medical:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseMedical" /></td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Other:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseOther" /></td>
			    </tr>
			    <tr>
				    <td class="fldLabel"> Rent / Mortgage:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseRentMortgage" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseRentMortgageMultiply" />&nbsp; for 10 months</td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Phone:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpensePhone" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpensePhoneMultiply" />&nbsp; for 10 months</td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Internet:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseInternet" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseInternetMultiply" />&nbsp; for 10 months</td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Electricity:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseElectricity" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseElectricityMultiply" />&nbsp; for 10 months</td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Heat:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseHeat" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseHeatMultiply" />&nbsp; for 10 months</td>
			    </tr>                  
			    <tr>
				    <td class="fldLabel"> Insurance:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseInsurance" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseInsuranceMultiply" />&nbsp; for 10 months</td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Groceries:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseGrocery" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseGroceryMultiply" />&nbsp; for 10 months</td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Debt Payments:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseDebtPayments" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseDebtPaymentsMultiply" />&nbsp; for 10 months</td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Family Care:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseFamilyCare" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseFamilyCareMultiply" />&nbsp; for 10 months</td>
			    </tr>                                 
			    <tr>
				    <td class="fldLabel"> Transportation:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpenseTransportation" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpenseTransportationMultiply" />&nbsp; for 10 months</td>
			    </tr> 
			    <tr>
				    <td class="fldLabel"> Personal:</td>
				    <td class="fldData"><asp:Literal runat="server" ID="litExpensePersonal" />&nbsp; a month &nbsp;<asp:Literal runat="server" ID="litExpensePersonalMultiply" />&nbsp; for 10 months</td>
			    </tr>                                 
			    <tr>
			        <td class="fldLabel"> Total Expenses:</td>
			        <td class="fldData"><asp:Literal runat="server" ID="litTotalExpenses" /></td>
			    </tr>                
			    <tr>
                    <td class="fldLabel"> Financial Need:</td>
			        <td class="fldData"><asp:Literal runat="server" ID="litFinancialNeed" /></td>
			    </tr>                 
			    <tr class="tblHdr">
				    <td colspan="2">Essay Questions</td>
			    </tr>
                <tr id="trQUESTION1">
                    <td class="fldLabel">Why do you feel you are a good candidate to receive a student award and how will it impact your success as a student?</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion1" /></td>
                </tr>
                <tr id="trQUESTION2" style="display:none;">
                    <td class="fldLabel">Provide us with an overview of: why you chose your program/field of study, your career objectives and how an NSCC education and previous experience has prepared you for this career; and why you believe you will succeed in your chosen profession upon graduation.</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion2" /></td>
                </tr>
                <tr id="trQUESTION3" style="display:none;">
                    <td class="fldLabel">Briefly detail your educational goals and career aspirations and provide a summary of your participation in extra-curricular activities and/or community service/involvement.</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion3" /></td>
                </tr>
                <tr id="trQUESTION4" style="display:none;">
                    <td class="fldLabel">Briefly detail your educational achievements at NSCC and provide insight into any barriers you have had to overcome in relation to your disability.</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion4" /></td>
                </tr>
                <tr id="trQUESTION5" style="display:none;">
                    <td class="fldLabel">Why is water resource important to you? Please articulate the importance of access to clean water and identify issues surrounding the management of water supply both domestically and in developing countries.</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion5" /></td>
                </tr>                
                <tr id="trQUESTION6" style="display:none;">
                    <td class="fldLabel">Outline, in a brief essay, the challenges and obstacles you have overcome in order to obtain your education. How has being an NSCC student reshaped the direction of your life? How will this award make a significant impact on your goals?</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion6" /></td>
                </tr>                
                <tr id="trQUESTION7" style="display:none;">
                    <td class="fldLabel">Please describe your affiliation to the Credit Union system.</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion7" /></td>
                </tr>                
                <tr id="trQUESTION8" style="display:none;">
                    <td class="fldLabel">Outline the importance of completing the ALP program and your goals in continuing your education.</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion8" /></td>
                </tr>                
                <tr id="trQUESTION9" style="display:none;">
                    <td class="fldLabel">Please describe one example of how you shared your story to help others better understand and accept people living with mental health disabilities.</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion9" /></td>
                </tr>                
                <tr id="trQUESTION10" style="display:none;">
                    <td class="fldLabel">Describe why you want to achieve your red seal certification?</td>
                    <td class="fldData"><asp:Literal runat="server" ID="litQuestion10" /></td>
                </tr>                
                <tr class="tblFtr">   						                
                    <td colspan="2">&nbsp;</td>
                </tr>
		    </tbody>
	    </table>
    </div>
    
</asp:Content>
