using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreData.Migrations
{
    public partial class updateauthorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "AuthorId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "BasePrice", "Genre", "ISBN", "Keywords", "PublishDate", "BookTitle" },
                values: new object[] { 1, 1, 0m, "0", "0596007124", "first", new DateTime(2004, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Head First Design Patterns" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "AuthorId",
                value: 1);
        }
    }
}
