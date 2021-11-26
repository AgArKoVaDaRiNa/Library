using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class CopyOfTheBook
    {
        public CopyOfTheBook()
        {
            IssuingBooks = new HashSet<IssuingBook>();
        }

        public int IdCopy { get; set; }
        public int IdBook { get; set; }
        public CopyOfTheBook Copy { get; set; }
        public Book Book { get; set; }


        public virtual Book IdBookNavigation { get; set; } = null!;
        public virtual ICollection<IssuingBook> IssuingBooks { get; set; }
    }
}
