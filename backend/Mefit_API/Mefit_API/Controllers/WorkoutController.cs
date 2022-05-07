using AutoMapper;
using Mefit_API.Models;
using Mefit_API.Models.Domain;
using Mefit_API.Models.DTOs.Set;
using Mefit_API.Models.DTOs.Workout;
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
    public class WorkoutController : ControllerBase
    {
        private readonly MefitDbContext _context;
        private readonly IMapper _mapper;

        public WorkoutController(MefitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all workouts from the database.
        /// </summary>
        /// <returns>A list of all workouts in the database and a responsetype indicating success.</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<WorkoutReadDTO>>> GetWorkouts()
        {
            var workouts = await _context.Workouts.Include(w => w.Programmes).Include(w => w.Goals).ToListAsync<Workout>();

            var workoutsToSend = _mapper.Map<List<WorkoutReadDTO>>(workouts);

            return Ok(workoutsToSend);
        }

        /// <summary>
        /// Get a specific workout from the database by ID.
        /// </summary>
        /// <param name="id">Workout ID</param>
        /// <returns>A workout from the database and a responstype indicating whether the workout was found.</returns>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<WorkoutReadDTO>> GetWorkout(int id)
        {
            var workout = await _context.Workouts.Include(w => w.Programmes).Include(w => w.Goals).FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                return NotFound();
            }

            var workoutToSend = _mapper.Map<WorkoutReadDTO>(workout);

            return Ok(workoutToSend);
        }

        /// <summary>
        /// Get the set associated to a specific workout from the database by ID.
        /// </summary>
        /// <param name="id">Workout ID</param>
        /// <returns>A set from the database and a responstype indicating whether the workout was found.</returns>
        [Authorize]
        [HttpGet("{id}/set")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SetReadDTO>> GetSetFromWorkout(int id)
        {
            var workout = await _context.Workouts.Include(w => w.Programmes).Include(w => w.Goals).Include(w => w.Set).FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                return NotFound();
            }

            var setToSend = _mapper.Map<SetReadDTO>(workout.Set);

            return Ok(setToSend);
        }

        /// <summary>
        /// Get the exercise associated to a specific workout from the database by ID.
        /// </summary>
        /// <param name="id">Workout ID</param>
        /// <returns>A exercise from the database and a responstype indicating whether the workout was found.</returns>
        [Authorize]
        [HttpGet("{id}/exercise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Exercise>> GetExerciseFromWorkout(int id)
        {
            var workout = await _context.Workouts.Include(w => w.Programmes).Include(w => w.Goals).Include(w => w.Set).ThenInclude(s => s.Exercise).FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                return NotFound();
            }

            var exerciseToSend = workout.Set.Exercise;

            return Ok(exerciseToSend);
        }
    }
}
