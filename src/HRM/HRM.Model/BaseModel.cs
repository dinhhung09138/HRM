using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model
{
    public class BaseModel
    {
        public long Id { get; set; }

        [RegularExpression("\\d{1,3}", ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Precedence")]
        public int Precedence { get; set; }

        public bool IsActive { get; set; }

        public long CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public long? UpdateBy { get; set; }

        public bool Deleted { get; set; }

        public byte[] RowVersion { get; set; }

        public BaseModel()
        {
            Precedence = 1;
            IsActive = true;
        }
    }
}
