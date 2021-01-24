using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models.SmokingWoodQuantity;
using SwineOMite.Models.SmookingWoodQuantity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Services
{
    public class SmokingWoodQuantityService
    {
        public SmokingWoodQuantityService()
        {

        }

        public bool CreateSmokingWoodQuantity(SmokingWoodQuantityCreate model)
        {
            var entity = new SmokingWoodQuantity()
            {
                SmokingWoodQuantityId = model.SmokingWoodQuantityId,
                SmokingWoodId = model.SmokingWoodId,
                WoodQuantityId = model.WoodQuantityId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SmokingWoodQuantities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SmokingWoodQuantityListItem> GetSmokingWoodQauntities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .SmokingWoodQuantities
                    .Select(
                    e => new SmokingWoodQuantityListItem
                    {
                        SmokingWoodQuantityId = e.SmokingWoodQuantityId,
                        SmokingWoodId = e.SmokingWoodId,
                        WoodQuantityId = e.WoodQuantityId
                    }
                    );

                return query.ToArray();
            }
        }

        public SmokingWoodQuantityDetail GetSmokingWoodQuantityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SmokingWoodQuantities
                    .Single(e => e.SmokingWoodQuantityId == id);
                return
                    new SmokingWoodQuantityDetail
                    {
                        SmokingWoodQuantityId = entity.SmokingWoodQuantityId,
                        SmokingWoodId = entity.SmokingWoodId,
                        WoodQuantityId = entity.WoodQuantityId
                    };
            }
        }

        public bool UpdateSmokingWoodQuantity(SmokingWoodQuantityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SmokingWoodQuantities
                    .Single(e => e.SmokingWoodQuantityId == model.SmokingWoodQuantityId);

                entity.SmokingWoodQuantityId = model.SmokingWoodQuantityId;
                entity.SmokingWoodId = model.SmokingWoodId;
                entity.WoodQuantityId = model.WoodQuantityId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSmokingWoodQuantity(int smokingWoodQuantityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .SmokingWoodQuantities
                    .Single(e => e.SmokingWoodQuantityId == smokingWoodQuantityId);

                ctx.SmokingWoodQuantities.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
