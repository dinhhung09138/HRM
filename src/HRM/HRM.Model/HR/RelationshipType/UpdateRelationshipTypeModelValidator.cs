using System;

namespace HRM.Model.HR
{
    public class UpdateRelationshipTypeModelValidator : RelationshipTypeValidator
    {
        public UpdateRelationshipTypeModelValidator()
        {
            Id();
            Name();
        }
    }
}
