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
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepo;

        public BooksController(IRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var booksList = await _bookRepo.GetAll();
          if (booksList == null)
          {
              return NotFound();
          }
          return Ok(booksList);

        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepo.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);

        }
        // GET: api/Books/
        [HttpGet("Book/{name}")]
        public async Task<ActionResult<Book>> SearchForBook(string name)
        {
            var book = await _bookRepo.Search(name);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);

        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            try
            {
                var UpdatedBook = await _bookRepo.Update(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_bookRepo.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
       
            if(book == null)
            {
                return BadRequest();
            }
             await _bookRepo.Insert(book);

            return CreatedAtAction("GetBook", new { id = book.BookId },book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var BooksList = await _bookRepo.GetAll();
            if (BooksList == null)
            {
                return NotFound();
            }
            var book = await _bookRepo.Delete(id);
            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
