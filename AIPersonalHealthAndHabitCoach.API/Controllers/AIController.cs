using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        [HttpGet("analyze")]
        public IActionResult GetMetricsAnalyze()
        {
            return Ok("Tu będzie analiza AI Twoich nawyków.");
        }
    }
}