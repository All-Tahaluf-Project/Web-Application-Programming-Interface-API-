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
    public class TeacherCourseController : ControllerBase
    {
        IServiceTeacherCourse _serviceTeacherCourse;
        public TeacherCourseController(IServiceTeacherCourse serviceTeacher)
        {
            _serviceTeacherCourse = serviceTeacher;
        }
        [HttpGet]
        public object GetAllTeacherCourse()
        {
            return _serviceTeacherCourse.GetAllTeacherCourse();
        }

        [HttpPost]
        public object InsertTeacherCourse(TeacherCourse model)
        {
            if (model.CourseId == 0 || model.TeacherId == 0) { return BadRequest(); }
            var R =_serviceTeacherCourse.InsertTeacherCourse(model);

            if (R == 2)
            {
                Response.StatusCode = 409;
                return "Make Sure Course Id.";
            }

            if (R == 3)
            {
                Response.StatusCode = 409;
                return "Make Sure Teache Id.";
            }

            return StatusCode(201);
        }

        [HttpPut]
        public object UpdateTeacherCourse(TeacherCourse model)
        {
            if (model.CourseId == 0 || model.TeacherId == 0) { return BadRequest(); }
            var R = _serviceTeacherCourse.UpdateTeacherCourse(model);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure TeacherCourse Id.";
            }

            if (R == 2)
            {
                Response.StatusCode = 409;
                return "Make Sure Course Id.";
            }

            if (R == 3)
            {
                Response.StatusCode = 409;
                return "Make Sure Teache Id.";
            }

            return StatusCode(202);
        }

        [HttpDelete]
        [Route("{Id}")]
        public object DeleteTeacherCourse(int Id)
        {
            var R = _serviceTeacherCourse.DeleteTeacherCourse(Id);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure TeacherCourse Id";
            }

            return StatusCode(202);
        }

        [HttpGet]
        [Route("{Id}")]
        public object DetailsTeacherCourse(int Id)
        {
            var R = _serviceTeacherCourse.DetailsTeacherCourse(Id);

            if (R == null)
            {
                Response.StatusCode = 409;
                return "Make Sure TeacherCourse Id.";
            }

            return R;
        }

        [HttpGet]
        [Route("SearchTeacherCourseFromCourse/{Name}")]
        public object SearchTeacherCourseFromCourse(string Name)
        {
            return _serviceTeacherCourse.SearchTeacherCourseFromCourse(Name);
        }

        [HttpGet]
        [Route("SearchTeacherCourseFromTeacher/{Name}")]
        public object SearchTeacherCourseFromTeacher(string Name)
        {
            return _serviceTeacherCourse.SearchTeacherCourseFromTeacher(Name);
        }
    }
}
