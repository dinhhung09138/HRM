using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class RelationshipTypeService : IRelationshipTypeService
    {
        private readonly IRelationshipTypeRepository _relationshipTypeRepository;

        public RelationshipTypeService(
            IRelationshipTypeRepository relationshipTypeRepository)
        {
            _relationshipTypeRepository = relationshipTypeRepository;
        }
    }
}
