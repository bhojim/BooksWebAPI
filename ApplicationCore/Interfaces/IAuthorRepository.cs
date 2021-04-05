using ApplicationCore.DTO;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>, IAsyncRepository<Author>
    {
        Task<Author> GetAuthor(int id);

        Task<IEnumerable<AuthorDTO>> GetAuthors();
        Task SaveAuthor(Author author);
        Task AddAuthor(Author author);

        Task DeleteAuthor(Author author);

        bool AuthorExists(int id);
    }
}
