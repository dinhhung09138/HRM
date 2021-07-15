using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Người thân nhân viên
    /// </summary>
    public class EmployeeRelationship : Entity<long>
    {
        public EmployeeRelationship(
            long employeeId,
            string fullName,
            long relationshipTypeId,
            string address,
            string mobile,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            RelationshipTypeId = relationshipTypeId;
            Address = address;
            Mobile = mobile;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public long RelationshipTypeId { get; set; }

        public RelationshipType RelationshipType { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string Mobile { get; set; }

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
