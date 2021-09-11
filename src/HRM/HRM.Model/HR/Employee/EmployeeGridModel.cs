using System;

namespace HRM.Model.HR
{
    public class EmployeeGridModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public string TypeOfWork { get; set; } // Nhân viên chính thức, nhân viên bán thời gian

        public bool IsActive { get; set; }
    }
}
