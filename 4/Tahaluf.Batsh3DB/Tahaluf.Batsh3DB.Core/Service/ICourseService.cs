using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Batsh3DB.Core.Data;

namespace Tahaluf.Batsh3DB.Core.Service
{
    public interface ICourseService
    {
        public List<Course> GetAllCourse();
        public object AddCourse(Course model);
        public object UpdateCourse(Course model);
        public object DeleteCourse(int Id);
    }
}
