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
    public class CourseController : Controller
    {
        private ICourseService _service;

        public CourseController(ICourseService courseService)
        {
            _service = courseService;
        }

        [HttpGet]
        public List<Course> GetAllCourse()
        {
            return _service.GetAllCourse();
        }


        [HttpPost]
        public object AddCourse(Course model)
        {
            if(model.Id == 0 || model.Name == null)
            {
                return BadRequest();
            }
            return _service.AddCourse(model);
        }

        [HttpPut]
        public object UpdateCourse(Course model)
        {
            if (model.Id == 0 || model.Name == null)
            {
                return BadRequest();
            }
            return _service.UpdateCourse(model);
        }


        [HttpDelete]
        [Route("{Id}")]
        public object DeleteCourse(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            return _service.DeleteCourse(Id);
        }
    }
}
