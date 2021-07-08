using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.API.Models;

namespace Task1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private List<Category> ListCategory = new List<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "Category1"
            },
            new Category()
            {
                Id = 2,
                Name = "Category2"
            },
            new Category()
            {
                Id = 3,
                Name = "Category3"
            }
        };

        private List<Course> ListCourse = new List<Course>()
        {
            new Course()
            {
                Id = 1,
                Name = "Course1"
            },
            new Course()
            {
                Id = 2,
                Name = "Course2"
            },
            new Course()
            {
                Id = 3,
                Name = "Course3"
            }
        };

        private List<Book> ListBooks;

        public BookController()
        {
            ListBooks = new List<Book>() { 
            new Book()
            {
                Id = 1,
                Name = "Name1",
                Publisher = "Publisher1",
                Category = ListCategory.FirstOrDefault(a=>a.Id == 1),
                Course = ListCourse.FirstOrDefault(a=>a.Id == 1)
            },
            new Book()
            {
                Id = 2,
                Name = "Name2",
                Publisher = "Publisher2",
                Category = ListCategory.FirstOrDefault(a=>a.Id == 2),
                Course = ListCourse.FirstOrDefault(a=>a.Id == 2)
            },
            new Book()
            {
                Id = 3,
                Name = "Name3",
                Publisher = "Publisher3",
                Category = ListCategory.FirstOrDefault(a=>a.Id == 3),
                Course = ListCourse.FirstOrDefault(a=>a.Id == 3)
            },
            };
        }


        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public List<Book> GetAll()
        {
            return ListBooks;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), 404)]
        public object GetById(int Id)
        {
            var Book = ListBooks.FirstOrDefault(a => a.Id == Id);

            if(Book == null) { return NotFound(); }
            return Book;
        }

        [HttpGet]
        [Route("GetByCourseId")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public object GetByCourseId(int Id)
        {
            var Book = ListBooks.Where(a => a.Course.Id == Id);

            return Book.ToList();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), 208)]
        [ProducesResponseType(typeof(Book), 404)]
        [ProducesResponseType(typeof(Book), 201)]
        public object Create(InputBook model)
        {
            if(ListBooks.FirstOrDefault(a=>a.Id == model.Id) != null)
            {
                Response.StatusCode = 208;
                return "Id Is Already Used";
            }
            var Category = ListCategory.FirstOrDefault(a => a.Id == model.IdCategory);
            if(Category == null) { Response.StatusCode = 404; return "Make Sure Category Id"; }

            var Course = ListCourse.FirstOrDefault(a => a.Id == model.IdCourse);
            if (Course == null) { Response.StatusCode = 404; return "Make Sure Course Id"; }


            var Book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Publisher = model.Publisher,
                Category = Category,
                Course = Course
            };

            //For Add To List
            //ListBooks.Add(Book);

            Response.StatusCode = 201;
            return Book;
        }


        [HttpPut]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), 208)]
        [ProducesResponseType(typeof(Book), 404)]
        public object Update(InputBook model)
        {
            var MyBook = ListBooks.FirstOrDefault(a => a.Id == model.Id);
            if (MyBook == null)
            {
                Response.StatusCode = 404;
                return "Make Sure Book Id";
            }
            var Category = ListCategory.FirstOrDefault(a => a.Id == model.IdCategory);
            if (Category == null) { Response.StatusCode = 404; return "Make Sure Category Id"; }

            var Course = ListCourse.FirstOrDefault(a => a.Id == model.IdCourse);
            if (Course == null) { Response.StatusCode = 404; return "Make Sure Course Id"; }


            var Book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Publisher = model.Publisher,
                Category = Category,
                Course = Course
            };

            //For Update In List
            //MyBook.Name = Book.Name;
            //MyBook.Publisher = Book.Publisher;
            //MyBook.Category = Category;
            //MyBook.Course = Course;

            return MyBook;
        }



        [HttpDelete("{Id}")]
        public object Delete(int Id)
        {
            var Book = ListBooks.FirstOrDefault(a => a.Id == Id);

            if(Book == null) { Response.StatusCode = 404; return false; }

            return true;
        }
    }
}
