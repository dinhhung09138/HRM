using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore.Domain;

namespace HRM.Domain
{
    /// <summary>
    /// Xã phường Thị trấn
    /// </summary>
    public class Ward : Entity<long>
    {
        public Ward(long id, string name, long districtId, int precedence, bool isActive)
        {
            Id = id;
            Name = name;
            DistrictId = districtId;
            Precedence = precedence;
            IsActive = isActive;
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public long DistrictId { get; set; }

        [Required]
        public int Precedence { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int CreateBy { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public byte[] RowVersion { get; set; }
    }
}
