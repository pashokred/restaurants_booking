using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsDishesController : ControllerBase
    {
        private readonly RestaurantsContext _context;

        public RestaurantsDishesController(RestaurantsContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantsDishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantsDishes>>> GetRestaurantsDishes()
        {
            return await _context.RestaurantsDishes.ToListAsync();
        }

        // GET: api/RestaurantsDishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantsDishes>> GetRestaurantsDishes(int id)
        {
            var restaurantsDishes = await _context.RestaurantsDishes.FindAsync(id);

            if (restaurantsDishes == null)
            {
                return NotFound();
            }

            return restaurantsDishes;
        }

        // PUT: api/RestaurantsDishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantsDishes(int id, RestaurantsDishes restaurantsDishes)
        {
            if (id != restaurantsDishes.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantsDishes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantsDishesExists(id))
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

        // POST: api/RestaurantsDishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantsDishes>> PostRestaurantsDishes(RestaurantsDishes restaurantsDishes)
        {
            _context.RestaurantsDishes.Add(restaurantsDishes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantsDishes", new { id = restaurantsDishes.Id }, restaurantsDishes);
        }

        // DELETE: api/RestaurantsDishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantsDishes(int id)
        {
            var restaurantsDishes = await _context.RestaurantsDishes.FindAsync(id);
            if (restaurantsDishes == null)
            {
                return NotFound();
            }

            _context.RestaurantsDishes.Remove(restaurantsDishes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantsDishesExists(int id)
        {
            return _context.RestaurantsDishes.Any(e => e.Id == id);
        }
    }
}
