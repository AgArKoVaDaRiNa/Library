using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class Author
    {
        public int IdAuthor { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public int Age { get; set; }
    }
}
