using ClassLibVideos;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace SuperMuskler4000GIFAPI.Managers
{
    public class VideoManager
    {
        string connectionString = "Data Source=supermuskler4000server.database.windows.net;Initial Catalog=SuperMuskler4000;User ID=admin1;Password=Alexander1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public List<Video> GetByMuscleType(string muscletype)
        {
            if (muscletype.IsNullOrEmpty())
            {
                throw new ArgumentNullException("muscletype", "You must enter a muscletype");
            }
            List<Video> videoList = new List<Video>();
            string queryString = "select * from Supermusklervideoer where MuscleType = @muscletype";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@muscletype", muscletype.ToLower());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Video v = ReadVideo(reader);
                    videoList.Add(v);
                }
            }
            if (videoList.Count == 0)
            {
                throw new ArgumentOutOfRangeException("No Exercises found");
            }
            return videoList;
        }
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
