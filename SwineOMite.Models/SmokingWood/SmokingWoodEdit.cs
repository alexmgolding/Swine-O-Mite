//using SwineOMite.Models.Enums;
using SwineOMite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Models.SmookingWood
{
    public class SmokingWoodEdit
    {
        public int SmokingWoodId { get; set; }
        public WoodSpeciesType WoodSpecies { get; set; }
        //public WoodSpeciesType WoodSpeciesType { get; set; }
        public WoodVarietyType WoodVariety { get; set; }
        //public WoodVarietyType WoodVarietyType { get; set; }
    }
}
