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
    public class BookRepository : EfRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            return book;
        }

        public async Task SaveBook(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        private bool BookExists(int id)
        {
            return _dbContext.Books.Any(e => e.Id == id);
        }

    }
}
