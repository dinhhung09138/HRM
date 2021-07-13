using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class CommendationService : ICommendationService
    {
        private readonly ICommendationRepository _commendationRepository;

        public CommendationService(
            ICommendationRepository commendationRepository)
        {
            _commendationRepository = commendationRepository;
        }
    }
}
