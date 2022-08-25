using BookStoreAPI.DTOs;
using BookStoreData;
using BookStoreDomain;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI
{
    public class AuthorService : IAuthorRepository
    {
        private readonly BookStoreContext _context;
        public AuthorService(BookStoreContext context)
        {
            _context = context;
        }


        public async Task<List<Author>> GetAll()
        {
            var authersList = await _context.Authors.Include(b => b.Book_Authors).ToListAsync();
            return authersList;

        }
        public async Task<Author> GetAuthorByEmail(string email)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(a=>a.Email == email);
            return author;
        }

        public async Task<Author> GetById(Guid id)
        {
            var author = await _context.Authors.Include(b => b.Book_Authors).FirstOrDefaultAsync(a => a.AuthorId == id);
            return author;
        }

        public async Task<Author> Insert(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Delete(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return null;
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return author;

        }

        public async Task<List<Author>> SearchByName(string word)
        {
            var author = await _context.Authors.Where(a => (a.FirstName + " " + a.LastName).ToLower().Contains(word)).ToListAsync();
            return author;

        }

        public static Author AuthorFromDTO(AuthorDTO authorDTO)
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


        public static AuthorDTO AuthorToDTO(Author author)
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

    }
}
