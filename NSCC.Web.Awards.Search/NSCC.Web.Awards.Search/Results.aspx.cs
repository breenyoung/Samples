using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.DataAccess;
using NSCC.Web.Awards.Search.Classes;

namespace NSCC.Web.Awards.Search
{
    public partial class Results : System.Web.UI.Page
    {
        protected int NumResults = 0;
        protected string ResultsLabel = "results";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Request.Url.Query.Equals(""))
                {
                    AwardSearch search = SearchUtils.GetSearchFromQueryString(Request.QueryString);
                    AwardsSearchDal dal = new AwardsSearchDal();

                    if (search.HasCriteria())
                    {
                        List<string> terms = new List<string>();

                        if (!search.Keyword.Equals("%")) { terms.Add(search.Keyword); }
                        if (!search.Program.Equals("%"))
                        {
                            ProgramVo p = dal.GetProgramByCode(search.Program);
                            if (p != null) { terms.Add(p.ProgramDescr); } else { terms.Add(search.Program); }
                        }
                        if (!search.Campus.Equals("%"))
                        {
                            CampusVo c = dal.GetCampusByCode(search.Campus);
                            if (c != null) { terms.Add(c.CampusDescr); } else { terms.Add(search.Campus); }
                        }
                        if (!search.ProgramDelivery.Equals("%")) { terms.Add(search.ProgramDelivery); }
                        if (!search.ProgramYear.Equals("%")) { terms.Add(search.ProgramYear); }

                        rpSearchTerms.DataSource = terms;
                        rpSearchTerms.DataBind();                        
                    }
                    else
                    {
                        litSearchTermsLabel.Visible = false;
                    }

                    List<AwardSelection> results = dal.GetAwardsByCriteria(search);
                    rpResults.DataSource = results;
                    rpResults.DataBind();

                    NumResults = results.Count;
                    if (results.Count == 1) { ResultsLabel = "result"; }

                    hlBackTop.NavigateUrl = String.Format(hlBackTop.NavigateUrl, SearchUtils.GetQueryStringFromSearch(search));
                    hlBackBottom.NavigateUrl = String.Format(hlBackBottom.NavigateUrl, SearchUtils.GetQueryStringFromSearch(search));
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void rpSearchTerms_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                string term = (string) e.Item.DataItem;
                Literal litSearchParameter = (Literal) e.Item.FindControl("litSearchParameter");
                litSearchParameter.Text = term;
            }
        }

        protected void rpResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                AwardSelection award = (AwardSelection) e.Item.DataItem;
                HyperLink hlLink = (HyperLink) e.Item.FindControl("hlLink");
                Literal litAmount = (Literal) e.Item.FindControl("litAmount");
                Literal litNumAwards = (Literal) e.Item.FindControl("litNumAwards");
                Literal litSpecialCriteriaHeader = (Literal) e.Item.FindControl("litSpecialCriteriaHeader");
                Literal litSpecialCriteria = (Literal) e.Item.FindControl("litSpecialCriteria");
                Literal litDeadline = (Literal) e.Item.FindControl("litDeadline");
                Literal litSummary = (Literal) e.Item.FindControl("litSummary");
                Literal litAwardType = (Literal) e.Item.FindControl("litAwardType");

                hlLink.NavigateUrl = String.Format(hlLink.NavigateUrl, award.Code);
                hlLink.Text = award.DisplayName;
                litAmount.Text = "$" + award.Amount;
                litNumAwards.Text = award.NumberOfAwards.ToString();
                litAwardType.Text = (award.NumberOfAwards > 1 ? award.PlurilizeAwardType() : award.AwardType);


                if (award.Deadline != null) { litDeadline.Text = award.Deadline.ToString("MMMM dd, yyyy"); }

                /*
                if (award.SpecialCriteria.Count > 0)
                {
                    litSpecialCriteriaHeader.Visible = true;
                    string specialCriteria = string.Empty;
                    foreach (string s in award.SpecialCriteria)
                    {
                        specialCriteria += s + ", ";
                    }
                    specialCriteria = specialCriteria.TrimEnd(", ".ToCharArray());

                    litSpecialCriteria.Text = specialCriteria;
                    litSpecialCriteria.Visible = true;
                }
                */

                litSummary.Text = award.GetSummary();
            }
        }
    }
}