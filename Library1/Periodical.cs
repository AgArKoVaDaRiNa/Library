using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class Periodical
    {
        public int IdEdition { get; set; }
        public string EditionTitle { get; set; } = null!;
        public int EditionNumber { get; set; }
        public DateTime EditionDate { get; set; }
        public int IdPublisher { get; set; }
        public string ReadingPlace { get; set; } = null!;

        public virtual Publisher IdPublisherNavigation { get; set; } = null!;
    }
}
