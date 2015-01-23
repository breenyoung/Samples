using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Caching;
using Dapper;
using NSCC.Web.Awards.Classes;


namespace NSCC.Web.Awards.DataAccess
{
    public class AwardsSearchDal
    {
        private readonly string _connectionString 
            = System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsConnectionString"].ConnectionString;

        public List<AwardSelection> GetAwardsByCriteria(AwardSearch search)
        {
            using (var conn = new SqlConnection(this._connectionString))
            {

                // If they chose 'Full-time' for AcademicLoad, add 'All' to search
                string academicLoadQuery = "AND (CombinedAwards.AcademicLoad LIKE @ProgramDelivery OR CombinedAwards.AcademicLoad = 'All') ";
//                if(search.ProgramDelivery.Equals(search.FullTimeIdentifier))
//                {
//                    academicLoadQuery = "AND (CombinedAwards.AcademicLoad LIKE @ProgramDelivery OR CombinedAwards.AcademicLoad = 'All') ";
//                }

                // If they chose any Year, add 'All' to search
                string statusYearQuery = "AND (CombinedAwards.StudentStatusYear LIKE @ProgramYear OR CombinedAwards.StudentStatusYear = 'All') ";
//                if (search.ProgramYear.Equals(search.WildCardOperator))
//                {
//                    statusYearQuery = "AND (CombinedAwards.StudentStatusYear LIKE @ProgramYear OR CombinedAwards.StudentStatusYear = 'All') ";
//                }

                string query = "SELECT CombinedAwards.*, Awards.AwardSchedules.deadline AS Deadline "

                            // GROSS EXTRA JOINS TO GET PROGRAMS FOR AWARD
                            + ", "
                            + " (replace(replace(replace ((SELECT AcadPlan FROM awards.awards left outer join awards.programstoawards on Awards.Awards.ListItemID = awards.programstoawards.AwardsListItemId"
                            + " left outer join awards.programs on awards.programstoawards.ProgramsListItemId = awards.programs.ListItemId"
                            + " WHERE CombinedAwards.ID = Awards.Awards.ID for XML PATH('') ), '</AcadPlan><AcadPlan>', ';#'),'</AcadPlan>', ';#'), '<AcadPlan>', ';#')) AS ProgramCodes "

                            + "FROM awards.awards AS CombinedAwards " 
                            + "INNER JOIN Awards.SchedulesToAwards ON Awards.SchedulesToAwards.AwardsListItemID = CombinedAwards.ListItemID "
                            + "INNER JOIN Awards.AwardSchedules ON Awards.SchedulesToAwards.AwardSchedulesListItemID = Awards.AwardSchedules.ListItemID "                            
                            //+ "WHERE DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.deadline "
                            + "WHERE ((Awards.AwardSchedules.Extension = 1 AND DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.extensiondeadline) OR (DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.deadline))"
                            + "AND CombinedAwards.Title LIKE @Keyword "
                            + "AND CombinedAwards.Campus LIKE @Campus "
                            + "AND Awards.AwardSchedules.Published = 1 "
                            + academicLoadQuery
                            + statusYearQuery
                            
                            ;
                /*
                if (search.SpecialCriteria.Count > 0)
                {                    
                    for (int i = 1; i <= search.SpecialCriteria.Count; i++)
                    {
                        query += " AND Awards.awards.SpecialCriteria LIKE @SC" + i;
                    }
                }
                */

                query += " ORDER BY CombinedAwards.title";

                var dbArgs = new DynamicParameters();
                foreach (var pair in search.ToDictionary(true)) dbArgs.Add(pair.Key, pair.Value);

                conn.Open();

                //var rows = conn.Query(query, new { Keyword = "%" + search.Keyword + "%", Campus = "%" + search.Campus + "%", ProgramDelivery = search.ProgramDelivery, ProgramYear = search.ProgramYear});
                var rows = conn.Query(query, dbArgs);

                List<AwardSelection> awards = rows.Select(r => Utilities.DynamicRowToAwardSelection(r)).Cast<AwardSelection>().ToList();
                
                // Filter on programs after the fact *BAD*!
                if (!search.Program.Equals(search.WildCardOperator)) { awards = FilterByProgram(search.Program, awards); }

                return awards;
            }
        }

        public AwardSelection GetAwardDetail(string code)
        {
            using (var conn = new SqlConnection(this._connectionString))
            {
                string query = "SELECT CombinedAwards.*, Awards.AwardSchedules.deadline AS Deadline "
                                
                                //+ ", ';#COOKING;#CULINARTS;#' As ProgramCodes" // TEMP
                                // GROSS EXTRA JOINS TO GET PROGRAMS FOR AWARD
                               + ", "
                               + " (replace(replace(replace ((SELECT AcadPlan FROM awards.awards left outer join awards.programstoawards on Awards.Awards.ListItemID = awards.programstoawards.AwardsListItemId"
                               + " left outer join awards.programs on awards.programstoawards.ProgramsListItemId = awards.programs.ListItemId"
                               + " WHERE CombinedAwards.ID = Awards.Awards.ID for XML PATH('') ), '</AcadPlan><AcadPlan>', ';#'),'</AcadPlan>', ';#'), '<AcadPlan>', ';#')) AS ProgramCodes"

                               + " FROM awards.awards AS CombinedAwards "
                               + "INNER JOIN Awards.SchedulesToAwards ON Awards.SchedulesToAwards.AwardsListItemID = CombinedAwards.ListItemID "
                               + "INNER JOIN Awards.AwardSchedules ON Awards.SchedulesToAwards.AwardSchedulesListItemID = Awards.AwardSchedules.ListItemID "
                               + "WHERE CombinedAwards.ID = @Id "
                               //+ "AND DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.deadline "
                               + " AND ((Awards.AwardSchedules.Extension = 1 AND DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.extensiondeadline) OR (DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0) <= Awards.AwardSchedules.deadline))"
                               + " AND Awards.AwardSchedules.Published = 1"
                            ;

                conn.Open();

                var row = conn.Query(query, new {Id = code});

                return row.Select(r => Utilities.DynamicRowToAwardSelection(r)).Cast<AwardSelection>().SingleOrDefault();
            }
        }

        public List<CampusVo> GetCampuses()
        {
            if (HttpContext.Current.Cache["AWARDS_CAMPUSES"] != null)
            {
                return (List<CampusVo>)HttpContext.Current.Cache["AWARDS_CAMPUSES"];
            }


            Service1.CurrentPrograms svc = new Service1.CurrentPrograms();
            List<CampusVo> campuses = GeneratedClassToCampusVo(svc.GetAllCampuses(-1));

            HttpContext.Current.Cache.Add("AWARDS_CAMPUSES",
                                          campuses,
                                          null,
                                          DateTime.Now.AddMinutes(1440),
                                          Cache.NoSlidingExpiration,
                                          CacheItemPriority.Normal,
                                          null);

            return campuses;
        }

        public CampusVo GetCampusByCode(string code)
        {
            List<CampusVo> campuses = this.GetCampuses();

            return campuses.SingleOrDefault(c => c.CampusCode.Equals(code));
        }

        public List<ProgramVo> GetAllPrograms()
        {
            if (HttpContext.Current.Cache["AWARDS_PROGRAMS"] != null)
            {
                return (List<ProgramVo>)HttpContext.Current.Cache["AWARDS_PROGRAMS"];
            }

            Service1.CurrentPrograms svc = new Service1.CurrentPrograms();
            List<ProgramVo> programs = GeneratedClassToProgramVo(svc.GetAllPrograms("", "-1"));

            HttpContext.Current.Cache.Add("AWARDS_PROGRAMS",
                                          programs,
                                          null,
                                          DateTime.Now.AddMinutes(60),
                                          Cache.NoSlidingExpiration,
                                          CacheItemPriority.Normal,
                                          null);

            return programs;
        }

        public ProgramVo GetProgramByCode(string code)
        {
            List<ProgramVo> programs = this.GetAllPrograms();

            return programs.SingleOrDefault(p => p.ProgramCode.Equals(code));
        }


        private List<ProgramVo> GeneratedClassToProgramVo(Service1.Program[] generated)
        {
            List<ProgramVo> programs = new List<ProgramVo>();
            for (int i = 0; i < generated.Length; i++)
            {
                ProgramVo vo = new ProgramVo();
                Service1.Program g = generated[i];

                vo.ProgramCode = g.ProgramCode;
                vo.ProgramDescr = g.ProgramDescr;

                for (int j = 0; j < g.Campuses.Length; j++)
                {
                    vo.Campuses.Add(new CampusVo{ CampusCode = g.Campuses[j].CampusCode, CampusDescr = g.Campuses[j].CampusDescr, Location = g.Campuses[j].Location });   
                }                    

                programs.Add(vo);
            }

            return programs;
        }

        private List<CampusVo> GeneratedClassToCampusVo(Service1.Campus[] generated)
        {
            List<CampusVo> campuses = new List<CampusVo>();
            for (int i = 0; i < generated.Length; i++)
            {
                CampusVo vo = new CampusVo();
                Service1.Campus g = generated[i];

                vo.CampusCode = g.CampusCode;
                vo.CampusDescr = g.CampusDescr;
                vo.Location = g.Location;

                campuses.Add(vo);
            }

            return campuses;
        }

        private List<AwardSelection> FilterByProgram(string programCode, List<AwardSelection> awards)
        {
            List<AwardSelection> filtered = new List<AwardSelection>();
            foreach (AwardSelection a in awards)
            {
                if (a.EligiblePrograms.Contains(programCode))
                {
                    filtered.Add(a);
                }
            }
            return filtered;
        }

    }
}
