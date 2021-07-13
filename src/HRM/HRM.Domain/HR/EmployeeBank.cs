using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Thông tin tài khoản ngân hàng của nhân viên
    /// </summary>
    public class EmployeeBank : Entity<long>
    {
        public EmployeeBank(
            long employeeId,
            long bankId,
            string bankAddress,
            string accountNumber,
            string accountOwner,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            BankId = bankId;
            BankAddress = bankAddress;
            AccountNumber = accountNumber;
            AccountOwner = accountOwner;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public long BankId { get; set; }

        public Bank Bank { get; set; }

        [MaxLength(100)]
        [Required]
        public string BankAddress { get; set; }

        [MaxLength(100)]
        [Required]
        public string AccountNumber { get; set; }

        [MaxLength(100)]
        [Required]
        public string AccountOwner { get; set; }

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
