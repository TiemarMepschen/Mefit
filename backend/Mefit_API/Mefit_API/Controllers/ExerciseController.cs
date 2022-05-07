using Mefit_API.Models;
using Mefit_API.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Mefit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ExerciseController : ControllerBase
    {
        private readonly MefitDbContext _context;

        public ExerciseController(MefitDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all exercises from the database.
        /// </summary>
        /// <returns>A list of all exercises in the database and a responsetype indicating success.</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            var exercises = await _context.Exercises.ToListAsync<Exercise>();

            return Ok(exercises);
        }

        /// <summary>
        /// Get a specific exercise from the database by ID.
        /// </summary>
        /// <param name="id">Exercise ID</param>
        /// <returns>An exercise from the database and a responstype indicating whether the exercise was found.</returns>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }
    }
}
