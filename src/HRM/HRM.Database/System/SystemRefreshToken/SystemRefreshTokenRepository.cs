using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Objects;
using System.Linq;
using HRM.Model.System.Authentication;

namespace HRM.Database.System
{
    public class SystemRefreshTokenRepository : EFRepository<SystemRefreshToken>, ISystemRefreshTokenRepository
    {
        public SystemRefreshTokenRepository(Context context) : base(context) { }

        public async Task<RefreshTokenModel> GetByToken(string token, long userId)
        {
            var model = await Queryable.Where(m => m.Token == token && m.UserId == userId && m.Revoked == null)
                                       .Select(m => new RefreshTokenModel
                                       {
                                           Id = m.Id,
                                           UserId = m.UserId,
                                           Token = m.Token,
                                           Created = m.CreateDate,
                                           CreatedByIp = m.CreatedByIp,
                                           Expires = m.Expires,
                                           Revoked = m.Revoked,
                                           RevokedByIp = m.RevokedByIp,
                                           ReplacedByToken = m.ReplacedByToken,
                                       }).FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> SaveAsync(SystemRefreshToken model, bool isCreate)
        {
            if (isCreate == true)
            {
                await AddAsync(model);
            }
            else
            {
                await UpdatePartialAsync(new
                {
                    model.Id,
                    model.Expires,
                    model.Revoked,
                    model.RevokedByIp,
                    model.ReplacedByToken,
                });
            }

            return true;
        }

        public async Task<bool> RevokeAsync(SystemRefreshToken model)
        {
            await UpdatePartialAsync(new
            {
                model.Id,
                model.Revoked,
                model.RevokedByIp,
                model.ReplacedByToken,
            });

            return true;
        }

    }
}
