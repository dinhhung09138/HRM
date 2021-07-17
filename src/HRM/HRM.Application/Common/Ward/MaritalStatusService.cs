﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IMaritalStatusRepository _MaritalStatusRepository;

        public MaritalStatusService(
            IMaritalStatusRepository MaritalStatusRepository)
        {
            _MaritalStatusRepository = MaritalStatusRepository;
        }
    }
}