using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using NSCC.Web.Awards.Classes;

namespace NSCC.Web.Awards.DataAccess
{
    public class CommonDal
    {
        private readonly string _connectionStringSearch = System.Configuration.ConfigurationManager.ConnectionStrings["NSCCAwardsConnectionString"].ConnectionString;

        public List<EssayQuestion> GetEssayQuestions()
        {
            using (var conn = new SqlConnection(this._connectionStringSearch))
            {
                string query = "SELECT * FROM awards.essayquestions ORDER BY id";

                conn.Open();

                var questions = conn.Query<EssayQuestion>(query, null);

                return questions.ToList<EssayQuestion>();
            }
        }

        public EssayQuestion GetEssayQuestionById(int id)
        {
            using (var conn = new SqlConnection(this._connectionStringSearch))
            {
                string query = "SELECT * FROM awards.essayquestions WHERE id = @Id";

                conn.Open();

                var question = conn.Query<EssayQuestion>(query, new { Id = id }).SingleOrDefault();

                return question;
            }
        }

        public List<EssayQuestion> GetEssayQuestionInRange(int[] ids)
        {
            using (var conn = new SqlConnection(this._connectionStringSearch))
            {
                string query = "SELECT * FROM awards.essayquestions WHERE id IN @Ids";

                conn.Open();

                var questions = conn.Query<EssayQuestion>(query, new { Ids = ids });

                return questions.ToList<EssayQuestion>();
            }
        }        

    }
}
