using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SuperMuskler4000APITest
{   
    [TestClass]
    public class ExercisePlanManagerTest
    {
        private ExercisePlanManager _exercisePlanManager;
        private ExercisePlan _exercisePlan;
        private string connectionString = "Data Source=supermuskler4000server.database.windows.net;Initial Catalog=SuperMuskler4000;User ID=admin1;Password=Alexander1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private ExercisePlan ReadPlan(SqlDataReader reader)
        {
            ExercisePlan p = new ExercisePlan();
            p.Name = reader.GetString(0);
            return p;
        }

        [TestInitialize]
        public void TestInit()
        {
            _exercisePlanManager = new ExercisePlanManager();
            _exercisePlan = new ExercisePlan();
        }

        [TestMethod]
        public void AddDataToListExercisePlanManager()
        {
            //Arrange
            List<ExercisePlan> exercisePlanList = new List<ExercisePlan>();

            //Act
            exercisePlanList = _exercisePlanManager.GetExercisePlan();

            //Assert
            Assert.IsTrue(exercisePlanList.Count > 0);
        }

        [TestMethod]
        public void CheckListNotEmptyExercisePlan()
        {
            //Arrange
            List<ExercisePlan> exercisePlanList = new List<ExercisePlan>();

            //Act
            exercisePlanList = _exercisePlanManager.GetExercisePlan();

            //Assert
            Assert.IsFalse(exercisePlanList.Count < 1);
        }

        [TestMethod]
        public void AddExercisePlanTest()
        {
            //Arrange
            _exercisePlan.Name = "Hammer Curls";
            string expectedValue = _exercisePlan.Name;
            ExercisePlan p = new ExercisePlan();
            string queryString = "Select * from Exerciseplan where Name = @name";

            //Act
            _exercisePlanManager.AddExercisePlan(_exercisePlan);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@name", _exercisePlan.Name);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    p = ReadPlan(reader);
                    
                }
            }

            string actualValue = p.Name;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}

