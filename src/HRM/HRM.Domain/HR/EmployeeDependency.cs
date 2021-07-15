using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Thông tin người phụ thuộc
    /// </summary>
    public class EmployeeDependency : Entity<long>
    {
        public EmployeeDependency(
            long employeeId,
            string fullName,
            long relationshipTypeId,
            DateTime dateOfBirth,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            RelationshipTypeId = relationshipTypeId;
            DateOfBirth = dateOfBirth;
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

        [Required]
        public DateTime DateOfBirth { get; set; }

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
