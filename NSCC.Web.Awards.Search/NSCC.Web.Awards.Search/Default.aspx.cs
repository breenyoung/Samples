using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.DataAccess;
using NSCC.Web.Awards.Search.Classes;
using Newtonsoft.Json;

namespace NSCC.Web.Awards.Search
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                LoadData();                
             
                if (Request.QueryString.HasKeys())
                {                    
                    PopulatePreviousSearch();
                }   
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AwardSearch search = new AwardSearch();
                if (!String.IsNullOrEmpty(tbAwardName.Text)) { search.Keyword = tbAwardName.Text; }
                if (!String.IsNullOrEmpty(hdnProgram.Value)) { search.Program = hdnProgram.Value;  }
                if (!String.IsNullOrEmpty(hdnCampus.Value)) { search.Campus = hdnCampus.Value; }
                if (!String.IsNullOrEmpty(ddlbProgramDelivery.SelectedValue)) { search.ProgramDelivery = ddlbProgramDelivery.SelectedValue; }
                if (!String.IsNullOrEmpty(ddlbProgramYear.SelectedValue)) { search.ProgramYear = ddlbProgramYear.SelectedValue; }

                /*
                foreach (ListItem i in cblSpecialCriteria.Items)
                {
                    if (i.Selected) { search.SpecialCriteria.Add(i.Value); }
                }
                */

                string queryString = SearchUtils.GetQueryStringFromSearch(search);

                Response.Redirect("Results.aspx?" + queryString);
            }
        }

        private void PopulatePreviousSearch()
        {
            ClientScriptManager csm = Page.ClientScript;

            AwardSearch previousSearch = SearchUtils.GetSearchFromQueryString(Request.QueryString);  
          
            previousSearch.ConvertValuesForWebForm();
            tbAwardName.Text = previousSearch.Keyword;
            ddlbProgramDelivery.SelectedValue = previousSearch.ProgramDelivery;
            ddlbProgramYear.SelectedValue = previousSearch.ProgramYear;

            csm.RegisterClientScriptBlock(this.GetType(), "DELIVERYAUTOSELECT", "$(document).ready(function () { NsccAwardSearch.autoFillDelivery('" + previousSearch.ProgramDelivery + "'); });", true);
            csm.RegisterClientScriptBlock(this.GetType(), "YEARAUTOSELECT", "$(document).ready(function () { NsccAwardSearch.autoFillYear('" + previousSearch.ProgramYear + "'); });", true);

            /*
            foreach (string s in previousSearch.SpecialCriteria)
            {
                foreach (ListItem l in cblSpecialCriteria.Items)
                {
                    if (l.Value.Equals(s)) { l.Selected = true; }
                }
            }
            */

            // Setup JS code to repopulate fields, etc
            
            if (!String.IsNullOrEmpty(previousSearch.Program))
            {
                csm.RegisterClientScriptBlock(this.GetType(), "PROGRAMAUTOSELECT", "$(document).ready(function () { NsccAwardSearch.autoFillProgram('" + previousSearch.Program + "'); });", true);                
            }

            if (!String.IsNullOrEmpty(previousSearch.Campus))
            {
                csm.RegisterClientScriptBlock(this.GetType(), "CAMPUSAUTOSELECT", "$(document).ready(function () { NsccAwardSearch.autoSelectCampus('" + previousSearch.Campus + "'); });", true);                
            }                       
        }

        private void LoadData()
        {
            ClientScriptManager csm = Page.ClientScript;
            
            AwardsSearchDal dal = new AwardsSearchDal();
            

            // Campuses
            List<CampusVo> campuses = dal.GetCampuses();
            string campusJson = JsonConvert.SerializeObject(campuses);
            csm.RegisterClientScriptBlock(this.GetType(), "CAMPUSJSON", "var jsonCampuses = " + campusJson + ";", true);

            // Generate program JSON
            List<ProgramVo> programs = dal.GetAllPrograms();
            string programJson = JsonConvert.SerializeObject(programs);            
            csm.RegisterClientScriptBlock(this.GetType(), "PROGRAMJSON", "var jsonPrograms = " + programJson + ";", true);
        }

    }
}