using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSCC.Web.Awards.Application.Awards
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string message = ConfigurationManager.AppSettings["AWARDS_ERROR_GENERIC"]; ;
                if (Request.QueryString["E"] != null && !Request.QueryString["E"].Equals(""))
                {                    
                    switch (Request.QueryString["E"])
                    {
                        case "ST":
                            message = ConfigurationManager.AppSettings["AWARDS_ERROR_EMPTY_SESSION"];
                            break;

                    }

                    
                }

                litErrorMessage.Text = message;
            }
        }
    }
}