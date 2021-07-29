using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;

namespace Tahaluf.Task3OnionArchitectoure.Core.Data.DTO
{
    public class DetailsDTOTeacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<DetailsDTOTeacherCourse> TeacherCourse { get; set; }
    }
}
