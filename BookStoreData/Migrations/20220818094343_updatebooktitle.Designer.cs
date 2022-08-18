﻿// <auto-generated />
using System;
using BookStoreData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreData.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20220818094343_updatebooktitle")]
    partial class updatebooktitle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookStoreDomain.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("AboutTheAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AboutTheAuthor = "She is the co-creator of the Head First series of books on technical (primarily computer) topics, along with her partner, Bert Bates. The series, which began with Head First Java in 2003,[4] takes an unorthodox, visually intensive approach to the process of teaching programming. Sierra's books in the series have received three nominations for Product Excellence Jolt Awards, winning in 2005 for Head First Design Patterns, and were recognized on Amazon.com's yearly top 10 list for computer books from 2003 to 2005.[5] In 2005 she coined the phrase 'The Kool - Aid Point' to describe the point at which detractors emerge purely due to the popularity of a topic being promoted by others.",
                            Email = "Kathy.Sierra@gmail.com",
                            FirstName = "Kathy",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Kathy_Sierra_1a.jpg/330px-Kathy_Sierra_1a.jpg",
                            LastName = "Sierra"
                        },
                        new
                        {
                            AuthorId = 2,
                            AboutTheAuthor = "Erich Gamma (born 1961 in Zürich) is a Swiss computer scientist and one of the four co-authors (referred to as 'Gang of Four') of the software engineering textbook, Design Patterns: Elements of Reusable Object-Oriented Software.",
                            Email = "egamma@microsoft.com",
                            FirstName = "Erich",
                            ImageURL = "https://www.inspiringquotes.us/data/image/2019/8/c/8751-erich-gamma.jpg",
                            LastName = "Gamma"
                        },
                        new
                        {
                            AuthorId = 3,
                            AboutTheAuthor = "Judith Bishop has had a distinguished background in academia. She has published over 80 papers in areas ranging from programming languages to distributed and web-based systems. She authored one of the first Java programming texts, Java Gently, now in its third edition. She is a Founding Fellow of the South African Institute for Computer Scientists and Information Technologists and in 2005 was recognized as Distinguished Woman Scientist of the Year in South Africa. She is a Fellow of the British Computer Society and of the Royal Society of South Africa.",
                            Email = "Judith.Bishop@gmail.com",
                            FirstName = "Judith",
                            ImageURL = "https://www.southwestern.edu/a/departments/mathcompsci/OHProject/BishopJ/bishopJ.jpg",
                            LastName = "Bishop"
                        });
                });

            modelBuilder.Entity("BookStoreDomain.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            BasePrice = 0m,
                            Genre = "Computers",
                            ISBN = "0596007124",
                            Keywords = "first",
                            PublishDate = new DateTime(2004, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Head First Design Patterns"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            BasePrice = 0m,
                            Genre = "Computers",
                            ISBN = "665-545-300-98",
                            Keywords = "software",
                            PublishDate = new DateTime(1994, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Design Patterns: Elements of Reusable Object-Oriented Software"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3,
                            BasePrice = 0m,
                            Genre = "Computers",
                            ISBN = "978-0-596-52773-0",
                            Keywords = "C#",
                            PublishDate = new DateTime(2007, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "C# 3.0 Design Patterns"
                        });
                });

            modelBuilder.Entity("BookStoreDomain.Book", b =>
                {
                    b.HasOne("BookStoreDomain.Author", "Author")
                        .WithOne("Book")
                        .HasForeignKey("BookStoreDomain.Book", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookStoreDomain.Author", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
