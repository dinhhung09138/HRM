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
        public string BranchIdValue { get; set; }

        public long? DepartmentId { get; set; }

        public string DepartmentIdValue { get; set; }

        public long? PositionId { get; set; }

        public string PositionIdValue { get; set; }

        /// <summary>
        /// TODO Vij tri cong viec, cong nhan, Senior Dev, QC
        /// Can tao bangr JobPosition
        /// </summary>
        public long? JobPositionId { get; set; }

        public string JobPositionIdValue { get; set; }

        public long? ManagerId { get; set; }

        public string ManagerIdValue { get; set; }

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

        public string EmployeeWorkingStatusIdValue { get; set; }

        public DateTime? ProbationDate { get; set; }

        public DateTime? StartWorkingDate { get; set; }

        public DateTime? ResignDate { get; set; }

        [MaxLength(10)]
        public string BadgeCardNumber { get; set; }

        public DateTime? DateApplyBadge { get; set; }

        [MaxLength(10)]
        public string FingerSignNumber { get; set; }

        public DateTime? DateApplyFingerSign { get; set; }
    }
}
