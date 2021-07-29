using Batch3.Core.Data.DTO;
using Batch3.Core.Service;
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
    public class MarkController : ControllerBase
    {
        IServiceMark _serviceMark;
        public MarkController(IServiceMark serviceMark)
        {
            _serviceMark = serviceMark;
        }
        [HttpGet]
        [Route("{Id}")]
        public List<DetailsDTOMark> GetAll(int Id)
        {
            return _serviceMark.GetAllMarks(Id);
        }

        [HttpGet]
        [Route("AVG/{Id}")]
        public object AVG(int Id)
        {
            return _serviceMark.AVG(Id);
        }

        [HttpGet]
        [Route("Sum/{Id}")]
        public object Sum(int Id)
        {
            return _serviceMark.Sum(Id);
        }

        [HttpGet]
        [Route("BellowAVG/{Id}")]
        public object LowestMark(int Id)
        {
            return _serviceMark.BellowAVG(Id);
        }

        [HttpGet]
        [Route("AboveAVG/{Id}")]
        public object AboveAVG(int Id)
        {
            return _serviceMark.AboveAVG(Id);
        }

        [HttpGet]
        [Route("CountMarks/{Id}")]
        public object CountMarks(int Id)
        {
            return _serviceMark.CountMarks(Id);
        }
    }
}
