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
        public void Post([FromBody] ExercisePlan exerciseplan)
        {
            _planmgr.AddExercisePlan(exerciseplan);
        }

        

        
    }
}
