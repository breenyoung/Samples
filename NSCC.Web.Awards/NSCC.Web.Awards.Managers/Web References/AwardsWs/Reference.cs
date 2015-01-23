﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18052.
// 
#pragma warning disable 1591

namespace NSCC.Web.Awards.Managers.AwardsWs {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllAwardsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service1() {
            this.Url = global::NSCC.Web.Awards.Managers.Properties.Settings.Default.NSCC_Web_Awards_Managers_AwardsWs_Service1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetAllAwardsCompletedEventHandler GetAllAwardsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllAwards", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public AwardSelection[] GetAllAwards() {
            object[] results = this.Invoke("GetAllAwards", new object[0]);
            return ((AwardSelection[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllAwardsAsync() {
            this.GetAllAwardsAsync(null);
        }
        
        /// <remarks/>
        public void GetAllAwardsAsync(object userState) {
            if ((this.GetAllAwardsOperationCompleted == null)) {
                this.GetAllAwardsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllAwardsOperationCompleted);
            }
            this.InvokeAsync("GetAllAwards", new object[0], this.GetAllAwardsOperationCompleted, userState);
        }
        
        private void OnGetAllAwardsOperationCompleted(object arg) {
            if ((this.GetAllAwardsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllAwardsCompleted(this, new GetAllAwardsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18054")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class AwardSelection {
        
        private string codeField;
        
        private string displayNameField;
        
        private string descriptionField;
        
        private bool requireIncomeInfoField;
        
        private int numberOfAttachmentsField;
        
        private AwardAttachment[] attachmentsRequiredField;
        
        private string[] eligibleCampusesField;
        
        private string[] eligibleProgramsField;
        
        private string[] essayQuestionsField;
        
        /// <remarks/>
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        public string DisplayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public bool RequireIncomeInfo {
            get {
                return this.requireIncomeInfoField;
            }
            set {
                this.requireIncomeInfoField = value;
            }
        }
        
        /// <remarks/>
        public int NumberOfAttachments {
            get {
                return this.numberOfAttachmentsField;
            }
            set {
                this.numberOfAttachmentsField = value;
            }
        }
        
        /// <remarks/>
        public AwardAttachment[] AttachmentsRequired {
            get {
                return this.attachmentsRequiredField;
            }
            set {
                this.attachmentsRequiredField = value;
            }
        }
        
        /// <remarks/>
        public string[] EligibleCampuses {
            get {
                return this.eligibleCampusesField;
            }
            set {
                this.eligibleCampusesField = value;
            }
        }
        
        /// <remarks/>
        public string[] EligiblePrograms {
            get {
                return this.eligibleProgramsField;
            }
            set {
                this.eligibleProgramsField = value;
            }
        }
        
        /// <remarks/>
        public string[] EssayQuestions {
            get {
                return this.essayQuestionsField;
            }
            set {
                this.essayQuestionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18054")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class AwardAttachment {
        
        private string attachmentTypeField;
        
        private string filenameField;
        
        /// <remarks/>
        public string AttachmentType {
            get {
                return this.attachmentTypeField;
            }
            set {
                this.attachmentTypeField = value;
            }
        }
        
        /// <remarks/>
        public string Filename {
            get {
                return this.filenameField;
            }
            set {
                this.filenameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetAllAwardsCompletedEventHandler(object sender, GetAllAwardsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllAwardsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllAwardsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AwardSelection[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AwardSelection[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591