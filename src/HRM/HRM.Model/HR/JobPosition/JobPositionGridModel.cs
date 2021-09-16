using System;

namespace HRM.Model.HR
{
    public sealed class JobPositionGridModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Precedence { get; set; }

        public bool IsActive { get; set; }
    }
}
