using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models.SmookingWood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Services
{
    public class SmokingWoodService
    {
        public SmokingWoodService()
        {

        }

        public bool CreateSmokingWood(SmokingWoodCreate model)
        {
            var entity = new SmokingWood()
            {
                WoodSpecies = model.WoodSpeciesType,
                WoodVariety = model.WoodVarietyType
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SmokingWoods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SmokingWoodListItem> GetSmokingWood()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .SmokingWoods
                    .Select(
                    e => new SmokingWoodListItem
                    {
                        SmokingWoodId = e.SmokingWoodId,
                        WoodSpecies = e.WoodSpecies,
                        WoodVariety = e.WoodVariety
                    }
                    );

                return query.ToArray();
            }
        }

        public SmokingWoodDetail GetSmokingWoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SmokingWoods
                    .Single(e => e.SmokingWoodId == id);
                return
                    new SmokingWoodDetail
                    {
                        SmokingWoodId = entity.SmokingWoodId,
                        WoodSpecies = entity.WoodSpecies,
                        WoodVariety = entity.WoodVariety
                    };
            }
        }

        public bool UpdateSmokingWood(SmokingWoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SmokingWoods
                    .Single(e => e.SmokingWoodId == model.SmokingWoodId);

                entity.WoodSpecies = model.WoodSpecies;
                entity.WoodVariety = model.WoodVariety;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSmokingWood(int woodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SmokingWoods
                    .Single(e => e.SmokingWoodId == woodId);

                ctx.SmokingWoods.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}