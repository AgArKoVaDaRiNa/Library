using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library1.Migrations
{
    public partial class AuthorAgeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Author",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Author");
        }
    }
}
