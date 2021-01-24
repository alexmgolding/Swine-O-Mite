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
    public class SmokingWoodListItem
    {
        [Display(Name = "Smoking Wood Id")]
        public int SmokingWoodId { get; set; }
        [Display(Name = "Wood Species")]
        public WoodSpeciesType WoodSpecies { get; set; }
        //public WoodSpeciesType WoodSpeciesType { get; set; }
        [Display(Name = "Wood Variety")]
        public WoodVarietyType WoodVariety { get; set; }
        //public WoodVarietyType WoodVarietyType { get; set; }
    }
}
