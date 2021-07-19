using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurProject.Core.Data;
using OurProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CController : Controller
    {
        IServiceC _serviceC;

        public CController(IServiceC serviceC)
        {
            _serviceC = serviceC;
        }

        [HttpGet]
        public List<C>GetAll()
        {
            return _serviceC.GetAllC();
        }

        [HttpPost]
        public int InsertC(C model)
        {
            return _serviceC.InsertC(model);
        }

        [HttpPut]
        public int UpdateC(C model)
        {
            return _serviceC.UpdateC(model);
        }

        [HttpDelete]
        [Route("{Id}")]
        public int DeleteC(int Id)
        {
            return _serviceC.DeleteC(Id);
        }
    }
}
