using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Batch3.Core.Data.Models
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        public float MarkValue { get; set; }
        public int TraineeId { get; set; }
        [ForeignKey("TraineeId")]
        public virtual Trainee Trainee { get; set; }
    }
}
