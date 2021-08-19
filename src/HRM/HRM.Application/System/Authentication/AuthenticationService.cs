using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Model.System;
using HRM.Domain.System;
using HRM.Database;
using HRM.Database.System;
using DotNetCore.Results;
using System.Security.Claims;
using DotNetCore.Extensions;
using DotNetCore.Security;
using HRM.Constant;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using HRM.Model;
using Microsoft.Extensions.Options;

namespace HRM.Application.System
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiSettingModel _apiSettingModel;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashService _hashService;
        private readonly IJsonWebTokenService _jsonWebTokenService;
        private readonly ISystemUserRepository _systemUserRepository;

        public AuthenticationService(
            IOptions<ApiSettingModel> apiSettingModel,
            IUnitOfWork unitOfWork,
            IHashService hashService,
            IJsonWebTokenService jsonWebTokenService,
            ISystemUserRepository systemUserRepository)
        {
            _apiSettingModel = apiSettingModel.Value;
            _unitOfWork = unitOfWork;
            _hashService = hashService;
            _systemUserRepository = systemUserRepository;
            _jsonWebTokenService = jsonWebTokenService;
        }


        public async Task<IResult<TokenModel>> SignInAsync(LoginModel model)
        {
            var failResult = Result<TokenModel>.Fail(Message.INVALID_LOGIN);

            var validation = await new LoginModelValidator().ValidateAsync(model);

            if (validation.IsValid == false)
            {
                return failResult;
            }

            var user = await _systemUserRepository.GetByUserNameAsync(model.UserName);

            if (user is null)
            {
                return failResult;
            }
            string password = _hashService.Create(model.Password, user.Salt);

            if (user.Password.ToLower() != password.ToLower())
            {
                return failResult;
            }

            var token = CreateToken(user);

            return Result<TokenModel>.Success(token);
        }

        public TokenModel CreateToken(long employeeId)
        {
            var claims = new List<Claim>();

            claims.AddSub(employeeId.ToString());

            //TODO
            //foreach (var r in model.User.Roles)
            //{
            //    claims.AddRoles((r.Role).ToStringArray());
            //}

            var token = _jsonWebTokenService.Encode(claims);

            var tokenModel = new TokenModel(token, employeeId);

            return tokenModel;
        }

        private TokenModel CreateToken(SystemUser user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_apiSettingModel.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.EmployeeId.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return new TokenModel(tokenString, user.EmployeeId);
        }

    }
}
