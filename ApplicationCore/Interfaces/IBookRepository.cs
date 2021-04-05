using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IBookRepository : IRepository<Book>, IAsyncRepository<Book>
    {
        Task AddBook(Book book);
        Task DeleteBook(Book book);
        Task<Book> GetBook(int id);
        Task<IEnumerable<Book>> GetBooks();
        Task SaveBook(Book book);
    }
}