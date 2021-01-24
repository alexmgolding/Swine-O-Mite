using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Data.Entities
{
    public class CompleteIngredient
    {
        [Key]
        public int CompleteIngredientId { get; set; }
        [ForeignKey(nameof (Ingredient))]
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        [ForeignKey(nameof (IngredientQuantity))]
        public int QuantityId { get; set; }
        public virtual IngredientQuantity IngredientQuantity { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
