using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Task3OnionArchitectoure.Core.Data.DTO
{
    public class DetailsDTOTeacherCourse
    {
        public int TeacherCourseId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}
