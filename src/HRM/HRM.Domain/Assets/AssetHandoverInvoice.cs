using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;
using HRM.Domain.HR;

namespace HRM.Domain.Assets
{
    public class AssetHandoverInvoice : Entity<long>
    {
        public AssetHandoverInvoice(
            long id,
            string code,
            long handoverBy,
            DateTime handoverDate,
            long receiveBy,
            DateTime? receiveDate,
            string notes,
            long createBy,
            DateTime createDate,
            long? updateBy,
            DateTime? updateDate)
        {
            Id = id;
            Code = code;
            HandoverBy = handoverBy;
            HandoverDate = handoverDate;
            ReceiveBy = receiveBy;
            ReceiveDate = receiveDate;
            Notes = notes;
            CreateBy = createBy;
            CreateDate = createDate;
            Deleted = false;
            UpdateBy = updateBy;
            UpdateDate = updateDate;
        }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]

        public long HandoverBy { get; set; }

        public Employee Handover { get; set; }

        [Required]
        public DateTime HandoverDate { get; set; }

        [Required]

        public long ReceiveBy { get; set; }

        public Employee Receiver { get; set; }

        public DateTime? ReceiveDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

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

        public virtual List<AssetHandoverInvoiceDetail> AssetHandoverInvoiceDetails { get; set; }
    }
}
