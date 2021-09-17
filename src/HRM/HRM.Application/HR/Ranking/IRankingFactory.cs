using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IRankingFactory
    {
        Ranking Create(RankingModel model);

        Ranking Update(RankingModel model);
    }
}
