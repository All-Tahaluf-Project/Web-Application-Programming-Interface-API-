using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Task3OnionArchitectoure.Core.Data.Models
{
    public class TeacherCourse
    {
        public int TeacherCourseId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Book Book { get; set; }
        public string TeacherName { get; set; }
    }
}
