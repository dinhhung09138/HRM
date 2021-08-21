using HRM.Domain.System;
using HRM.Model.System.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.System
{
    public class RefreshTokenFactory : IRefreshTokenFactory
    {
        public SystemRefreshToken Create(RefreshTokenModel model)
        {
            SystemRefreshToken md = new SystemRefreshToken();
            md.UserId = model.UserId;
            md.Token = model.Token;
            md.CreatedByIp = model.CreatedByIp;
            md.CreateDate = DateTime.Now;
            md.Expires = model.Expires;

            return md;
        }

        public SystemRefreshToken Revoke(RefreshTokenModel model)
        {
            return new SystemRefreshToken(model.Id, model.Revoked, model.RevokedByIp, model.ReplacedByToken);
        }
    }
}
