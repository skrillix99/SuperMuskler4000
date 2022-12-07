using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SuperMuskler4000APITest
{
    [TestClass]
    public class ExercisePlanManagerTest
    {
        private ExercisePlanManager _exercisePlanManager;
        
        [TestInitialize]
        public void TestInit()
        {
            _exercisePlanManager = new ExercisePlanManager();
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
        public void MyTestMethod()
        {

        }
    }
}

