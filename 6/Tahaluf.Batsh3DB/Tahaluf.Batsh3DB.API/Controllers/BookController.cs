using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Batsh3DB.Core.Data;
using Tahaluf.Batsh3DB.Core.Service;

namespace Tahaluf.Batsh3DB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookService _service;
        public BookController(IBookService bookService)
        {
            _service = bookService;
        }
        [HttpGet]
        public List<Book> GetAllBook()
        {
            return _service.GetAllBook();
        }

        [HttpPost]
        public object AddBook(Book model)
        {
            if(model.Name == "" || model.Name == null || model.CourseId == 0)
            {
                Response.StatusCode = 400;
                return "Make Sure Enter All Value";
            }
            return _service.AddBook(model);
        }

        [HttpPut]
        public object UpdateBook(Book model)
        {
            if (model.Name == "" || model.Name == null || model.CourseId == 0 || model.Id == 0)
            {
                Response.StatusCode = 400;
                return "Make Sure Enter All Value";
            }
            return _service.UpdateBook(model);
        }

        [HttpDelete]
        public object UpdateBook(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return "Make Sure Id";
            }
            return _service.DeleteBook(id);
        }
    }
}
