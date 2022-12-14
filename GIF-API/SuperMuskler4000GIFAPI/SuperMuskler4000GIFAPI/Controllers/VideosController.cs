using ClassLibVideos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SuperMuskler4000GIFAPI.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperMuskler4000GIFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private VideoManager mgr = new VideoManager();

        // GET api/<VideosController>/biceps
        //[HttpGet]
        //[Route("{muscletype}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetByMuscleType(string muscletype)
        //{
        //    try
        //    {
        //        List<Video> listOfVideos = mgr.GetByMuscleType(muscletype);
        //        return Ok(listOfVideos);
        //    }
        //    catch (ArgumentOutOfRangeException s)
        //    {
        //        return NotFound(s.Message);
        //    }
        //    catch(ArgumentNullException s)
        //    {
        //        return BadRequest(s.Message);
        //    }
        //}

        /// <summary>
        /// Try Catch To check for errors on our GetAllVideos
        /// </summary>
        /// <returns>returns status codes based on input given (200 OK, 400 Bad Request, 404 Not Found)</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllVideos()
        {
            try
            {
                return Ok(mgr.GetAllVideos());
            }
            catch
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Post Method to add profile videos to the database through our manager
        /// </summary>
        /// <param name="video"></param>
        [HttpPost]
        public void AddVideoToProfile([FromBody] Video video)
        {
                mgr.AddVideoToProfile(video);
            
        } 

    }
}
