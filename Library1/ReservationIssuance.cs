using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class ReservationIssuance
    {
        public int IdIssuance { get; set; }
        public int IdReservation { get; set; }
        public IssuingBook Issuance { get; set; }
        public Reservation Reservation { get; set; }
    }
}
