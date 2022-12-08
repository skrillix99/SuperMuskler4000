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
        public List<Video> GetByMuscleType(string muscletype)
        {
            // throws an exception if mucle type is null or empthy.
            if (muscletype.IsNullOrEmpty())
            {
                throw new ArgumentNullException("muscletype", "You must enter a muscletype");
            }
            // create the list of vidoes
            List<Video> videoList = new List<Video>();
            // creating the query, where it select mucletypes from supermuskler4000 database
            string queryString = "select * from Supermusklervideoer where MuscleType = @muscletype";

            // establish connection to database using the connectionstring.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // creating the command we send to the database.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@muscletype", muscletype.ToLower());
                // crates the reading founktion for the database
                SqlDataReader reader = command.ExecuteReader();
                // here we read the data from the database and puts it in the video list
                while (reader.Read())
                {
                    Video v = ReadVideo(reader);
                    videoList.Add(v);
                }
            // tjeks if the video list is empthy
            }
            if (videoList.Count == 0)
            {
                throw new ArgumentOutOfRangeException("No Exercises found");
            }
            return videoList;
        }
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
            v.MuscleType = reader.GetString(2);
            v.VideoLink = reader.GetString(3);
            return v;
        }
    }
}
