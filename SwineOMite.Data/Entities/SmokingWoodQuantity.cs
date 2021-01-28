using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Data.Entities
{
    public class SmokingWoodQuantity
    {
        [Key]
        public int SmokingWoodQuantityId { get; set; }

        [ForeignKey(nameof (WoodQuantity))]
        public int WoodQuantityId { get; set; }
        public virtual WoodQuantity WoodQuantity { get; set; }

        [ForeignKey(nameof (SmokingWood))]
        public int SmokingWoodId { get; set; }
        public virtual SmokingWood SmokingWood { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

    }
}
