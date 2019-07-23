using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllAboutFood.Models.EF;

namespace AllAboutFood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly AllAboutFoodContext _context;

        public RestaurantController(AllAboutFoodContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        [HttpGet("Lookup/{lookup}")]        
        public async Task<ActionResult<IEnumerable<Restaurant.RestaurantLookup>>> GetByLookup(string lookup)
        {
            return await _context.Restaurant.Where(r => r.Name.Contains(lookup)).Select(r => r.MyLookupValue()).ToListAsync();
        }

        // GET: Restaurant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> Get(int id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: Restaurant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: Restaurant
        [HttpPost]
        public async Task<ActionResult<Restaurant>> Post(Restaurant restaurant)
        {
            _context.Restaurant.Add(restaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: Restaurant/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> Delete(int id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();

            return restaurant;
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurant.Any(e => e.Id == id);
        }
    }    
}
