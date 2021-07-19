using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.Task3OnionArchitectoure.Core.Data.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
