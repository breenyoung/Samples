using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.DataAccess;

namespace NSCC.Web.Awards.Search
{
    public partial class az : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllAwards();
            }
        }

        protected void rpAwards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                AwardSelection award = (AwardSelection)e.Item.DataItem;
                HyperLink hlLink = (HyperLink)e.Item.FindControl("hlLink");
                Literal litAmount = (Literal)e.Item.FindControl("litAmount");
                Literal litNumAwards = (Literal)e.Item.FindControl("litNumAwards");
                Literal litSpecialCriteriaHeader = (Literal)e.Item.FindControl("litSpecialCriteriaHeader");
                Literal litSpecialCriteria = (Literal)e.Item.FindControl("litSpecialCriteria");
                Literal litDeadline = (Literal)e.Item.FindControl("litDeadline");
                Literal litSummary = (Literal)e.Item.FindControl("litSummary");
                Literal litAwardType = (Literal)e.Item.FindControl("litAwardType");

                hlLink.NavigateUrl = String.Format(hlLink.NavigateUrl, award.Code);
                hlLink.Text = award.DisplayName;
                litAmount.Text = "$" + award.Amount;
                litNumAwards.Text = award.NumberOfAwards.ToString();
                litAwardType.Text = (award.NumberOfAwards > 1 ? award.PlurilizeAwardType() : award.AwardType);

                if (award.Deadline != null) { litDeadline.Text = award.Deadline.ToString("MMMM dd, yyyy"); }

                litSummary.Text = award.GetSummary();
            }
        }

        private void GetAllAwards()
        {
            AwardsDal dal = new AwardsDal();
            List<AwardSelection> awards = dal.GetAllAwards();

            rpAwards.DataSource = awards;
            rpAwards.DataBind();
        }
    }
}