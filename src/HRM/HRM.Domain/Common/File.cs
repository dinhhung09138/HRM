using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore.Domain;

namespace HRM.Domain.Common
{
    /// <summary>
    /// TODO
    /// File
    /// </summary>
    public class File : Entity<long>
    {
        public File(
            string fileName,
            decimal size,
            string mineType,
            string extension,
            string systemFileName,
            string filePath,
            string filePath32,
            string filePath64,
            string filePath128,
            long createBy,
            DateTime createDate)
        {
            FileName = fileName;
            Size = size;
            MineType = mineType;
            Extension = extension;
            SystemFileName = systemFileName;
            FilePath = filePath;
            FilePath32 = filePath32;
            FilePath64 = filePath64;
            FilePath128 = filePath128;
            CreateBy = createBy;
            CreateDate = createDate;
        }

        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }

        [Required]
        public decimal Size { get; set; }

        [Required]
        [MaxLength(20)]
        public string MineType { get; set; }

        [Required]
        [MaxLength(10)]
        public string Extension { get; set; }

        [Required]
        [MaxLength(100)]
        public string SystemFileName { get; set; }

        [MaxLength(300)]
        public string FilePath { get; set; }

        [MaxLength(300)]
        public string FilePath32 { get; set; }

        [MaxLength(300)]
        public string FilePath64 { get; set; }

        [MaxLength(300)]
        public string FilePath128 { get; set; }

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
