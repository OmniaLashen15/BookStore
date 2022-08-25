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
using BookStoreAPI.Services;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsBooksController : ControllerBase
    {
        private readonly IRepository<AuthorBook> _authorBookRepo;

        public AuthorsBooksController(IRepository<AuthorBook> authorBookRepo)
        {
            _authorBookRepo = authorBookRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorBookDTO>>> GetAuthors()
        {
            var list = await _authorBookRepo.GetAll();
            var DTOList = new List<AuthorBookDTO>();
          if (list == null)
          {
              return NotFound();
          }
          foreach (var item in list)
            {
                DTOList.Add(AuthorBookService.BookToDTO(item));
            }
          return Ok(list);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBookDTO>> GetAuthor(Guid id)
        {
            
            var result = await _authorBookRepo.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(AuthorBookService.BookToDTO(result));

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(Guid id, AuthorBookDTO authorBook)
        {
            if (id != authorBook.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _authorBookRepo.Update(AuthorBookService.BookFromDTO(authorBook));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_authorBookRepo.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(authorBook);
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<AuthorBookDTO>> PostAuthor(AuthorBookDTO authorBook)
        {
       
            if(authorBook == null)
            {
                return BadRequest();
            }
             await _authorBookRepo.Insert(AuthorBookService.BookFromDTO(authorBook));

            return CreatedAtAction("GetAuthor", new { id = authorBook.Id },authorBook);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var authorsList = await _authorBookRepo.GetAll();
            if (authorsList == null)
            {
                return NotFound();
            }
            var author = await _authorBookRepo.Delete(id);
            if (author == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
