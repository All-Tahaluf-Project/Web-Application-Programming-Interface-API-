using System;
using System.Collections.Generic;
using System.Text;

namespace Batch3.Core.Data.DTO
{
    public class CourseDTO
    {
        public string CourseName { get; set; }
        public string CategoryName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
