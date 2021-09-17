using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public class RelationshipTypeFactory : IRelationshipTypeFactory
    {
        public RelationshipType Create(RelationshipTypeModel model)
        {
            var item = new RelationshipType(model.Id,
                model.Name,
                model.Precedence,
                model.IsActive,
                model.CreateBy,
                DateTime.Now,
                null, null);
            return item;
        }

        public RelationshipType Update(RelationshipTypeModel model)
        {
            var item = new RelationshipType(model.Id,
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
