using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMySQL.Data;
using WebApiMySQL.Models;

namespace WebApiMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly WebApiMySQLContext _context;

        public VideosController(WebApiMySQLContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoCollection>>> GetVideos()
        {
          if (_context.Videos == null)
          {
              return NotFound();
          }
            return await _context.Videos.Include(c => c.Friend)
                .ToListAsync();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoCollection>> GetVideoCollection(int id)
        {
          if (_context.Videos == null)
          {
              return NotFound();
          }
            var videoCollection = await _context.Videos
                .Include(c=>c.Friend).FirstOrDefaultAsync(i=> i.Id == id);

            if (videoCollection == null)
            {
                return NotFound();
            }

            return videoCollection;
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoCollection(int id, VideoCollection videoCollection)
        {
            if (id != videoCollection.Id)
            {
                return BadRequest();
            }

            _context.Entry(videoCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoCollectionExists(id))
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

        // POST: api/Videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoCollection>> PostVideoCollection(VideoCollection videoCollection)
        {
          if (_context.Videos == null)
          {
              return Problem("Entity set 'WebApiMySQLContext.Videos'  is null.");
          }
            _context.Videos.Add(videoCollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoCollection", new { id = videoCollection.Id }, videoCollection);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoCollection(int id)
        {
            if (_context.Videos == null)
            {
                return NotFound();
            }
            var videoCollection = await _context.Videos.FindAsync(id);
            if (videoCollection == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(videoCollection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoCollectionExists(int id)
        {
            return (_context.Videos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
