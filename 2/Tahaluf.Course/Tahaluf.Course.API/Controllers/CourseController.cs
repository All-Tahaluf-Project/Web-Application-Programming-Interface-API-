using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Course.API.Models;

namespace Tahaluf.Course.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private static List<Courses> ListCoures = new List<Courses> {
            new Courses()
            {
                Id = 1,
                Date = DateTime.Now,
                Category = "Math",
                Name = "Math Course"
            },
            new Courses()
            {
                Id = 2,
                Date = DateTime.Now,
                Category = "IT",
                Name = "ASP.net"
            },
            new Courses()
            {
                Id = 3,
                Date = DateTime.Now,
                Category = "IT",
                Name = "Angular"
            },
            new Courses()
            {
                Id = 4,
                Date = DateTime.Now,
                Category = "IT",
                Name = "React"
            },
        };



        //[HttpGet]
        //[Route("GetAll")]
        //public object GetAll()
        //{
        //    return ListCoures;
        //}

        //https://localhost:44331/api/Course/GetAll
        [HttpGet]
        [Route("GetAll")]
        public List<Courses> GetAll()
        {
            return ListCoures;
        }

        //https://localhost:44331/api/Course/SearchByName?Name=M
        [HttpGet]
        [Route("SearchByName")]
        public object SearchByName(string Name)
        {
            if (Name == null) { return StatusCode(400); }
            return ListCoures.Where(a => a.Name.Contains(Name));
        }

        //https://localhost:44331/api/Course/SearchById?Id=1
        [HttpGet]
        [Route("SearchById")]
        public object SearchById(int? id)
        {
            if (id == null || id == 0) { return StatusCode(400); }
            var Course = ListCoures.FirstOrDefault(a => a.Id == id);
            if (Course == null) { return NotFound(); }

            return Course;
        }

        //https://localhost:44331/api/Course/1
        [HttpGet]
        [Route("{Id}")]
        public object SearchById1(int? id)
        {
            if (id == null || id == 0) { return StatusCode(400); }
            var Course = ListCoures.FirstOrDefault(a => a.Id == id);
            if (Course == null) { return NotFound(); }

            return Course;
        }

        //https://localhost:44331/api/Course/SearchByCategory?Category=IT
        [HttpGet]
        [Route("SearchByCategory")]
        public object SearchByCategory(string Category)
        {
            if (Category == null) { return StatusCode(400); }

            return ListCoures.Where(a => a.Category == Category);
        }

        //https://localhost:44331/api/Course/SearchByDate?StartTime=2021-07-07T00:00:00.000000&EndTime=2021-07-08T00:00:00.000000
        [HttpGet]
        [Route("SearchByDate")]
        public object SearchByDate(DateTime StartTime, DateTime EndTime)
        {
            if (StartTime == null || EndTime == null) { return StatusCode(400); }


            return ListCoures.Where(a => a.Date >= StartTime && a.Date <= EndTime);
        }

        //https://localhost:44331/api/Course/AddCourse
        //Json
        //        {
        //    "Id" : 5,
        //    "Name" : "Name",
        //    "Category" : "IT"
        //}
        [HttpPost]
        [Route("AddCourse")]
        public object AddCourse(Courses model)
        {
            if (model.Id == 0)
            {
                if (model.Name == "" || model.Name == null ||
                    model.Category == "" || model.Category == null
                    )
                {
                    Response.StatusCode = 400;
                    return "Make Sure Enter All Values";
                }
                else
                {
                    model.Date = DateTime.Now;
                    model.Id = ListCoures.Max(a => a.Id) + 1;
                    ListCoures.Add(model);
                    return Ok("Done");
                }
            }
            else
            {
                var Course = ListCoures.FirstOrDefault(a => a.Id == model.Id);

                if (Course == null) { return NotFound(); }

                Course.Name = model.Name;
                Course.Category = model.Category;
                Course.Date = DateTime.Now;

                return Ok("Done");
            }
        }

        //https://localhost:44331/api/Course/DeleteCourse
        //Json
        //        {
        //    "Id" : 5
        //}
        [HttpDelete]
        [Route("DeleteCourse")]
        public object DeleteCourse(Courses model)
        {
            var Course = ListCoures.FirstOrDefault(a => a.Id == model.Id);

            if (Course == null) { return NotFound(); }

            ListCoures.Remove(Course);

            return Ok("Done");
        }



































        //Tahaluf
        [HttpPut]
        [ProducesResponseType(typeof(Courses), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Courses), StatusCodes.Status400BadRequest)]
        public Courses Update([FromBody] Courses model)
        {
            return model;
        }

        [HttpDelete("{Id}")]
        public bool Delete (int Id)
        {
            return true;
        }

    }
}
