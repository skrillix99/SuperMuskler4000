namespace ClassLibVideos
{
    public class Video
    {


        #region Constructor

        public Video() : this(1, "Barbell Curl", "https://i.imgur.com/adDxqu3.mp4","biceps")
        {
            
        }

        public Video(int id, string name, string videolink, string muscleType)
        {
            Id = id;
            Name = name;
            VideoLink = videolink;
            MuscleType = muscleType;
        }


        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoLink { get; set; }
        public string MuscleType { get; set; }


        #endregion
    }
}