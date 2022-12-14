using ClassLibVideos;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace SuperMuskler4000GIFAPI.Managers
{
    public class VideoManager
    {
        // stores the connectionstring to the database supermuskler4000 in the variable connectionString.
        private string connectionString = "Data Source=supermuskler4000server.database.windows.net;Initial Catalog=SuperMuskler4000;User ID=admin1;Password=Alexander1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        /// <summary>
        /// creates a list with videos where it get the data from the database and sortes them after mucletype, and if mucle type is null or empthy it throw an exception.
        /// </summary>
        /// <param name="muscletype"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        //public List<Video> GetByMuscleType(string muscletype)
        //{
        //    // throws an exception if mucle type is null or empthy.
        //    if (muscletype.IsNullOrEmpty())
        //    {
        //        throw new ArgumentNullException("muscletype", "You must enter a muscletype");
        //    }
        //    // create the list of vidoes
        //    List<Video> videoList = new List<Video>();
        //    // creating the query, where it select mucletypes from supermuskler4000 database
        //    string queryString = "select * from Supermusklervideoer where MuscleType = @muscletype";

        //    // establish connection to database using the connectionstring.
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        // creating the command we send to the database.
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.Parameters.AddWithValue("@muscletype", muscletype.ToLower());
        //        // crates the reading founktion for the database
        //        SqlDataReader reader = command.ExecuteReader();
        //        // here we read the data from the database and puts it in the video list
        //        while (reader.Read())
        //        {
        //            Video v = ReadVideo(reader);
        //            videoList.Add(v);
        //        }
        //    // tjeks if the video list is empthy
        //    }
        //    if (videoList.Count == 0)
        //    {
        //        throw new ArgumentOutOfRangeException("No Exercises found");
        //    }
        //    return videoList;
        //}
        /// <summary>
        /// Reads one row of data from the database and puts the data into a Video object
        /// </summary>
        /// <param name="reader">Type SqlDataReader. Reads the data from the database</param>
        /// <returns>Returns an object of the Video class</returns>
        private Video ReadVideo(SqlDataReader reader)
        {
            Video v = new Video();
            v.Id = reader.GetInt32(0);
            v.Name = reader.GetString(1);
           // v.MuscleType = reader.GetString(2);
            v.VideoLink = reader.GetString(3);
            return v;
        }

        /// <summary>
        /// Selects all the data in our PrivateExerciseVideos table through sql querystrings. used to make a list of videos created by the user
        /// </summary>
        /// <returns>returns a list of videos created by the user, that exists in our azure database</returns>
        public List<Video> GetAllVideos()
        {
            List<Video> videos = new List<Video>();

            string queryString = "SELECT * FROM PrivateExerciseVideos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Video b = ReadPrivateVideo(reader);
                    videos.Add(b);
                }
            }
            return videos;
        }
        private Video ReadPrivateVideo(SqlDataReader reader)
        {
            Video b = new Video();
            b.Id = reader.GetInt32(0);
            b.Name = reader.GetString(1);
            b.VideoLink = reader.GetString(2);
            return b;
        }

        /// <summary>
        /// Adds our video recording into the database through sql insert into with values name, and video link
        /// throws ArgumentException if it didnt get created
        /// </summary>
        /// <param name="video"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddVideoToProfile(Video video)
        {
            string queryString = "insert into PrivateExerciseVideos Values (@name, @videolink)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@name", video.Name);
                command.Parameters.AddWithValue("@videolink", video.VideoLink);

                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Exerciseplan er ikke oprettet");
                }



            }
        }

    }
}
