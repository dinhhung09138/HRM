using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.HR;

namespace HRM.Domain.System
{
    public class SystemUser : Entity<long>
    {
        public SystemUser(
            long id,
            long employeeId,
            string userName,
            string password,
            string salt,
            bool isActive,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            EmployeeId = employeeId;
            UserName = userName;
            Password = password;
            Salt = salt;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Salt { get; set; }

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

        public virtual List<SystemUserRole> SystemUserRoless { get; set; }

        public virtual List<SystemRefreshToken> SystemRefreshTokens { get; set; }

    }
}
