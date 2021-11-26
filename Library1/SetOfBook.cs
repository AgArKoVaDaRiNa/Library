using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class SetOfBook
    {
        public int IdReservation { get; set; }
        public int IdBook { get; set; }
        public Reservation Reservation { get; set; }
        public Book Book { get; set; }
    }
}
