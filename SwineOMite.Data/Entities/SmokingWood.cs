using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Data.Entities
{
    public enum WoodVarietyType
    {
        Chips,
        Chunks,
        Splits
    }

    public enum WoodSpeciesType
    {
        Alder = 1,
        Apple,
        Cherry,
        Hickory,
        Maple,
        Mesquite,
        Oak,
        Peach,
        Pear,
        Pecan,
        PostOak,
        Walnut
    }
    public class SmokingWood
    {
        [Key]
        public int SmokingWoodId { get; set; }
        [Required]
        public WoodSpeciesType WoodSpecies { get; set; }
        [Required]
        public WoodVarietyType WoodVariety { get; set; }
        //[ForeignKey(nameof(SmokingWoodQuantity))]
        //public int SmokingWoodQuantityId { get; set; }
        //public virtual SmokingWoodQuantity SmokingWoodQuantity { get; set; }

        //public virtual WoodSpeciesType WoodSpeciesType { get; set; }

        //public virtual WoodVarietyType WoodVarietyType { get; set; }
    }
}
