using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSCC.Web.Awards.Managers;
using NSCC.Web.AwardsApplication.Classes;
using AwardSelection = NSCC.Web.Awards.Classes.AwardSelection;


namespace NSCC.Web.AwardsApplication.Awards
{
    public partial class Default : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAwards();
            }
        }

        protected void rpAwards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                AwardSelection award = (AwardSelection) e.Item.DataItem;
                Literal litTitle = (Literal) e.Item.FindControl("litTitle");
                //Literal litDesc = (Literal) e.Item.FindControl("litDesc");
                HyperLink hlAdd = (HyperLink) e.Item.FindControl("hlAdd");

                litTitle.Text = award.DisplayName;
                //litDesc.Text = award.Description;
                hlAdd.NavigateUrl = award.Code;
            }
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {

            bool debugMode = Boolean.Parse(ConfigurationManager.AppSettings["AWARDS_DEBUG_MODE"]);
            bool directDataAccess = Boolean.Parse(ConfigurationManager.AppSettings["AWARDS_DIRECT_DATA_ACCESS"]);

            AwardManager awardManager = new AwardManager();

            List<AwardSelection> selectedAwards = new List<AwardSelection>();

            string rawAwards = hdnSelectedAwards.Value.TrimEnd(":::".ToCharArray());
            string[] awards = rawAwards.Split(":::".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < awards.Length; i++)
            {
                AwardSelection a = awardManager.GetAwardById(awards[i], debugMode, directDataAccess);
                if (a != null)
                {
                    selectedAwards.Add(a);
                }
            }

            
            awardManager.AddAwardsToSession(selectedAwards);

            Response.Redirect("Application.aspx");
        }

        private void LoadAwards()
        {
            bool debugMode = Boolean.Parse(ConfigurationManager.AppSettings["AWARDS_DEBUG_MODE"]);
            bool directDataAccess = Boolean.Parse(ConfigurationManager.AppSettings["AWARDS_DIRECT_DATA_ACCESS"]);

            AwardManager awardManager = new AwardManager();
            rpAwards.DataSource = awardManager.GetAllAwards(debugMode, directDataAccess);
            rpAwards.DataBind();

            // Restore any selections made that are in session already
            List<AwardSelection> selectedAwards = awardManager.GetAwardsFromSession();
            StringBuilder sb = new StringBuilder();
            foreach (AwardSelection a in selectedAwards)
            {
                sb.Append(a.Code + ":::");
            }
            hdnSessionState.Value = sb.ToString().TrimEnd(":::".ToCharArray());

        }
    }
}