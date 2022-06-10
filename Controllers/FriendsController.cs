using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMySQL.Models;
using WebApiMySQL.Data;

namespace WebApiMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly WebApiMySQLContext _context;

        public FriendsController(WebApiMySQLContext context)
        {
            _context = context;
        }

        // GET: api/Friends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriends()
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            return await _context.Friends
                .ToListAsync();
        }

        // GET: api/Friends
        [HttpGet("{id}/videos")]
        public async Task<ActionResult<IEnumerable<Object>>> GetVideos(int id)
        {
            if (_context.Friends == null || _context.Videos == null)
            {
                return NotFound();
            }
            return await _context.Videos.Select(c => new
            {
                c.Id,
                c.MovieTitle,
                c.Subject,
                c.Length,
                c.Rating,
                c.FriendId
            }).Where(c => c.FriendId == id)
                .ToListAsync();
        }

        // GET: api/Friends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Friend>> GetFriend(int id)
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            var friend = await _context.Friends.FindAsync(id);

            if (friend == null)
            {
                return NotFound();
            }
            return friend;
        }

        // PUT: api/Friends/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriend(int id, Friend friend)
        {
            if (id != friend.Id)
            {
                return BadRequest();
            }

            _context.Entry(friend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExists(id))
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

        // POST: api/Friends
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Friend>> PostFriend(Friend friend)
        {
          if (_context.Friends == null)
          {
              return Problem("Entity set 'WebApiMySQLContext.Friends'  is null.");
          }
            _context.Friends.Add(friend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriend", new { id = friend.Id }, friend);
        }

        // DELETE: api/Friends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriend(int id)
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            var friend = await _context.Friends.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }

            _context.Friends.Remove(friend);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FriendExists(int id)
        {
            return (_context.Friends?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
