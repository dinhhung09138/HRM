using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class RankingFactory : IRankingFactory
    {
        public Ranking Create(RankingModel model)
        {
            var item = new Ranking(model.Id,
                model.Name,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public Ranking Update(RankingModel model)
        {
            var item = new Ranking(model.Id,
                model.Name,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                model.UpdateBy,
                DateTime.Now);
            return item;
        }
    }
}
