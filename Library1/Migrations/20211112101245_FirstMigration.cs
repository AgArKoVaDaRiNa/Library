using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library1.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    IdAuthor = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdAuthor", x => x.IdAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Authors books",
                columns: table => new
                {
                    IdBook = table.Column<int>(type: "int", nullable: false),
                    IdAuthor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Authors __7D80ACA9E1C8E282", x => new { x.IdBook, x.IdAuthor });
                });

            migrationBuilder.CreateTable(
                name: "BuyingBook",
                columns: table => new
                {
                    IdBuying = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBook = table.Column<int>(type: "int", nullable: false),
                    Buying = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BuyingBo__57D2F209DE8B724F", x => x.IdBuying);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCard",
                columns: table => new
                {
                    IdLibraryCard = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ReadersAddress = table.Column<string>(name: "Reader`sAddress", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReadersDateOfBirth = table.Column<DateTime>(name: "Reader`sDateOfBirth", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdLibraryCard", x => x.IdLibraryCard);
                });

            migrationBuilder.CreateTable(
                name: "LibraryEmployee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    BookDepartment = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdEmployee", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    IdPublisher = table.Column<int>(type: "int", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublisherAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublishingCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdPublisher", x => x.IdPublisher);
                });

            migrationBuilder.CreateTable(
                name: "ReservationIssuance",
                columns: table => new
                {
                    IdIssuance = table.Column<int>(type: "int", nullable: false),
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__1B111D51050AECDE", x => new { x.IdIssuance, x.IdReservation });
                });

            migrationBuilder.CreateTable(
                name: "SetOfBook",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SetOfBoo__DC1CC9C6FDA60E13", x => new { x.IdReservation, x.IdBook });
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    IdBook = table.Column<int>(type: "int", nullable: false),
                    BooksTitle = table.Column<string>(name: "Book`sTitle", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RackNumber = table.Column<int>(type: "int", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "date", nullable: true),
                    BooksInStock = table.Column<int>(type: "int", nullable: false),
                    BookGenre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IdPublisher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdBook", x => x.IdBook);
                    table.ForeignKey(
                        name: "FK_Library_IdPublisher",
                        column: x => x.IdPublisher,
                        principalTable: "Publisher",
                        principalColumn: "IdPublisher");
                });

            migrationBuilder.CreateTable(
                name: "Periodicals",
                columns: table => new
                {
                    IdEdition = table.Column<int>(type: "int", nullable: false),
                    EditionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EditionNumber = table.Column<int>(type: "int", nullable: false),
                    EditionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdPublisher = table.Column<int>(type: "int", nullable: false),
                    ReadingPlace = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdEdition", x => x.IdEdition);
                    table.ForeignKey(
                        name: "FK_Library_Publisher_Periodicals",
                        column: x => x.IdPublisher,
                        principalTable: "Publisher",
                        principalColumn: "IdPublisher");
                });

            migrationBuilder.CreateTable(
                name: "CopyOfTheBook",
                columns: table => new
                {
                    IdCopy = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdCopy", x => x.IdCopy);
                    table.ForeignKey(
                        name: "FK_Library_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Book",
                        principalColumn: "IdBook");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false),
                    IdLibraryCard = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linbrary_IdReservation", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Library_IdBook_Reservation",
                        column: x => x.IdBook,
                        principalTable: "Book",
                        principalColumn: "IdBook");
                    table.ForeignKey(
                        name: "FK_Library_LibraryCard_Reservation",
                        column: x => x.IdLibraryCard,
                        principalTable: "LibraryCard",
                        principalColumn: "IdLibraryCard");
                });

            migrationBuilder.CreateTable(
                name: "IssuingBooks",
                columns: table => new
                {
                    IdIssuance = table.Column<int>(type: "int", nullable: false),
                    IdLibraryCard = table.Column<int>(type: "int", nullable: false),
                    IdCopy = table.Column<int>(type: "int", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_IdIssuance", x => x.IdIssuance);
                    table.ForeignKey(
                        name: "FK_Library_IdCopy",
                        column: x => x.IdCopy,
                        principalTable: "CopyOfTheBook",
                        principalColumn: "IdCopy");
                    table.ForeignKey(
                        name: "FK_Library_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "LibraryEmployee",
                        principalColumn: "IdEmployee");
                    table.ForeignKey(
                        name: "FK_Library_IdLibraryCard",
                        column: x => x.IdLibraryCard,
                        principalTable: "LibraryCard",
                        principalColumn: "IdLibraryCard");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdPublisher",
                table: "Book",
                column: "IdPublisher");

            migrationBuilder.CreateIndex(
                name: "IX_CopyOfTheBook_IdBook",
                table: "CopyOfTheBook",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_IssuingBooks_IdCopy",
                table: "IssuingBooks",
                column: "IdCopy");

            migrationBuilder.CreateIndex(
                name: "IX_IssuingBooks_IdEmployee",
                table: "IssuingBooks",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_IssuingBooks_IdLibraryCard",
                table: "IssuingBooks",
                column: "IdLibraryCard");

            migrationBuilder.CreateIndex(
                name: "IX_Periodicals_IdPublisher",
                table: "Periodicals",
                column: "IdPublisher");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdBook",
                table: "Reservation",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdLibraryCard",
                table: "Reservation",
                column: "IdLibraryCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Authors books");

            migrationBuilder.DropTable(
                name: "BuyingBook");

            migrationBuilder.DropTable(
                name: "IssuingBooks");

            migrationBuilder.DropTable(
                name: "Periodicals");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "ReservationIssuance");

            migrationBuilder.DropTable(
                name: "SetOfBook");

            migrationBuilder.DropTable(
                name: "CopyOfTheBook");

            migrationBuilder.DropTable(
                name: "LibraryEmployee");

            migrationBuilder.DropTable(
                name: "LibraryCard");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
