using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationCore.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
