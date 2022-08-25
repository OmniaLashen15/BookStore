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
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var booksList = await _bookRepo.GetAll();
            var booksDTOList = new List<BookDTO>();
          if (booksList == null)
          {
              return NotFound();
          }
          foreach (var book in booksList)
            {
                booksDTOList.Add(BookService.BookToDTO(book));
            }
          return Ok(booksDTOList);

        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(Guid id)
        {
            var book = await _bookRepo.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(BookService.BookToDTO(book));

        }
        // GET: api/Books/
        [HttpGet("Book/{name}")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> SearchForBook(string name)
        {

            var books = await _bookRepo.SearchByKeyword(name);
            var bookDTOList = new List<BookDTO>();
            if (books == null)
            {
                return NotFound();
            }
            foreach(var book in books)
            {
                bookDTOList.Add(BookService.BookToDTO(book));
            }
            return Ok(bookDTOList);

        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, BookDTO book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            try
            {
               
                var UpdatedBook = await _bookRepo.Update(BookService.BookFromDTO(book));
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
        public async Task<ActionResult<BookDTO>> PostBook(BookDTO book)
        {

            try
            {
                if (book == null)
                {
                    return BadRequest();
                }
                var _book = await _bookRepo.GetBookByISBN(book.ISBN);

                if (_book != null)
                {
                    ModelState.AddModelError("isbn", "Book isbn is already in use");
                    return BadRequest();
                }
                var createdBook = await _bookRepo.Insert(BookService.BookFromDTO(book));

                return CreatedAtAction("GetBook", new { id = book.BookId }, book);
            }
             catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var BooksList = await _bookRepo.GetAll();
            if (BooksList == null || _bookRepo.GetById(id) == null)
            {
                return NotFound();
            }
             await _bookRepo.Delete(id);


            return NoContent();
        }

    }
}
