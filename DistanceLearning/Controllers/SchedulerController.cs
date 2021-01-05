using Microsoft.AspNetCore.Mvc;

namespace DistanceLearning.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchedulerController : ControllerBase
    {
        public SchedulerController()
        {
        }

        [HttpGet]
        public void Get()
        {
            return;
        }
    }
}
