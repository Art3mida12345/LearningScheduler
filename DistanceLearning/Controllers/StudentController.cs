using System.Linq;
using DistanceLearning.DAL;
using DistanceLearning.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DistanceLearning.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;

        public StudentController(ApplicationContext context)
        {
            _applicationContext = context;
        }

        [HttpGet]
        public ActionResult<Student> Get()
        {
            return Ok(_applicationContext.Student.ToList());
        }
    }
}
