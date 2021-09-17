using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IRelationshipTypeFactory
    {
        RelationshipType Create(RelationshipTypeModel model);

        RelationshipType Update(RelationshipTypeModel model);
    }
}
