using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library1
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorsBook> AuthorsBooks { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BuyingBook> BuyingBooks { get; set; } = null!;
        public virtual DbSet<CopyOfTheBook> CopyOfTheBooks { get; set; } = null!;
        public virtual DbSet<IssuingBook> IssuingBooks { get; set; } = null!;
        public virtual DbSet<LibraryCard> LibraryCards { get; set; } = null!;
        public virtual DbSet<LibraryEmployee> LibraryEmployees { get; set; } = null!;
        public virtual DbSet<Periodical> Periodicals { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationIssuance> ReservationIssuances { get; set; } = null!;
        public virtual DbSet<SetOfBook> SetOfBooks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SOSU5R3\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("PK_Library_IdAuthor");

                entity.ToTable("Author");

                entity.Property(e => e.IdAuthor).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Patronymic).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<AuthorsBook>(entity =>
            {
                entity.HasKey(e => new { e.IdBook, e.IdAuthor })
                    .HasName("PK__Authors __7D80ACA9E1C8E282");

                entity.ToTable("Authors books");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IdBook)
                    .HasName("PK_Library_IdBook");

                entity.ToTable("Book");

                entity.Property(e => e.IdBook).ValueGeneratedNever();

                entity.Property(e => e.BookGenre).HasMaxLength(25);

                entity.Property(e => e.BookSTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Book`sTitle");

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.HasOne(d => d.IdPublisherNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdPublisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_IdPublisher");
            });

            modelBuilder.Entity<BuyingBook>(entity =>
            {
                entity.HasKey(e => e.IdBuying)
                    .HasName("PK__BuyingBo__57D2F209DE8B724F");

                entity.ToTable("BuyingBook");

                entity.Property(e => e.Buying).HasMaxLength(100);
            });

            modelBuilder.Entity<CopyOfTheBook>(entity =>
            {
                entity.HasKey(e => e.IdCopy)
                    .HasName("PK_Library_IdCopy");

                entity.ToTable("CopyOfTheBook");

                entity.Property(e => e.IdCopy).ValueGeneratedNever();

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.CopyOfTheBooks)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_IdBook");
            });

            modelBuilder.Entity<IssuingBook>(entity =>
            {
                entity.HasKey(e => e.IdIssuance)
                    .HasName("PK_Library_IdIssuance");

                entity.Property(e => e.IdIssuance).ValueGeneratedNever();

                entity.Property(e => e.DateOfIssue).HasColumnType("datetime");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCopyNavigation)
                    .WithMany(p => p.IssuingBooks)
                    .HasForeignKey(d => d.IdCopy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_IdCopy");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.IssuingBooks)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_IdEmployee");

                entity.HasOne(d => d.IdLibraryCardNavigation)
                    .WithMany(p => p.IssuingBooks)
                    .HasForeignKey(d => d.IdLibraryCard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_IdLibraryCard");
            });

            modelBuilder.Entity<LibraryCard>(entity =>
            {
                entity.HasKey(e => e.IdLibraryCard)
                    .HasName("PK_Library_IdLibraryCard");

                entity.ToTable("LibraryCard");

                entity.Property(e => e.IdLibraryCard).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Patronymic).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReaderSAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Reader`sAddress");

                entity.Property(e => e.ReaderSDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Reader`sDateOfBirth");

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<LibraryEmployee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK_Library_IdEmployee");

                entity.ToTable("LibraryEmployee");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

                entity.Property(e => e.BookDepartment).HasMaxLength(20);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Patronymic).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<Periodical>(entity =>
            {
                entity.HasKey(e => e.IdEdition)
                    .HasName("PK_Library_IdEdition");

                entity.Property(e => e.IdEdition).ValueGeneratedNever();

                entity.Property(e => e.EditionDate).HasColumnType("datetime");

                entity.Property(e => e.EditionTitle).HasMaxLength(50);

                entity.Property(e => e.ReadingPlace).HasMaxLength(15);

                entity.HasOne(d => d.IdPublisherNavigation)
                    .WithMany(p => p.Periodicals)
                    .HasForeignKey(d => d.IdPublisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_Publisher_Periodicals");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.IdPublisher)
                    .HasName("PK_Library_IdPublisher");

                entity.ToTable("Publisher");

                entity.Property(e => e.IdPublisher).ValueGeneratedNever();

                entity.Property(e => e.PublisherAddress).HasMaxLength(50);

                entity.Property(e => e.PublisherName).HasMaxLength(30);

                entity.Property(e => e.PublishingCity).HasMaxLength(30);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("PK_Linbrary_IdReservation");

                entity.ToTable("Reservation");

                entity.Property(e => e.IdReservation).ValueGeneratedNever();

                entity.Property(e => e.ReservationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_IdBook_Reservation");

                entity.HasOne(d => d.IdLibraryCardNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdLibraryCard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_LibraryCard_Reservation");
            });

            modelBuilder.Entity<ReservationIssuance>(entity =>
            {
                entity.HasKey(e => new { e.IdIssuance, e.IdReservation })
                    .HasName("PK__Reservat__1B111D51050AECDE");

                entity.ToTable("ReservationIssuance");
            });

            modelBuilder.Entity<SetOfBook>(entity =>
            {
                entity.HasKey(e => new { e.IdReservation, e.IdBook })
                    .HasName("PK__SetOfBoo__DC1CC9C6FDA60E13");

                entity.ToTable("SetOfBook");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
