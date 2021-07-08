using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual Course Course { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
