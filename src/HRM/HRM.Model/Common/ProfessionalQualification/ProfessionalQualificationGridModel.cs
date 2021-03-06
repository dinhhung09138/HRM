using System;

namespace HRM.Model.Common
{
    public sealed class ProfessionalQualificationGridModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Precedence { get; set; }

        public bool IsActive { get; set; }
    }
}
