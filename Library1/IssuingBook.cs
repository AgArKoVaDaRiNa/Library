using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class IssuingBook
    {
        public int IdIssuance { get; set; }
        public int IdLibraryCard { get; set; }
        public int IdCopy { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public int IdEmployee { get; set; }

        public virtual CopyOfTheBook IdCopyNavigation { get; set; } = null!;
        public virtual LibraryEmployee IdEmployeeNavigation { get; set; } = null!;
        public virtual LibraryCard IdLibraryCardNavigation { get; set; } = null!;
    }
}
