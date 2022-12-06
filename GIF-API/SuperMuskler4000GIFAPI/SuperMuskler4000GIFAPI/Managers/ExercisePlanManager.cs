using ClassLibVideos;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace SuperMuskler4000GIFAPI.Managers
{
    public class ExercisePlanManager
    {
        string connectionString = "Data Source=supermuskler4000server.database.windows.net;Initial Catalog=SuperMuskler4000;User ID=admin1;Password=Alexander1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<ExercisePlan> GetExercisePlan()
        {
            
            List<ExercisePlan> PlanList = new List<ExercisePlan>();
            string queryString = "select * from ExercisePlan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ExercisePlan p = ReadPlan(reader);
                    PlanList.Add(p);
                }
            }
            return PlanList;
        }
        private ExercisePlan ReadPlan(SqlDataReader reader)
        {
            ExercisePlan p = new ExercisePlan();
            p.Name = reader.GetString(0);
            return p;
        }

    }
}
