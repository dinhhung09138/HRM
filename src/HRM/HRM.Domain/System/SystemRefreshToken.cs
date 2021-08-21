using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain.System
{
    public class SystemRefreshToken : Entity<long>
    {
        public SystemRefreshToken()
        {

        }

        public SystemRefreshToken(
            long id, 
            DateTime? revoked, 
            string revokedByIp, 
            string replacedByToken)
        {
            Id = id;
            Revoked = revoked;
            RevokedByIp = revokedByIp;
            ReplacedByToken = replacedByToken;
        }

        public long UserId { get; set; }

        public SystemUser User { get; set; }

        public string Token { get; set; }

        public DateTime Expires { get; set; }

        //public bool IsExpired => DateTime.UtcNow >= Expires;

        public DateTime CreateDate { get; set; }

        public string CreatedByIp { get; set; }

        public DateTime? Revoked { get; set; }

        public string RevokedByIp { get; set; }

        public string ReplacedByToken { get; set; }

        //public bool IsActive => Revoked == null && !IsExpired;
    }
}
