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
    public class CommonCodeType : Entity<long>
    {
        public CommonCodeType()
        {

        }

        [Column(TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string ModuleName { get; set; }
    }
}
