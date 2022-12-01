namespace ClassLibVideos
{
    public class Video
    {


        #region Constructor

        public Video() : this(1, "Barbell Curl", "https://i.imgur.com/adDxqu3.mp4")
        {
            
        }

        public Video(int id, string name, string videolink)
        {
            Id = id;
            Name = name;
            VideoLink = videolink;
        }


        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoLink { get; set; }


        #endregion
    }
}