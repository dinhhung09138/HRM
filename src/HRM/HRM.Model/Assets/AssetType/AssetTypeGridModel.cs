using System;

namespace HRM.Model.Assets
{
    public sealed class AssetTypeGridModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Precedence { get; set; }

        public bool IsActive { get; set; }
    }
}
