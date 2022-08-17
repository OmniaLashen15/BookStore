using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreData.Migrations
{
    public partial class editBookpropertyinAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);
        }
    }
}
