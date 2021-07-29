using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Batch3.Core.Data.DTO
{
    public class DetailsDTOUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
