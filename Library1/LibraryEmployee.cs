using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class LibraryEmployee
    {
        public LibraryEmployee()
        {
            IssuingBooks = new HashSet<IssuingBook>();
        }

        public int IdEmployee { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string BookDepartment { get; set; } = null!;

        public virtual ICollection<IssuingBook> IssuingBooks { get; set; }
    }
}
