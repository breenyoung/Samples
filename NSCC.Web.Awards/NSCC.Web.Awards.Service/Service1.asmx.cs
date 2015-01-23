using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Services;
using NSCC.Web.Awards.Classes;
using NSCC.Web.Awards.DataAccess;


namespace NSCC.Web.Awards.Service
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<AwardSelection> GetAllAwards()
        {
            AwardsDal dal = new AwardsDal();
            List<AwardSelection> awards = dal.GetAllAwards();
            return awards;
        }

    }
}