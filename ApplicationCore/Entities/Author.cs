using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationCore.Entities
{
    public class Author : BaseEntity
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        //public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
