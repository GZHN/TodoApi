using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/GroceryItems")]
    [ApiController]
    public class GroceryItemsController : ControllerBase
    {
        private readonly GroceryContext _context;

        public GroceryItemsController(GroceryContext context)
        {
            _context = context;           
        }

        // GET: api/GroceryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryItem>>> GetGroceryItems()
        {
            return await _context.GroceryItems.ToListAsync();
        }

        // GET: api/GroceryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryItem>> GetGroceryItem(long id)
        {
            var groceryItem = await _context.GroceryItems.FindAsync(id);

            if (groceryItem == null)
            {
                return NotFound();
            }

            return groceryItem;
        }


        // POST: api/GroceryItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroceryItem>> PostGroceryItem(GroceryItem groceryItem)
        {
            _context.GroceryItems.Add(groceryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroceryItem), new { id = groceryItem.Id }, groceryItem);
        }

        // DELETE: api/GroceryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryItem>> DeleteGroceryItem(long id)
        {
            var groceryItem = await _context.GroceryItems.FindAsync(id);
            if (groceryItem == null)
            {
                return NotFound();
            }

            _context.GroceryItems.Remove(groceryItem);
            await _context.SaveChangesAsync();

            return groceryItem;
        }

        private bool GroceryItemExists(long id)
        {
            return _context.GroceryItems.Any(e => e.Id == id);
        }
    }
}
