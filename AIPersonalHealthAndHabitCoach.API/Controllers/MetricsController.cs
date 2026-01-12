using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AIPersonalHealthAndHabitCoach.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricsController : ControllerBase
    {
        // --- SEKCJA GET (Pobieranie) ---
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Pobrano wszystko");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok($"Pobrano metrykę o ID: {id}");
        }

        // --- SEKCJA CREATE (Tworzenie) ---
        [HttpPost("sleep")]
        public IActionResult CreateSleep(Sleep sleep)
        {
            return Ok("Dodano sen");
        }

        [HttpPost("activity")]
        public IActionResult CreateActivity(Activity activity)
        {
            return Ok("Dodano aktywność");
        }

        [HttpPost("meal")]
        public IActionResult CreateMeal(Meal meal)
        {
            return Ok("Dodano posiłek");
        }

        // --- SEKCJA UPDATE (Aktualizacja - metody z diagramu) ---
        [HttpPut("sleep")]
        public IActionResult UpdateSleep(Sleep sleep)
        {
            return Ok("Zaktualizowano sen");
        }

        [HttpPut("activity")]
        public IActionResult UpdateActivity(Activity activity)
        {
            return Ok("Zaktualizowano aktywność");
        }

        [HttpPut("meal")]
        public IActionResult UpdateMeal(Meal meal)
        {
            return Ok("Zaktualizowano posiłek");
        }

        // --- SEKCJA DELETE (Usuwanie) ---
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            return Ok($"Usunięto element o ID: {id}");
        }
    }
}