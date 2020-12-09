using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vector.Application.Books.Queries;

namespace Vector.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            return await Mediator.Send(new GetBooksQuery());
        }
    }
}
