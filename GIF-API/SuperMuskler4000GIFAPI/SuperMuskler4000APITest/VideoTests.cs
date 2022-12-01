namespace SuperMuskler4000APITest
{
    [TestClass]
    public class VideoTests
    {
        private Video video;
        
        [TestInitialize]
        public void TestInit()
        {
            video = new Video();
        }
        
        
        [TestMethod]
        public void VideoLinkReturnsCorrectLink()
        {
            //Arrange
            string expectedLink = "https://i.imgur.com/adDxqu3.mp4";
            
            //Act
            video.VideoLink = "https://i.imgur.com/adDxqu3.mp4";
            string actualLink = video.VideoLink;

            //Assert
            Assert.AreEqual(expectedLink, actualLink);
        }

        [TestMethod]
        public void NameReturnsCorrectName()
        {
            //Arrange
            string expectedName = "Barbell Curl";

            //Act
            video.Name = "Barbell Curl";
            string actualName = video.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void IdReturnsCorrectId()
        {
            //Arrange
            int expectedId = 1;

            //Act
            video.Id = 1;
            int actualId = video.Id;

            //Assert
            Assert.AreEqual(expectedId, actualId);
        }


    }
}