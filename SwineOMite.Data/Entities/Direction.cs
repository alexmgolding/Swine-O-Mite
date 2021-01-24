using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
