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
using BookStoreAPI.Repository;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepository<Author> _authorRepo;

        public AuthorsController(IRepository<Author> authorRepo)
        {
            _authorRepo = authorRepo;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authorsList = await _authorRepo.GetAll();
          if (authorsList == null)
          {
              return NotFound();
          }
          return Ok(authorsList);

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorRepo.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);

        }
        // GET: api/Authors/
        [HttpGet("Author/{name}")]
        public async Task<ActionResult<Author>> SearchForAuthor(string name)
        {
            var author = await _authorRepo.Search(name);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);

        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            try
            {
                var Updatedauthor = await _authorRepo.Update(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_authorRepo.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(author);
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
       
            if(author == null)
            {
                return BadRequest();
            }
             await _authorRepo.Insert(author);

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId },author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var authorsList = await _authorRepo.GetAll();
            if (authorsList == null)
            {
                return NotFound();
            }
            var author = await _authorRepo.Delete(id);
            if (author == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
