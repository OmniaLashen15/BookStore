using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreData;
using BookStoreDomain;
using BookStoreAPI.DTOs;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorsController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            //return await _context.Authors.Include(a => a.Book).ToListAsync();
            return await _context.Authors
                .Select(a => new AuthorDTO
                {
                    AuthorId = a.AuthorId,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    ImageURL = a.ImageURL,
                    AboutTheAuthor = a.AboutTheAuthor
                })
                .ToListAsync();

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            //return author;
            return AuthorToDTO(author);

        }
        private static AuthorDTO AuthorToDTO(Author author)
        {
            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                ImageURL = author.ImageURL,
                AboutTheAuthor = author.AboutTheAuthor
            };
        }
        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorDTO authorDTO)
        {
            if (id != authorDTO.AuthorId)
            {
                return BadRequest();
            }
            Author author = AuthorFromDTO(authorDTO);
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO authorDTO)
        {
          if (_context.Authors == null)
          {
              return Problem("Entity set 'BookStoreContext.Authors'  is null.");
          }
            var author = AuthorFromDTO(authorDTO);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, AuthorToDTO(author));
        }

        private static Author AuthorFromDTO(AuthorDTO authorDTO)
        {
            return new Author
            {
                AuthorId = authorDTO.AuthorId,
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName,
                AboutTheAuthor = authorDTO.AboutTheAuthor,
                Email = authorDTO.Email,
                ImageURL = authorDTO.ImageURL
            };
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            //It doesn't require DTO as it only takes the id and doesn't return anything
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        }
    }
}
