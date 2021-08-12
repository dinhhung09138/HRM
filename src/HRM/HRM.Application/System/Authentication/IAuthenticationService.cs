using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using DotNetCore.Results;

namespace HRM.Application.System
{
    public interface IAuthenticationService
    {
        Task<IResult<TokenModel>> SignInAsync(LoginModel model);
    }
}
