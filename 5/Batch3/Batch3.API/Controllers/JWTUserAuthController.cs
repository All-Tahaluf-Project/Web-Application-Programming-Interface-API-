using Batch3.Core.Data.Models;
using Batch3.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTUserAuthController : ControllerBase
    {
        IServiceJWTUserAuth _serviceJWTUserAuth;
        public JWTUserAuthController(IServiceJWTUserAuth serviceJWTUserAuth)
        {
            _serviceJWTUserAuth = serviceJWTUserAuth;
        }

        [HttpGet]
        [Route("GetTeacherUserById")]
        [Authorize(Roles = "Teacher")]
        public object GetTeacherUserById()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;

            return _serviceJWTUserAuth.GetTeacherUserById(Convert.ToInt32(userId));
        }

        [HttpGet]
        [Route("GetTraineeUserById")]
        [Authorize(Roles = "Trainee")]
        public object GetTraineeUserById()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;

            return _serviceJWTUserAuth.GetTraineeUserById(Convert.ToInt32(userId));
        }

        [HttpPost]
        [Route("LogIn")]
        public object LogIn(User model)
        {
            var Token = _serviceJWTUserAuth.LogIn(model);
            if(Token == null) { Response.StatusCode = 404; return "Make Sure UserName Or Password"; }
            return new { Token = Token };
        }


    }
}
