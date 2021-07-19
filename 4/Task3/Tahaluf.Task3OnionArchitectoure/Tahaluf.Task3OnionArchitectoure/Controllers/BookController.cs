using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Service;

namespace Tahaluf.Task3OnionArchitectoure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        IServiceBook _serviceBook;
        public BookController(IServiceBook serviceBook)
        {
            _serviceBook = serviceBook;
        }
        [HttpGet]
        public object GetAllBook ()
        {
            return _serviceBook.GetAllBook();
        }

        [HttpPost]
        public object InsertBook(Book model)
        {
            var R = _serviceBook.InsertBook(model);

            if(R == 0) {
                Response.StatusCode = 409;
                return "Make Sure Course Id";
            }

            return StatusCode(201);
        }

        [HttpPut]
        public object UpdateBook(Book model)
        {
            var R = _serviceBook.UpdateBook(model);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure Book Id";
            }

            if (R == 2)
            {
                Response.StatusCode = 409;
                return "Make Sure Course Id";
            }

            return StatusCodes.Status202Accepted;
        }

        [HttpDelete]
        [Route("{Id}")]
        public object DeleteBook(int Id)
        {
            var R = _serviceBook.DeleteBook(Id);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure Book Id";
            }

            return StatusCode(202);
        }

        [HttpGet]
        [Route("{Id}")]
        public object DetailsBook(int Id)
        {
            var R = _serviceBook.DetailsBook(Id);

            if (R == null)
            {
                Response.StatusCode = 409;
                return "Make Sure Book Id";
            }

            return R;
        }
    }
}
