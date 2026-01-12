using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(UserData user)
        {
            return Ok("Utworzono użytkownika");
        }

        [HttpPut]
        public IActionResult Update(UserData user)
        {
            return Ok("Zaktualizowano dane użytkownika");
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(new UserData { Id = id, Age = 25, WeightKilograms = 70 });
        }
    }
}