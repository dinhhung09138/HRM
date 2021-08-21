using HRM.Domain.System;
using HRM.Model.System.Authentication;

namespace HRM.Application.System
{
    public interface IRefreshTokenFactory
    {
        SystemRefreshToken Create(RefreshTokenModel model);
        SystemRefreshToken Revoke(RefreshTokenModel model);
    }
}
