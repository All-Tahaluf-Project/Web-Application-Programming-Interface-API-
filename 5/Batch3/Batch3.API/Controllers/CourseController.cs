using Batch3.Core.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;
using Tahaluf.Task3OnionArchitectoure.Core.Service;

namespace Tahaluf.Task3OnionArchitectoure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        IServiceCourse _serviceCourse;
        public CourseController(IServiceCourse serviceCourse)
        {
            _serviceCourse = serviceCourse;
        }

        [HttpGet]
        public object GetAllCourse()
        {
            return _serviceCourse.GetAllCourse();
        }

        [HttpPost]
        public object InsertCourse(Course model)
        {
            if (model.CourseName == null || model.CourseName == "") { return BadRequest(); }
            _serviceCourse.InsertCourse(model);

            return StatusCode(201);
        }

        [HttpPut]
        public object UpdateCourse(Course model)
        {
            if (model.CourseName == null || model.CourseName == "") { return BadRequest(); }
            var R = _serviceCourse.UpdateCourse(model);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure Course Id";
            }

            return StatusCode(202);
        }

        [HttpDelete]
        [Route("{Id}")]
        public object DeleteCourse(int Id)
        {
            var R = _serviceCourse.DeleteCourse(Id);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure Course Id";
            }
            if (R == 2)
            {
                Response.StatusCode = 409;
                return "There is Books In That Course.";
            }
            if (R == 3)
            {
                Response.StatusCode = 409;
                return "There is TeacherCourse In That Course.";
            }

            return StatusCode(202);
        }

        [HttpGet]
        [Route("{Id}")]
        public object DetailsCourse(int Id)
        {
            var R = _serviceCourse.DetailsCourse(Id);

            if (R == null)
            {
                Response.StatusCode = 409;
                return "Make Sure Course Id";
            }

            return R;
        }

        [HttpPost]
        [Route("CourseSearch")]
        public object Search(CourseDTO courseDTO)
        {
            return _serviceCourse.Search(courseDTO);
        }

        [HttpGet]
        [Route("GetAllCourseBook")]
        public Task<List<Course>> GetAllCourseBook()
        {
            return _serviceCourse.GetAllCourseBook();
        }
    }
}
