using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain
{
    public class File : Entity<long>
    {
        public File()
        {

        }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }

        [Column(TypeName = "decimal(12, 0)")]
        [Required]
        public decimal Size { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        [MaxLength(50)]
        public string MineType { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        [MaxLength(10)]
        public string Extension { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        [MaxLength(100)]
        public string SystemFileName { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath32 { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath64 { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath128 { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool WaitForDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }

        [Column(TypeName = "timestamp")]
        [Required]
        public byte[] RowVersion { get; set; }
    }
}
