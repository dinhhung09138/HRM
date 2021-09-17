using System;

namespace HRM.Model.HR
{
    public class UpdateRankingModelValidator : RankingValidator
    {
        public UpdateRankingModelValidator()
        {
            Id();
            Name();
        }
    }
}
