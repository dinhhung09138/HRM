using System;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.HR
{
    /// <summary>
    /// TODO
    /// Thông tin liên hệ
    /// </summary>
    public class EmployeeContact : Entity<long>
    {
        public EmployeeContact(
            long employeeId,
            string phone,
            string mobile,
            string email,
            string skyper,
            string zalo,
            string facebook,
            string linkedIn,
            string twitter,
            string github,
            string whatsapp,
            string temporaryAddress,
            long? temporaryWardId,
            long? temporaryDistrictId,
            long? temporaryProvinceId,
            string permanentAddress,
            long? permanentWardId,
            long? permanentDistrictId,
            long? permanentProvinceId,
            bool isActive,
            long createBy,
            DateTime createDate)
        {
            EmployeeId = employeeId;
            Phone = phone;
            Mobile = mobile;
            Email = email;
            Skyper = skyper;
            Zalo = zalo;
            Facebook = facebook;
            LinkedIn = linkedIn;
            Twitter = twitter;
            Github = github;
            Whatsapp = whatsapp;
            TemporaryAddress = temporaryAddress;
            TemporaryWardId = temporaryWardId;
            TemporaryDistrictId = temporaryDistrictId;
            TemporaryProvinceId = temporaryProvinceId;
            PermanentAddress = permanentAddress;
            PermanentWardId = permanentWardId;
            PermanentDistrictId = permanentDistrictId;
            PermanentProvinceId = permanentProvinceId;
            IsActive = isActive;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(15)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Skyper { get; set; }

        [MaxLength(20)]
        public string Zalo { get; set; }

        [MaxLength(200)]
        public string Facebook { get; set; }

        [MaxLength(200)]
        public string LinkedIn { get; set; }

        [MaxLength(200)]
        public string Twitter { get; set; }

        [MaxLength(200)]
        public string Github { get; set; }

        [MaxLength(20)]
        public string Whatsapp { get; set; }

        [MaxLength(250)]
        public string TemporaryAddress { get; set; }

        //TODO
        public long? TemporaryWardId { get; set; }
        //TODO
        public long? TemporaryDistrictId { get; set; }
        //TODO
        public long? TemporaryProvinceId { get; set; }

        [MaxLength(250)]
        public string PermanentAddress { get; set; }
        //TODO
        public long? PermanentWardId { get; set; }
        //TODO
        public long? PermanentDistrictId { get; set; }
        //TODO
        public long? PermanentProvinceId { get; set; }

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
