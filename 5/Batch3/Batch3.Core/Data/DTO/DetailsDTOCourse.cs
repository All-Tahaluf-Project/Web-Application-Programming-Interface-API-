using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;

namespace Tahaluf.Task3OnionArchitectoure.Core.Data.DTO
{
    public class DetailsDTOCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<Book> Books { get; set; }
        public List<DetailsDTOTeacherCourse> TeacherCourse { get; set; }
    }
}
