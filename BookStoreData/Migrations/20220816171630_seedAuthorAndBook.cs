using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreData.Migrations
{
    public partial class seedAuthorAndBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AboutTheAuthor", "Email", "FirstName", "ImageURL", "LastName" },
                values: new object[] { 1, "She is the co-creator of the Head First series of books on technical (primarily computer) topics, along with her partner, Bert Bates. The series, which began with Head First Java in 2003,[4] takes an unorthodox, visually intensive approach to the process of teaching programming. Sierra's books in the series have received three nominations for Product Excellence Jolt Awards, winning in 2005 for Head First Design Patterns, and were recognized on Amazon.com's yearly top 10 list for computer books from 2003 to 2005.[5] In 2005 she coined the phrase 'The Kool - Aid Point' to describe the point at which detractors emerge purely due to the popularity of a topic being promoted by others.", "Kathy.Sierra@gmail.com", "Kathy", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Kathy_Sierra_1a.jpg/330px-Kathy_Sierra_1a.jpg", "Sierra" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AboutTheAuthor", "Email", "FirstName", "ImageURL", "LastName" },
                values: new object[] { 2, "Erich Gamma (born 1961 in Zürich) is a Swiss computer scientist and one of the four co-authors (referred to as 'Gang of Four') of the software engineering textbook, Design Patterns: Elements of Reusable Object-Oriented Software.", "egamma@microsoft.com", "Erich", "https://www.inspiringquotes.us/data/image/2019/8/c/8751-erich-gamma.jpg", "Gamma" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AboutTheAuthor", "Email", "FirstName", "ImageURL", "LastName" },
                values: new object[] { 3, "Judith Bishop has had a distinguished background in academia. She has published over 80 papers in areas ranging from programming languages to distributed and web-based systems. She authored one of the first Java programming texts, Java Gently, now in its third edition. She is a Founding Fellow of the South African Institute for Computer Scientists and Information Technologists and in 2005 was recognized as Distinguished Woman Scientist of the Year in South Africa. She is a Fellow of the British Computer Society and of the Royal Society of South Africa.", "Judith.Bishop@gmail.com", "Judith", "https://www.southwestern.edu/a/departments/mathcompsci/OHProject/BishopJ/bishopJ.jpg", "Bishop" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "BasePrice", "ISBN", "Keywords", "PublishDate", "Title" },
                values: new object[] { 2, 2, 0m, "665-545-300-98", "software", new DateTime(1994, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design Patterns: Elements of Reusable Object-Oriented Software" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "BasePrice", "ISBN", "Keywords", "PublishDate", "Title" },
                values: new object[] { 3, 1, 0m, "978-0-596-52773-0", "C#", new DateTime(2007, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# 3.0 Design Patterns" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);
        }
    }
}
