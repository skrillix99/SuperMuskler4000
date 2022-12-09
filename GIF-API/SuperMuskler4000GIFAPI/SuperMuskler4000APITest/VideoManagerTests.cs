//namespace SuperMuskler4000APITest
//{
//    [TestClass]
//    public class VideoManagerTests
//    {
//        private List<Video> _videoList;
//        private VideoManager _videoManager;

//        [TestInitialize]
//        public void TestInit()
//        {
//            _videoList = new List<Video>();
//            _videoManager = new VideoManager();
//        }


//        [TestMethod]
//        [DataRow("biceps")]
//        [DataRow("glutes")]
//        [DataRow("triceps")]
//        [DataRow("chest")]
//        [DataRow("calves")]
//        public void GetByMuscleTypeReturnsListofVidoesWithCorrectType(string muscletype)
//        {
//            //Arrange
//            bool checktype = true;

//            //Act
//            _videoList = _videoManager.GetByMuscleType(muscletype);
//            foreach (var exercise in _videoList)
//            {
//                if (exercise.MuscleType != muscletype)
//                {
//                    checktype = false;
//                    break;
//                }

//            }

//            //Assert
//            Assert.IsTrue(checktype);


//        }

//        [TestMethod]
//        [DataRow("biCeps")]
//        [DataRow("glUtes")]
//        [DataRow("TRICEPS")]
//        [DataRow("CHESt")]
//        [DataRow("caLVes")]
//        public void GetByMuscleTypeReturnsCorrectListofVidoesWithUpperCaseSearch(string muscletype)
//        {
//            //Arrange
//            bool checktype = true;

//            //Act
//            _videoList = _videoManager.GetByMuscleType(muscletype);
//            foreach (var exercise in _videoList)
//            {
//                if (exercise.MuscleType == muscletype)
//                {
//                    checktype = false;
//                    break;
//                }

//            }

//            //Assert
//            Assert.IsTrue(checktype);


//        }


//        [TestMethod()]
//        [DataRow("bi")]
//        [ExpectedException(typeof(ArgumentOutOfRangeException))]
//        public void GetByMuscleWithWrongInput(string input)
//        {
//            //Arrange


//            //Act
//            _videoList = _videoManager.GetByMuscleType(input);

//            //Assert
//            Assert.Fail();
//        }

//        [TestMethod()]
//        [DataRow("")]
//        [DataRow(null)]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void GetByMuscleWithEmptyAndNullAsInput(string input)
//        {
//            //Arrange


//            //Act
//            _videoList = _videoManager.GetByMuscleType(input);

//            //Assert
//            Assert.Fail();
//        }
//    }
//}
