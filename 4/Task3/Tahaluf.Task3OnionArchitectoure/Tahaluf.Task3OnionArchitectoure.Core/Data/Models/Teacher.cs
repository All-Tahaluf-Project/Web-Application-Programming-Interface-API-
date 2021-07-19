using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Task3OnionArchitectoure.Core.Data.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public ICollection<TeacherCourse> teacherCourses { get; set; }
    }
}
