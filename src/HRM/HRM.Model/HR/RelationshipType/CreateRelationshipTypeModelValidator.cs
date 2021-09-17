using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.HR
{
    public class CreateRelationshipTypeModelValidator : RelationshipTypeValidator
    {
        public CreateRelationshipTypeModelValidator()
        {
            Name();
        }
    }
}
