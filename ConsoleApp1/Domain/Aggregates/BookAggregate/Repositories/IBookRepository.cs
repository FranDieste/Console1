using Domain.Aggregates.BookAggregate.Entities;
using Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aggregates.BookAggregate.Repositories
{
   public interface IBookRepository:IRepository
    {
        public IEnumerable<Book> GetBooks();
        public void AddBook(Book book);

    }
}
