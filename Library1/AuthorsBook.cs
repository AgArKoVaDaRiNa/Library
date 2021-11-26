using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class AuthorsBook
    {
        public int IdBook { get; set; }
        public int IdAuthor { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
