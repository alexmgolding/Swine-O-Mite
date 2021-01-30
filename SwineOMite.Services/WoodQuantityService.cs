using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models.WoodQuantity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SwineOMite.Services
{
    public class WoodQuantityService
    {
        public WoodQuantityService()
        {

        }

        public bool CreateWoodQuantity(WoodQuantityCreate model)
        {
            var entity = new WoodQuantity()
            {
                WoodQuantityId = model.WoodQuantityId,
                WoodAmount = model.WoodAmount
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.WoodQuantities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SelectListItem> GetWoodQuantityDropdown()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .WoodQuantities
                    .Select(
                    e => new SelectListItem
                    {
                        Value = e.WoodQuantityId.ToString(),
                        Text = e.WoodAmount.ToString()
                    }
                    );

                return query.ToArray();
            }
        }

        

        public IEnumerable<WoodQuantityListItem> GetWoodQuantity()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .WoodQuantities
                    .Select(
                    e => new WoodQuantityListItem
                    {
                        WoodQuantityId = e.WoodQuantityId,
                        WoodAmount = e.WoodAmount
                    }
                    );

                return query.ToArray();
            }
        }

        public WoodQuantityDetail GetWoodQuantityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .WoodQuantities
                    .Single(e => e.WoodQuantityId == id);
                return
                    new WoodQuantityDetail
                    {
                        WoodQuantityId = entity.WoodQuantityId,
                        WoodAmount = entity.WoodAmount
                    };
            }
        }

        public bool UpdateWoodQuantity(WoodQuantityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .WoodQuantities
                    .Single(e => e.WoodQuantityId == model.WoodQuantityId);

                entity.WoodQuantityId = model.WoodQuantityId;
                entity.WoodAmount = model.WoodAmount;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWoodQuantity(int woodQuantityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .WoodQuantities
                    .Single(e => e.WoodQuantityId == woodQuantityId);

                ctx.WoodQuantities.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}