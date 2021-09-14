using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.HR
{
    public class EmployeeModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(15)]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        [MaxLength(70)]
        public string FullName { get; set; }

        /// <summary>
        /// TODO, need to add Branch where (ho chi minh, ha noi,...)
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public long? BranchId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public string BranchIdValue
        {
            get
            {
                return BranchId?.ToString();
            }
            set { }
        }

        public long? DepartmentId { get; set; }

        public string DepartmentIdValue
        {
            get
            {
                return DepartmentId?.ToString();
            }
            set { }
        }

        public long? PositionId { get; set; }

        public string PositionIdValue
        {
            get
            {
                return PositionId?.ToString();
            }
            set { }
        }

        /// <summary>
        /// TODO Vij tri cong viec, cong nhan, Senior Dev, QC
        /// Can tao bangr JobPosition
        /// </summary>
        public long? JobPositionId { get; set; }

        public string JobPositionIdValue
        {
            get
            {
                return JobPositionId?.ToString();
            }
            set { }
        }

        public long? ManagerId { get; set; }

        public string ManagerIdValue
        {
            get
            {
                return ManagerId?.ToString();
            }
            set { }
        }

        [EmailAddress(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(10)]
        public string PhoneExt { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        public long? EmployeeWorkingStatusId { get; set; }

        public string EmployeeWorkingStatusIdValue
        {
            get
            {
                return EmployeeWorkingStatusId?.ToString();
            }
            set { }
        }

        public DateTime? ProbationDate { get; set; }

        public DateTime? StartWorkingDate { get; set; }

        public DateTime? ResignDate { get; set; }

        [MaxLength(10)]
        public string BadgeCardNumber { get; set; }

        public DateTime? DateApplyBadge { get; set; }

        [MaxLength(10)]
        public string FingerSignNumber { get; set; }

        public DateTime? DateApplyFingerSign { get; set; }

        public EmployeeModel Clone()
        {
            return new EmployeeModel()
            {
                Id = this.Id,
                EmployeeCode = this.EmployeeCode,
                FullName = this.FullName,
                BranchId = this.BranchId,
                BranchIdValue = this.BranchIdValue,
                DepartmentId = this.DepartmentId,
                DepartmentIdValue = this.DepartmentIdValue,
                PositionId = this.PositionId,
                PositionIdValue = this.PositionIdValue,
                JobPositionId = this.JobPositionId,
                JobPositionIdValue = this.JobPositionIdValue,
                ManagerId = this.ManagerId,
                ManagerIdValue = this.ManagerIdValue,
                Email = this.Email,
                Phone = this.Phone,
                PhoneExt = this.PhoneExt,
                Fax = this.Fax,
                EmployeeWorkingStatusId = this.EmployeeWorkingStatusId,
                EmployeeWorkingStatusIdValue = this.EmployeeWorkingStatusIdValue,
                ProbationDate = this.ProbationDate,
                StartWorkingDate = this.StartWorkingDate,
                ResignDate = this.ResignDate,
                BadgeCardNumber = this.BadgeCardNumber,
                DateApplyBadge = this.DateApplyBadge,
                FingerSignNumber = this.FingerSignNumber,
                DateApplyFingerSign = this.DateApplyFingerSign,
                IsActive = this.IsActive,
                CreateBy = this.CreateBy,
                CreateDate = this.CreateDate,
                UpdateBy = this.UpdateBy,
                UpdateDate = this.UpdateDate,
                Deleted = this.Deleted,
                RowVersion = this.RowVersion,
            };
        }
    }
}
