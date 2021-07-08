using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.API.Models
{
    public class InputBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int IdCategory { get; set; }
        public int IdCourse { get; set; }
    }
}
