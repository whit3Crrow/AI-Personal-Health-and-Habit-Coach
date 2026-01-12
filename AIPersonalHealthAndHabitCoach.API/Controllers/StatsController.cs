using AIPersonalHealthAndHabitCoach.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsMetricService _statsService;

        public StatsController()
        {
            _statsService = new StatsMetricService();
        }

        [HttpGet("summary/{userId}")]
        public IActionResult GetMetricsSummary(Guid userId)
        {
            var result = _statsService.GetSummary(userId);
            return Ok(result);
        }

        [HttpGet("type/{userId}")]
        public IActionResult GetMetricByType(Guid userId, string type)
        {
            var result = _statsService.GetSpecific(userId, type);
            return Ok(result);
        }
    }
}