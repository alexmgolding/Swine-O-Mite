//using SwineOMite.Models.Enums;
using SwineOMite.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.SmookingWood
{
    public class SmokingWoodCreate
    {
        [Key]
        public int SmokingWoodId { get; set; }
        [Required]
        public WoodSpeciesType WoodSpeciesType { get; set; }
        //public WoodSpeciesType WoodSpeciesType { get; set; }
        [Required]
        public WoodVarietyType WoodVarietyType { get; set; }
        //public WoodVarietyType WoodVarietyType { get; set; }
    }
}
