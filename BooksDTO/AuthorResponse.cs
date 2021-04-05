using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDTO
{
    public class AuthorResponse : Author
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
