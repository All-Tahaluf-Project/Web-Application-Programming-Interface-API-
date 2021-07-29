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
    public class TeacherController : Controller
    {
        IServiceTeacher _serviceTeacher;
        public TeacherController(IServiceTeacher serviceTeacher)
        {
            _serviceTeacher = serviceTeacher;
        }

        [HttpGet]
        public object GetAllTeacher()
        {
            return _serviceTeacher.GetAllTeacher();
        }

        [HttpPost]
        public object InsertTeacher(Teacher model)
        {
            if (model.TeacherName == null || model.TeacherName == "") { return BadRequest(); }
            _serviceTeacher.InsertTeacher(model);

            return StatusCode(201);
        }

        [HttpPut]
        public object UpdateTeacher(Teacher model)
        {
            if (model.TeacherName == null || model.TeacherName == "") { return BadRequest(); }
            var R = _serviceTeacher.UpdateTeacher(model);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure Teacher Id";
            }

            return StatusCode(202);
        }

        [HttpDelete]
        [Route("{Id}")]
        public object DeleteTeacher(int Id)
        {
            var R = _serviceTeacher.DeleteTeacher(Id);

            if (R == 0)
            {
                Response.StatusCode = 409;
                return "Make Sure Teacher Id";
            }
            if (R == 2)
            {
                Response.StatusCode = 409;
                return "There is TeacherCourse In That Teacehr.";
            }

            return StatusCode(202);
        }

        [HttpGet]
        [Route("{Id}")]
        public object DetailsTeacher(int Id)
        {
            var R = _serviceTeacher.DetailsTeacher(Id);

            if (R == null)
            {
                Response.StatusCode = 409;
                return "Make Sure Teacher Id";
            }

            return R;
        }
    }
}
