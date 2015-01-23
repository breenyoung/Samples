using System;
using System.Collections.Generic;

namespace NSCC.Web.Awards.Classes
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