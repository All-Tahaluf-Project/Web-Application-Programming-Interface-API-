using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Batch3.Core.Data.Models
{
    public class Trainee
    {
        [Key]
        public int TraineeId { get; set; }
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
