using ClassLibVideos;
using Microsoft.AspNetCore.Mvc;
using SuperMuskler4000GIFAPI.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperMuskler4000GIFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisePlansController : ControllerBase
    {
        private ExercisePlanManager _planmgr = new ExercisePlanManager();
        
        // GET: api/<ExercisePlansController>
        [HttpGet]
        public List<ExercisePlan> GetAll()
        {

            return _planmgr.GetExercisePlan();

        }

        

        // POST api/<ExercisePlansController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] ExercisePlan exerciseplan)
        {
            try
            {
               return Ok(_planmgr.AddExercisePlan(exerciseplan));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        
    }
}
