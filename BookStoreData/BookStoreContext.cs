using BookStoreDomain;
using Microsoft.EntityFrameworkCore;

namespace BookStoreData
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {
             
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> Books_Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Genre).HasConversion<string>();

            modelBuilder.Entity<AuthorBook>()
                 .HasOne(b => b.Book)
                 .WithMany(ba => ba.Book_Authors)
                 .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<AuthorBook>()
             .HasOne(b => b.Author)
             .WithMany(ba => ba.Book_Authors)
             .HasForeignKey(bi => bi.AuthorId);

            //modelBuilder.Entity<Author>().HasData(
            //    new Author { AuthorId = new Guid(), FirstName = "Kathy",
            //    LastName = "Sierra" , Email = "Kathy.Sierra@gmail.com",
            //    AboutTheAuthor= "She is the co-creator of the Head First series of books on technical (primarily computer) topics, along with her partner, Bert Bates. The series, which began with Head First Java in 2003,[4] takes an unorthodox, visually intensive approach to the process of teaching programming. Sierra's books in the series have received three nominations for Product Excellence Jolt Awards, winning in 2005 for Head First Design Patterns, and were recognized on Amazon.com's yearly top 10 list for computer books from 2003 to 2005.[5] In 2005 she coined the phrase 'The Kool - Aid Point' to describe the point at which detractors emerge purely due to the popularity of a topic being promoted by others.",
            //    ImageURL= "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Kathy_Sierra_1a.jpg/330px-Kathy_Sierra_1a.jpg" });

            //var authorList = new Author[]
            //{
            //    new Author { AuthorId = new Guid(), FirstName = "Erich",
            //    LastName = "Gamma" , Email = "egamma@microsoft.com",
            //    AboutTheAuthor="Erich Gamma (born 1961 in Zürich) is a Swiss computer scientist and one of the four co-authors (referred to as 'Gang of Four') of the software engineering textbook, Design Patterns: Elements of Reusable Object-Oriented Software.",
            //    ImageURL= "https://www.inspiringquotes.us/data/image/2019/8/c/8751-erich-gamma.jpg" },
            //    new Author {AuthorId = new Guid(), FirstName = "Judith", LastName = "Bishop",Email="Judith.Bishop@gmail.com",AboutTheAuthor="Judith Bishop has had a distinguished background in academia. She has published over 80 papers in areas ranging from programming languages to distributed and web-based systems. She authored one of the first Java programming texts, Java Gently, now in its third edition. She is a Founding Fellow of the South African Institute for Computer Scientists and Information Technologists and in 2005 was recognized as Distinguished Woman Scientist of the Year in South Africa. She is a Fellow of the British Computer Society and of the Royal Society of South Africa.",ImageURL="https://www.southwestern.edu/a/departments/mathcompsci/OHProject/BishopJ/bishopJ.jpg"},

            //};
            //modelBuilder.Entity<Author>().HasData(authorList);

            //var someBooks = new Book[]
            //{
            //    new Book {BookId=new Guid(),
            //    ISBN="0596007124",Title="Head First Design Patterns",
            //    Keywords="first",Genre=BookGenre.Computers,
            //    PublishDate=new DateTime(2004,10,1)},
            //    new Book {BookId=new Guid(),
            //    ISBN="665-545-300-98",Title="Design Patterns: Elements of Reusable Object-Oriented Software",
            //    Keywords="software",Genre=BookGenre.Computers,
            //    PublishDate=new DateTime(1994,10,21)},
            //    new Book {BookId=new Guid(),ISBN="978-0-596-52773-0",Title="C# 3.0 Design Patterns",Keywords="C#",Genre=BookGenre.Computers,
            //    PublishDate=new DateTime(2007,12,10)},
            //};
            //modelBuilder.Entity<Book>().HasData(someBooks);


        }


    }
}