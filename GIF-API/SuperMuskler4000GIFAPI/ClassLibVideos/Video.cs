namespace ClassLibVideos
{
    /// <summary>
    /// This is the Model Class for Videos
    /// </summary>
    public class Video
    {


        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Video() : this(1, "Barbell Curl", "https://i.imgur.com/adDxqu3.mp4","biceps")
        {
            
        }

        /// <summary>
        /// Constructor with 4 parameters
        /// </summary>
        /// <param name="id">The videos Id. Type int</param>
        /// <param name="name">The videos name. Type string</param>
        /// <param name="videolink">The link to the video. Type string</param>
        /// <param name="muscleType">Muscletype of the exercise shown in the video. Type string</param>
        public Video(int id, string name, string videolink, string muscleType)
        {
            Id = id;
            Name = name;
            VideoLink = videolink;
        //    MuscleType = muscleType;
        }


        #endregion

        #region Properties
        /// <summary>
        /// The Id property. Type string. Contains both get/set functionality
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name property. Type string. Contains both get/set functionality
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The video link property. Type string. Contains both get/set functionality
        /// </summary>
        public string VideoLink { get; set; }
        /// <summary>
        /// The muscletype property. Type string. Contains both get/set functionality
        /// </summary>
       // public string MuscleType { get; set; }


        #endregion
    }
}