using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSCC.Web.Awards.Search.Classes
{
    [Serializable]
    public class ProgramVo
    {
        public string ProgramCode { get; set; }
        public string ProgramDescr { get; set; }
        public List<CampusVo> Campuses { get; set; } 

        public ProgramVo()
        {
            this.Campuses = new List<CampusVo>();
        }
    }
}