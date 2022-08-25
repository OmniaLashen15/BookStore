using BookStoreAPI.DTOs;
using BookStoreData;
using BookStoreDomain;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Services
{
    public class AuthorBookService : IRepository<AuthorBook>
    {
        private readonly BookStoreContext _context;
        public AuthorBookService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<AuthorBook> Delete(Guid id)
        {
            var result = await _context.Books_Authors.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            _context.Books_Authors.Remove(result);
            _context.SaveChanges();
            return result;
        }

        public async Task<List<AuthorBook>> GetAll()
        {
            var list = await _context.Books_Authors.Include(a => a.Author).Include(b => b.Book).ToListAsync();
            return list;
        }

        public async Task<AuthorBook> GetById(Guid id)
        {
            var result = await _context.Books_Authors.Include(a => a.Author).Include(b => b.Book).FirstOrDefaultAsync(ba => ba.Id == id);
            return result;
        }

        public async Task<AuthorBook> Insert(AuthorBook authorBook)
        {
            _context.Books_Authors.Add(authorBook);
            await _context.SaveChangesAsync();
            return authorBook;
        }

        public Task<AuthorBook> Search(string word)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorBook> Update(AuthorBook authorBook)
        {
            _context.Books_Authors.Update(authorBook);
            await _context.SaveChangesAsync();
            return authorBook;
        }
        public static AuthorBook BookFromDTO(AuthorBookDTO authorBookDTO)
        {
            return new AuthorBook
            {
                Id = authorBookDTO.Id,
                AuthorId = authorBookDTO.AuthorId,
                BookId= authorBookDTO.BookId
            };
        }


        public static AuthorBookDTO BookToDTO(AuthorBook authorBook)
        {
            return new AuthorBookDTO
            {
                Id= authorBook.Id,
                AuthorId= authorBook.AuthorId,
                BookId= authorBook.BookId 
            };
        }
    }
}

