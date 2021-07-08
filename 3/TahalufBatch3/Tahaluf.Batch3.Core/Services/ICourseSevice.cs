using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Batch3.Core.Data;

namespace Tahaluf.Batch3.Core.Services
{
    public interface ICourseSevice
    {
        public List<Courses> GetAll();
        public bool AddCourse(Courses model);
        public bool DeleteCourse(Courses model);
    }
}
