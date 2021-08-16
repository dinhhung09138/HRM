using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Client.Models
{
    public class HttpActionResponseWrapper
    {
        public bool Failed { get; set; }

        public bool Succeeded { get; set; }

        public string Message { get; set; }
    }
}
