using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mefit_API.Models;
using Mefit_API.DTOs.Profile;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Mefit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly MefitDbContext _context;
        private readonly IMapper _mapper;

        public ProfileController(MefitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Get

        /// <summary>
        /// Get a specific profile from the database by ID
        /// </summary>
        /// <param name="id">Profile ID</param>
        /// <returns>A profile from the database</returns>
        //[Authorize]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileReadDTO>> GetProfile(int id)
        {
            if (!ProfileExists(id))
            {
                return NotFound();
            }

            var profile = await _context.Profile.Include(p => p.Goal).FirstOrDefaultAsync(p => p.Id == id);

            //var profile = await _context.Profile.FindAsync(id);

            return Ok(_mapper.Map<ProfileReadDTO>(profile));
        }

        #endregion

        #region Put

        /// <summary>
        /// Updates a profile in the database
        /// </summary>
        /// <param name="id">Profile ID</param>
        /// <param name="newProfile">The profile data to update.</param>
        /// <returns>A responsetype indicating success and whether the profile was found.</returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, ProfileUpdateDTO newProfile)
        {
            var domainProfile = _mapper.Map<Models.Profile>(newProfile);

            if (id != domainProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(domainProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        #endregion

        #region Post

        /// <summary>
        /// Adds a new profile to the database
        /// </summary>
        /// <param name="newProfile">The profile data to add to the database.</param>
        /// <returns>The profile data, indicating success.</returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProfileReadDTO>> PostProfile([FromBody] ProfileCreateDTO newProfile)
        {
            var domainProfile = _mapper.Map<Models.Profile>(newProfile);

            _context.Profile.Add(domainProfile);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction("GetProfile", new { id = domainProfile.Id }, newProfile);
        }

        #endregion

        /// <summary>
        /// Checks if a profile exists in the database.
        /// </summary>
        /// <param name="id">Profile ID</param>
        /// <returns>A boolean, indicating whether the profile exists in the database.</returns>
        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.Id == id);
        }
    }
}
