using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class Book
    {
        public Book()
        {
            CopyOfTheBooks = new HashSet<CopyOfTheBook>();
            Reservations = new HashSet<Reservation>();
        }

        public int IdBook { get; set; }
        public string BookSTitle { get; set; } = null!;
        public int RackNumber { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int BooksInStock { get; set; }
        public string BookGenre { get; set; } = null!;
        public int IdPublisher { get; set; }

        public virtual Publisher IdPublisherNavigation { get; set; } = null!;
        public virtual ICollection<CopyOfTheBook> CopyOfTheBooks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
