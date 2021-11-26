using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class LibraryCard
    {
        public LibraryCard()
        {
            IssuingBooks = new HashSet<IssuingBook>();
            Reservations = new HashSet<Reservation>();
        }

        public int IdLibraryCard { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string ReaderSAddress { get; set; } = null!;
        public DateTime ReaderSDateOfBirth { get; set; }

        public virtual ICollection<IssuingBook> IssuingBooks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
