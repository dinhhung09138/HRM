using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Client.Models
{
    public class AppSettingModel
    {
        public string Cors { get; set; }
        public AppSettings AppSettings { get; set; }

    }

    public class AppSettings
    {
        public string ApiUrl { get; set; }
    }
}
