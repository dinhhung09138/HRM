using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Thông tin hợp dồng nhân viên
    /// </summary>
    public class EmployeeContract : Entity<long>
    {
        public EmployeeContract(
            long employeeId,
            long employeeProcessId,
            long contractTypeId,
            DateTime fromDate,
            DateTime? toDate,
            string comment,
            decimal grossSalary,
            decimal netSalary,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            EmployeeProcessId = employeeProcessId;
            ContractTypeId = contractTypeId;
            FromDate = fromDate;
            ToDate = toDate;
            Comment = comment;
            GrossSalary = grossSalary;
            NetSalary = netSalary;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [MaxLength(20)]
        [Required]
        public string ContractNumber { get; set; }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public long EmployeeProcessId { get; set; }

        public Employee EmployeeProcess { get; set; }

        [Required]
        public long ContractTypeId { get; set; }

        public ContractType ContractType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        [MaxLength(255)]
        public string Comment { get; set; }

        [Required]
        public decimal GrossSalary { get; set; }

        [Required]
        public decimal NetSalary { get; set; }

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
