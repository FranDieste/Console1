using Domain.Aggregates.BookAggregate.Entities;
using Domain.Aggregates.BookAggregate.Repositories;
using Repository01.Repositories.Base.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Repository01.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private IApplicationDbContext _context;
        public BookRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            //Hola que tal-->Comentario desde GitFranClone


        }

        public IEnumerable<Book> GetBooks()
        {
            var books = GenerateBooks();


            return books;
        }

        private IEnumerable<Book> GenerateBooks()
        {
            var identity = WindowsIdentity.GetCurrent(); //We can get an information of GetCurrent an then use it

            var books = new List<Book>();
            for (int i = 0; i < 10; i++)
            {
                var book = new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Book" + i,
                    Isbn = i + "isbn",
                    Pages = i * 10,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserCode = identity.User.Value,
                    Version = 1
                };

                var chart = new Chapter()
                {
                    Id = Guid.NewGuid(),
                    BookId = book.Id,
                    Title = "Chapter of Book " + book.Title,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    UserCode = WindowsIdentity.GetCurrent().User.Value //we get the user directly from WindowsIdentity 
                };

                book.AddChapter(chart);

                books.Add(book);

            }
            
            return books;



        }
    }
}
