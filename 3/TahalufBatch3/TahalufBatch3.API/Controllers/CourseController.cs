using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Batch3.Core.Services;
using Tahaluf.Batch3.Core.Data;

namespace TahalufBatch3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseSevice _courseSevice;
        private readonly IMyClass _MyClass;

        public CourseController(ICourseSevice courseSevice,IMyClass myClass)
        {
            _courseSevice = courseSevice;
            _MyClass = myClass;
        }

        [HttpGet]
        public object GetAll()
        {
            //return StatusCode(500);
            //Response.StatusCode = 300;
            //return Name;
            return _courseSevice.GetAll();
        }

        [HttpPost]
        public object AddCourse([FromBody]Courses courses)
        {
            return _courseSevice.AddCourse(courses);
        }

        [HttpDelete]
        public bool Delete (int id)
        {
            return _courseSevice.DeleteCourse(id);
        }

        [HttpGet]
        [Route("GetMyClass")]
        public object GetMyClass()
        {
            return _MyClass.GetAll();
        }

        [HttpGet]
        [Route("SearchByName/{Name}")]
        public object SearchByName(string Name)
        {
            return _MyClass.SearchByName(Name);
        }

        [HttpGet]
        [Route("SearchByOneName/{Name}")]
        public object SearchByOneName(string Name)
        {
            return _MyClass.SearchByOneName(Name);
        }
    }
}
