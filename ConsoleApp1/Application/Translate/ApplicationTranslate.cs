using Application.Dto.OutDto;
using Domain.Aggregates.BookAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Translate
{
   //_____________________________________
  //We create a Singleton class
  //______________________________________
  public  class ApplicationTranslate
    {
                
        private static  ApplicationTranslate _applicationTranslate;

        private ApplicationTranslate()
        {

        }
        
        public static ApplicationTranslate MyAplication { get => _applicationTranslate ?? (_applicationTranslate = new ApplicationTranslate());}


        public IEnumerable<BooksResultDto> GetBooks(IEnumerable<Book> books)
        {

            var booksDto = new List<BooksResultDto>();


            if (books == null || books.Count() == 0) return null;

            foreach (var book in books)
            {
                var _bookDto = new BooksResultDto(){
                    Id = book.Id
                };

                booksDto.Add(_bookDto);
            }

            return booksDto;

        }


        
    }
}
