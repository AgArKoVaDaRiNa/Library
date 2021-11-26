using System;
using System.Collections.Generic;

namespace Library1
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
            Periodicals = new HashSet<Periodical>();
        }

        public int IdPublisher { get; set; }
        public string PublisherName { get; set; } = null!;
        public string PublisherAddress { get; set; } = null!;
        public string PublishingCity { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Periodical> Periodicals { get; set; }
    }
}
