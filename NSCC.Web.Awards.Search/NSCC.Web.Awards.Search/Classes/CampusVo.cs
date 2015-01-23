using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSCC.Web.Awards.Search.Classes
{
    [Serializable]
    public class CampusVo
    {
        public string CampusCode { get; set; }
        public string CampusDescr { get; set; }
        public string Location { get; set; }
    }
}