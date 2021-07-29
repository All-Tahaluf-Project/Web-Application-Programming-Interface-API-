using Batch3.Core.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batch3.Core.Service
{
    public interface IServiceMark
    {
        public List<DetailsDTOMark> GetAllMarks(int Id);
        public object Sum(int Id);
        public object AVG(int Id);
        public object AboveAVG(int Id);
        public object BellowAVG(int Id);
        public object CountMarks(int Id);
    }
}
