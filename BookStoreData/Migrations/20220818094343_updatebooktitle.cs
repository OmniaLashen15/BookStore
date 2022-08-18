using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreData.Migrations
{
    public partial class updatebooktitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookTitle",
                table: "Books",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "BookTitle");
        }
    }
}
