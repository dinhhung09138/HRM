using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.Common;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// THông tin giấy tờ tùy thân nhân viên (bằng lái, hộ chiếu, visa...)
    /// </summary>
    public class EmployeeIdentification : Entity<long>
    {
        public EmployeeIdentification(
            long employeeId,
            long placeId,
            DateTime? applyDate,
            long identificationTypeId,
            string notes,
            DateTime? expirationDate,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            PlaceId = placeId;
            ApplyDate = applyDate;
            IdentificationTypeId = identificationTypeId;
            Notes = notes;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [Required]
        public long PlaceId { get; set; }

        public Province Place { get; set; }

        public DateTime? ApplyDate { get; set; }

        [Required]
        public long IdentificationTypeId { get; set; }

        public IdentificationType IdentificationType { get; set; }

        [MaxLength(255)]
        public string Notes { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public long CreateBy { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public long? UpdateBy { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public byte[] RowVersion { get; set; }
    }
}
