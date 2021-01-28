using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Data.Entities
{
    public class Direction
    {
        [Key]
        public int DirectionId { get; set; }
        [Required]
        public int StepNumber { get; set; }
        [Required]
        public string Instructions { get; set; }
    }
}
