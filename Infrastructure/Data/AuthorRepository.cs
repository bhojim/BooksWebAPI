using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AuthorRepository : EfRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreContext dbContext) : base(dbContext)
        {
        }

        public async Task<Author> GetAuthor(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            return author;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAuthors()
        {
             var authors = await _dbContext.Authors.Include(a => a.Books)
                .Select(x => new AuthorDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Books = x.Books
                        .Select(b =>
                        new BookDTO
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Genre = b.Genre,
                            Price = b.Price,
                            Year = b.Year,
                            AuthorId = b.AuthorId
                        })
                        .ToList()
                }).ToListAsync();
            return authors;
        }

        public async Task SaveAuthor(Author author)
        {
            _dbContext.Entry(author).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAuthor(Author author)
        {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
        public bool AuthorExists(int id)
        {
            return _dbContext.Authors.Any(e => e.Id == id);
        }
    }
}
