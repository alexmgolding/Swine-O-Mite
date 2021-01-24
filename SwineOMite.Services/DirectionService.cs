using SwineOMite.Data;
using SwineOMite.Data.Entities;
using SwineOMite.Models;
using SwineOMite.Models.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineOMite.Services
{
    public class DirectionService
    {
        public DirectionService()
        {

        }

        public bool CreateDirection(DirectionCreate model)
        {
            var entity = new Direction()
            {
                StepNumber = model.StepNumber,
                Instructions = model.Instructions

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Directions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DirectionListItem> GetDirections()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Directions
                    .Select(
                    e => new DirectionListItem
                    {
                        DirectionId = e.DirectionId,
                        StepNumber = e.StepNumber,
                        Instructions = e.Instructions
                    }
                    );

                return query.ToArray();
            }
        }

        public DirectionDetail GetDirectionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Directions
                    .Single(e => e.DirectionId == id);
                return
                    new DirectionDetail
                    {
                        DirectionId = entity.DirectionId,
                        StepNumber = entity.StepNumber,
                        Instructions = entity.Instructions
                    };
            }
        }

        public bool UpdateDirection(DirectionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Directions
                    .Single(e => e.DirectionId == model.DirectionId);

                entity.StepNumber = model.StepNumber;
                entity.Instructions = model.Instructions;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDirection(int directionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Directions
                    .Single(e => e.DirectionId == directionId);

                ctx.Directions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}