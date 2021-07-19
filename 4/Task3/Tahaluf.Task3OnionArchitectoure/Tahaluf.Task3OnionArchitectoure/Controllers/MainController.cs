using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tahaluf.Task3OnionArchitectoure.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : Controller
    {
        [HttpGet]
        public string Main()
        {
            return "Hello For All";
        }
    }
}
