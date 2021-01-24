using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.Directions
{
    public class DirectionDetail
    {
        public int DirectionId { get; set; }
        public int StepNumber { get; set; }
        public string Instructions { get; set; }
    }
}
