using AutoMapper;
using Mefit_API.Models;
using Mefit_API.Models.DTOs.Programme;
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
    public class ProgrammeController : ControllerBase
    {
        private readonly MefitDbContext _context;
        private readonly IMapper _mapper;

        public ProgrammeController(MefitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all programmes from the database.
        /// </summary>
        /// <returns>A list of all programmes in the database and a responsetype indicating success.</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProgrammeReadDTO>>> GetProgrammes()
        {
            var programmes = await _context.Programmes.Include(p => p.Workouts).ToListAsync();

            var programmesToSend = _mapper.Map<List<ProgrammeReadDTO>>(programmes);

            return Ok(programmesToSend);
        }

        /// <summary>
        /// Get a specific programme from the database by ID.
        /// </summary>
        /// <param name="id">Programme ID</param>
        /// <returns>A programme from the database and a responstype indicating whether the programme was found.</returns>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProgrammeReadDTO>> GetProgramme(int id)
        {
            var programme = await _context.Programmes.Include(p => p.Workouts).FirstOrDefaultAsync(p => p.Id == id);

            if (programme == null)
            {
                return NotFound();
            }

            var programmeToSend = _mapper.Map<ProgrammeReadDTO>(programme);

            return Ok(programmeToSend);
        }
    }
}
