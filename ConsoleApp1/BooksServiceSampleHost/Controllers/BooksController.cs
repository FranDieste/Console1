using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto.InDto.Book;
using Application.Dto.OutDto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RegisterTool;

namespace BooksServiceSampleHost.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        public IEnumerable<BooksResultDto> GetBooks()
        {
            var booksDto = new BooksRequestDto();
            var register = RegisterElements.GetDI();

            //Llamar a una funcion utilizando DI
            
              var controller0 = register.GetRequiredService<IQuery<BooksRequestDto, IEnumerable<BooksResultDto>>>();

            var j = controller0.ExecuteQuery(booksDto);
            return j;
        }
    }
}
