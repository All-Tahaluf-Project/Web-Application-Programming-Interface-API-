using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Batch3.Core.Data.DTO
{
    public class DetailsTeacherUserDTO
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string TeacherName { get; set; }
    }
}
