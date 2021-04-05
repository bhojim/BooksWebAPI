using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDTO
{
    public class BookResponse : Book
    {
        public Author Author { get; set; }
    }
}
