using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model.System
{
    public class TokenModel
    {
        public string Token { get; set; }

        public long EmployeeId { get; set; }

        public string RefreshToken { get; set; }

        public TokenModel(string token, long employeeId, string refreshToken = "")
        {
            Token = token;
            EmployeeId = employeeId;
            RefreshToken = refreshToken;
        }
    }
}
