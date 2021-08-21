using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.Repositories;
using DotNetCore.Objects;
using HRM.Model.System.Authentication;

namespace HRM.Database.System
{
    public interface ISystemRefreshTokenRepository
    {
        Task<RefreshTokenModel> GetByToken(string token, long userId);

        Task<bool> SaveAsync(SystemRefreshToken model, bool isCreate);

        Task<bool> RevokeAsync(SystemRefreshToken model);
    }
}
