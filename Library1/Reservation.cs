using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class Reservation
    {
        public int IdReservation { get; set; }
        public int IdLibraryCard { get; set; }
        public DateTime ReservationDate { get; set; }
        public int IdBook { get; set; }

        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual LibraryCard IdLibraryCardNavigation { get; set; } = null!;
    }
}
