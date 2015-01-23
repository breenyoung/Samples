using System;

namespace NSCC.Web.Awards.Classes
{
    [Serializable]
    public class CampusVo
    {
        public string CampusCode { get; set; }
        public string CampusDescr { get; set; }
        public string Location { get; set; }
    }
}