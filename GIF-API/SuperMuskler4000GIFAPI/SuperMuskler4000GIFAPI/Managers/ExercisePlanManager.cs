using ClassLibVideos;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace SuperMuskler4000GIFAPI.Managers
{
    public class ExercisePlanManager
    {
        private string connectionString = "Data Source=supermuskler4000server.database.windows.net;Initial Catalog=SuperMuskler4000;User ID=admin1;Password=Alexander1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// selects all data from exerciseplan table with SELECT *
        /// </summary>
        /// <returns>data from exerciseplan</returns>
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

        /// <summary>
        /// Adds exercise to personal exercise plan by doing a get request on the current plan and checking if the result is there or not
        /// if it exists already it throws argument exception, else it runs the querystring and inserts the data into Exerciseplan
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns>new object in Exerciseplan table</returns>
        /// <exception cref="ArgumentException"></exception>
        public ExercisePlan AddExercisePlan(ExercisePlan exercise)
        {
            List <ExercisePlan> PlanList = GetExercisePlan();

            if(PlanList.Exists(e => e.Name == exercise.Name))
            {
                throw new ArgumentException();
            }




            string queryString = "insert into Exerciseplan Values (@name, @type, @muscletype, @equipment, @difficulty, @instructions)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@name", exercise.Name);
                command.Parameters.AddWithValue("@type", exercise.Type);
                command.Parameters.AddWithValue("@muscletype", exercise.MuscleType);
                command.Parameters.AddWithValue("@equipment", exercise.Equipment);
                command.Parameters.AddWithValue("@difficulty", exercise.Difficulty);
                command.Parameters.AddWithValue("@instructions", exercise.Instructions);
                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Exerciseplan er ikke oprettet");
                }



            }

            return exercise;
        }

        private ExercisePlan ReadPlan(SqlDataReader reader)
        {
            ExercisePlan p = new ExercisePlan();
            p.Name = reader.GetString(0);
            p.Type = reader.GetString(1);
            p.MuscleType = reader.GetString(2);
            p.Equipment = reader.GetString(3);
            p.Difficulty = reader.GetString(4);
            p.Instructions = reader.GetString(5);
            return p;
        }

    }
}
