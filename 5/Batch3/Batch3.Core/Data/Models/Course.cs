using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Task3OnionArchitectoure.Core.Data.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<Book> Book { get; set; }
        public ICollection<TeacherCourse> TeacherCourse { get; set; }
    }
}
