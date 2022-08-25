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
        private readonly IAuthorRepository _authorRepo;

        public AuthorsController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authorsList = await _authorRepo.GetAll();
            var authoesDTOList = new List<AuthorDTO>();
          if (authorsList == null)
          {
              return NotFound();
          }
          foreach (var author in authorsList)
            {
               authoesDTOList.Add(AuthorService.AuthorToDTO(author));
            }
          return Ok(authoesDTOList);

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(Guid id)
        {
            
            var author = await _authorRepo.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(AuthorService.AuthorToDTO(author));

        }
        // GET: api/Authors/
        [HttpGet("Author/{name}")]
        public async Task<ActionResult<List<AuthorDTO>>> SearchForAuthor(string name)
        {
            var authors = await _authorRepo.SearchByName(name);
            var authorDTOList = new List<AuthorDTO>();
            if (authors == null)
            {
                return NotFound();
            }
            foreach(var author in authors)
            {
                authorDTOList.Add(AuthorService.AuthorToDTO(author));
            }
            return Ok(authorDTOList);

        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(Guid id, AuthorDTO author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

           try
            {
                
                var Updatedauthor = await _authorRepo.Update(AuthorService.AuthorFromDTO(author));
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
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO author)
        {

            try
            {
                if (author == null)
                {
                    return BadRequest();
                }
               var auth = await _authorRepo.GetAuthorByEmail(author.Email);

                if(auth != null)
                {
                    ModelState.AddModelError("email","Author email is already in use");
                    return BadRequest();
                } 
                var createdAuthor = await _authorRepo.Insert(AuthorService.AuthorFromDTO(author));

                return CreatedAtAction("GetAuthor", new { id = createdAuthor.AuthorId }, author);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
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
