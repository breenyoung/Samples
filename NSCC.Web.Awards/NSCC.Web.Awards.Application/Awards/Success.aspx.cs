using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.Managers;


namespace NSCC.Web.AwardsApplication.Awards
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                litSuccessMessage.Text = ConfigurationManager.AppSettings["AWARDS_SUCCESS_MESSAGE"];

                AwardManager awardManager = new AwardManager();
                List<AwardSelection> selectedAwards = awardManager.GetAwardsFromSession();
                rpSelectedAwards.DataSource = selectedAwards;
                rpSelectedAwards.DataBind();

                bool clearBasketOnSuccess = true;
                Boolean.TryParse(ConfigurationManager.AppSettings["AWARDS_CLEAR_BASKET_ONSUCCESS"], out clearBasketOnSuccess);

                if (clearBasketOnSuccess)
                {
                    awardManager.RemoveAllAwardsFromSession();
                }
            }
        }

        protected void rpSelectedAwards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                AwardSelection a = (AwardSelection) e.Item.DataItem;
                Literal litAwardName = (Literal) e.Item.FindControl("litAwardName");

                litAwardName.Text = a.DisplayName;
            }
        }

    }
}