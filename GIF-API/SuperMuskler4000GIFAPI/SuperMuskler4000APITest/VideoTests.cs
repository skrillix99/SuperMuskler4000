//namespace SuperMuskler4000APITest
//{
//    /// <summary>
//    /// A Test Class used to test Video Class functionality
//    /// </summary>
//    [TestClass]
//    public class VideoTests
//    {
//        private Video video;
        
//        /// <summary>
//        /// Method to initialize new Video object before each test
//        /// </summary>
//        [TestInitialize]
//        public void TestInit()
//        {
//            video = new Video();
//        }
        
//        /// <summary>
//        /// Tests get/set works properly ofr VideoLink property
//        /// </summary>
//        [TestMethod]
//        public void VideoLinkReturnsCorrectLink()
//        {
//            //Arrange
//            string expectedLink = "https://i.imgur.com/adDxqu3.mp4";
            
//            //Act
//            video.VideoLink = "https://i.imgur.com/adDxqu3.mp4";
//            string actualLink = video.VideoLink;

//            //Assert
//            Assert.AreEqual(expectedLink, actualLink);
//        }
//        /// <summary>
//        /// Tests get set/set works properly for Name property
//        /// </summary>
//        [TestMethod]
//        public void NameReturnsCorrectName()
//        {
//            //Arrange
//            string expectedName = "Barbell Curl";

//            //Act
//            video.Name = "Barbell Curl";
//            string actualName = video.Name;

//            //Assert
//            Assert.AreEqual(expectedName, actualName);
//        }

//        /// <summary>
//        /// Tests get/set works properly for Id property
//        /// </summary>
//        [TestMethod]
//        public void IdReturnsCorrectId()
//        {
//            //Arrange
//            int expectedId = 1;

//            //Act
//            video.Id = 1;
//            int actualId = video.Id;

//            //Assert
//            Assert.AreEqual(expectedId, actualId);
//        }

//        /// <summary>
//        /// /// Tests get/set works properly for MuscleType property
//        /// </summary>
//        [TestMethod]
//        public void MuscleTypeReturnsCorrectMuscleType()
//        {
//            //Arrange
//            string expectedMuscleType = "biceps";

//            //Act
//            video.MuscleType = "biceps";
//            string actualMuscleType = video.MuscleType;

//            //Assert
//            Assert.AreEqual(expectedMuscleType, actualMuscleType);
//        }
//    }
//}