using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tahaluf.Course.API.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
