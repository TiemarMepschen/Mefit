using AutoMapper;
using Mefit_API.Models;
using Mefit_API.Models.Domain;
using Mefit_API.Models.DTOs.Goal;
using Mefit_API.Models.DTOs.Programme;
using Mefit_API.Models.DTOs.Workout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Mefit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class GoalController : ControllerBase
    {
        private readonly MefitDbContext _context;
        private readonly IMapper _mapper;

        public GoalController(MefitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all goals from the database.
        /// </summary>
        /// <returns>A list of all goals in the database and a responsetype indicating success.</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<GoalReadDTO>>> GetGoals()
        {
            var goals = await _context.Goals.Include(g => g.Workouts).ToListAsync();

            var goalsToSend = _mapper.Map<List<GoalReadDTO>>(goals);

            return Ok(goalsToSend);
        }

        /// <summary>
        /// Get a specific goal from the database by ID.
        /// </summary>
        /// <param name="id">Goal ID</param>
        /// <returns>A goal from the database and a responstype indicating whether the goal was found.</returns>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<GoalReadDTO>> GetGoal(int id)
        {
            var goal = await _context.Goals.Include(g => g.Workouts).FirstOrDefaultAsync(g => g.Id == id);

            if (goal == null)
            {
                return NotFound();
            }

            var goalToSend = _mapper.Map<GoalReadDTO>(goal);

            return Ok(goalToSend);
        }

        /// <summary>
        /// Get the programme from a specific goal from the database by ID.
        /// </summary>
        /// <param name="id">Goal ID</param>
        /// <returns>A programme from the database and a responstype indicating whether the goal was found.</returns>
        [Authorize]
        [HttpGet("{id}/program")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProgrammeReadDTO>> GetProgrammeFromGoal(int id)
        {
            var goal = await _context.Goals.Include(g => g.Programme).ThenInclude(p => p.Workouts).FirstOrDefaultAsync(g => g.Id == id);

            if (goal == null)
            {
                return NotFound();
            }

            var programmeToSend = _mapper.Map<ProgrammeReadDTO>(goal.Programme);

            return Ok(programmeToSend);
        }

        /// <summary>
        /// Get the workouts from a specific goal from the database by ID.
        /// </summary>
        /// <param name="id">Goal ID</param>
        /// <returns>A list of workouts from the database and a responstype indicating whether the goal was found.</returns>
        [Authorize]
        [HttpGet("{id}/workout")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<WorkoutReadDTO>>> GetWorkoutsFromGoal(int id)
        {
            var goal = await _context.Goals.Include(g => g.Programme).ThenInclude(p => p.Workouts).ThenInclude(w => w.Set).FirstOrDefaultAsync(g => g.Id == id);

            if (goal == null)
            {
                return NotFound();
            }

            var workoutsToSend = _mapper.Map<List<WorkoutReadDTO>>(goal.Programme.Workouts);

            return Ok(workoutsToSend);
        }

        /// <summary>
        /// Updates completed workouts in goal
        /// </summary>
        /// <param name="id">Goal Id</param>
        /// <param name="workouts">Add workouts that have been completed.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoalWorkout(int id, List<int> workouts)
        {
            if (!GoalExists(id))
            {
                return NotFound();
            }

            Goal goalToUpdateWorkouts = await _context.Goals
                .Include(c => c.Workouts)
                .Where(c => c.Id == id)
                .FirstAsync();

            List<Workout> allWorkouts = new();
            foreach (int workoutId in workouts)
            {
                Workout workout = await _context.Workouts.FindAsync(workoutId);
                if (workout == null)
                    return BadRequest("Workouts don't exist!");
                allWorkouts.Add(workout);
            }

            goalToUpdateWorkouts.Workouts = allWorkouts;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Adds a new goal to the database.
        /// </summary>
        /// <param name="goal">The goal data to add to the database.</param>
        /// <returns>A goal ID, goal data and a responsetype indicating success.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<GoalReadDTO>> PostGoal([FromBody] GoalCreateDTO goal)
        {
            var domainGoal = _mapper.Map<Goal>(goal);

            _context.Goals.Add(domainGoal);

            await _context.SaveChangesAsync();

            var goalToSend = _mapper.Map<GoalReadDTO>(domainGoal);

            return CreatedAtAction("GetGoal", new { id = domainGoal.Id }, goalToSend);
        }

        /// <summary>
        /// Checks if a profile exists in the database.
        /// </summary>
        /// <param name="id">Profile ID</param>
        /// <returns>A boolean, indicating whether the profile exists in the database.</returns>
        private bool GoalExists(int id)
        {
            return _context.Goals.Any(e => e.Id == id);
        }
    }
}
