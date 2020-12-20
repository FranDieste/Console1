using Application.Dto.InDto.Book;
using Application.Dto.OutDto;
using Application.Interfaces;
using Application.Translate;
using Domain.Aggregates.BookAggregate.Entities;
using Domain.Aggregates.BookAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Repositories;
using Microsoft.Extensions.Logging;
using RegisterTool;
using RegisterTool.Interfaces;
using Repository01.Repositories.Base.EF.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
   public class GetBookHandler:IQuery<BooksRequestDto,IEnumerable<BooksResultDto>>
    {
        //Inyection items
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private IApplicationDbContext _myContext;
        public GetBookHandler(IBookRepository bookRepository,
                              IUserRepository userRepository,
                              IApplicationDbContext myContext)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _myContext = myContext;
        }

        public IEnumerable<BooksResultDto> ExecuteQuery(BooksRequestDto Param)
        {

            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\Log\LogFile.txt").CreateLogger();

            Log.Information("GetBookHandler ExecuteQuery");
            try
            {
                var a = 2;
                var b = 0;
                Log.Debug("The values as {0} and {0}", a, b);

                var c = a / b;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Some error occurred");
                
            }

            Log.CloseAndFlush();
            Console.WriteLine("Finito");

            // _myContext.Instance.Database.BeginTransaction();
            //var user = new User()
            //{
            //    Code = "Usrt01",
            //    Name = "Usrt01",
            //    PassWord = "pasUsrt01"
            //};

            //_myContext.Users.Add(user);


            //var user1 = new User()
            //{
            //    Code = "Usrt02",
            //    Name = "Usrt02",
            //    PassWord = "pasUsrt02"
            //};

            //_myContext.Users.Add(user1);

            var user = new User()
            {
                Code = "Usr02",
                Name = "Usr02Name",
                PassWord = "Usr02Pass"
            };

            _userRepository.Add(user);


            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Bokk01 Title",
                Isbn = "123-456-789",
                UserCode = "usr1",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                Pages = 12,
                Version = 1
            };

            _bookRepository.AddBook(book);

            _myContext.Instance.SaveChanges();

           // _myContext.Instance.Database.RollbackTransaction();

            var books = _bookRepository.GetBooks();

            var bookDto = ApplicationTranslate.MyAplication.GetBooks(books);

            return bookDto;

        }
    }
}
