using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

using Dapper;

namespace NSCC.Web.Awards.Search.Classes
{
    public class DataAccess
    {
        //private readonly string _connectionString 
        //    = System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsConnectionString"].ConnectionString;

        public List<CampusVo> GetCampuses()
        {
            /*
            using (var conn = new SqlConnection(this._connectionString))
            {
                string query = "";

                conn.Open();

                var campuses = conn.Query<CampusVo>(query, null);

                return campuses.ToList<CampusVo>();
            }*/

            List<CampusVo> campuses = new List<CampusVo>();

            campuses.Add(new CampusVo { CampusCode = "AKERL", CampusDescr = "Akerley Campus", Location = "Dartmouth" });
            campuses.Add(new CampusVo { CampusCode = "STRAT", CampusDescr = "Strait Area Campus", Location = "Port Hawkesbury" });

            return campuses;

        }

        public List<ProgramVo> GetAllPrograms()
        {
            /*
            using (var conn = new SqlConnection(this._connectionString))
            {
                string query = "";

                conn.Open();

                return null;
            }
             */
            
            List<ProgramVo> programs = new List<ProgramVo>();

            CampusVo akerl = new CampusVo { CampusCode = "AKERL", CampusDescr = "Akerley Campus", Location = "Dartmouth" };
            CampusVo strat = new CampusVo { CampusCode = "STRAT", CampusDescr = "Strait Area Campus", Location = "Port Hawkesbury" };
            CampusVo annap = new CampusVo { CampusCode = "ANNAP", CampusDescr = "Annapolis Valley Campus", Location = null };

            programs.Add(new ProgramVo { ProgramCode = "AIRMAINENG", ProgramDescr = "Aircraft Maintenance Engineer (Mechanical)", Campuses = new List<CampusVo> { akerl } });
            programs.Add(new ProgramVo { ProgramCode = "BEHAVINTER", ProgramDescr = "Behavioural Interventions", Campuses = new List<CampusVo> { annap, strat } });

            return programs;
        }

        
    }
}