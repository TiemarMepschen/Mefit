using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mefit_API.Models;
using AutoMapper;
using Mefit_API.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Mefit_API.DTOs.Profile;

namespace Mefit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MefitDbContext _context;
        private readonly IMapper _mapper;

        public UserController(MefitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Get

        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <returns>A list of all users in the database</returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetUser()
        {
            //TODO: Return 303 See Other with the location header set to the URL of the currently authenticated user's profile.

            var user = await _context.User.ToListAsync();

            return Ok(_mapper.Map<List<UserReadDTO>>(user));
        }

        /// <summary>
        /// Get a specific user from the database by keycloak ID
        /// </summary>
        /// <param name="id">Keycloak ID</param>
        /// <returns>A user from the database</returns>
        //[Authorize]
        [Authorize]
        [HttpGet("{id}/keycloakId")]
        public async Task<ActionResult<UserReadDTO>> GetUser(string id)
        {
            var user = await _context.User.Include(p => p.Profile).FirstOrDefaultAsync(p => p.KeycloakId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserReadDTO>(user));
        }

        /// <summary>
        /// Get a specific user from the database by user ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>A user from the database</returns>
        [Authorize]
        [HttpGet("{id}/userId")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            var user = await _context.User.Include(p => p.Profile).FirstOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserReadDTO>(user));
        }

        [Authorize]
        [HttpGet("{id}/profile")]
        public async Task<ActionResult<ProfileReadDTO>> GetProfileFromUser(int id)
        {
            var user = await _context.User.Include(p => p.Profile).FirstOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProfileReadDTO>(user.Profile));
        }

        #endregion

        #region Put

        /// <summary>
        /// Updates a user in the database
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="newUser">The user data to update.</param>
        /// <returns>A responsetype indicating success and whether the user was found.</returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDTO newUser)
        {
            var domainUser = _mapper.Map<User>(newUser);

            if (id != domainUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(domainUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        /// Adds a new user to the database
        /// </summary>
        /// <param name="newUser">The user data to add to the database.</param>
        /// <returns>The user data, indicating success.</returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] UserCreateDTO newUser)
        {
            var domainUser = _mapper.Map<User>(newUser);

            _context.User.Add(domainUser);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction("GetUser", new { id = domainUser.Id }, newUser);
        }

        #endregion

        /// <summary>
        /// Checks if a user exists in the database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>A boolean, indicating whether the user exists in the database.</returns>
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
