using System;
using System.Collections.Generic;

namespace HRM.Model.HR
{
    public class CustomerGridModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public List<CustomerContactGridModel> Contacts { get; set; } = new List<CustomerContactGridModel>();
    }
}
