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
using System.Security.Cryptography;
using HRM.Model.System.Authentication;

namespace HRM.Application.System
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiSettingModel _apiSettingModel;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashService _hashService;
        private readonly IRefreshTokenFactory _refreshTokenFactory;
        private readonly IJsonWebTokenService _jsonWebTokenService;
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly ISystemRefreshTokenRepository _refreshTokenRepository;

        public AuthenticationService(
            IOptions<ApiSettingModel> apiSettingModel,
            IUnitOfWork unitOfWork,
            IHashService hashService,
            IRefreshTokenFactory refreshTokenFactory,
            IJsonWebTokenService jsonWebTokenService,
            ISystemUserRepository systemUserRepository,
            ISystemRefreshTokenRepository refreshTokenRepository)
        {
            _apiSettingModel = apiSettingModel.Value;
            _unitOfWork = unitOfWork;
            _hashService = hashService;
            _refreshTokenFactory = refreshTokenFactory;
            _systemUserRepository = systemUserRepository;
            _jsonWebTokenService = jsonWebTokenService;
            _refreshTokenRepository = refreshTokenRepository;
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

            var refreshTokenModel = GenerateRefreshToken(model.IpAddress);
            refreshTokenModel.UserId = user.Id;

            var token = CreateToken(user);
            token.RefreshToken = refreshTokenModel.Token;

            var refreshToken = _refreshTokenFactory.Create(refreshTokenModel);

            await _refreshTokenRepository.SaveAsync(refreshToken, true);
            await _unitOfWork.SaveChangesAsync();

            return Result<TokenModel>.Success(token);
        }

        public async Task<IResult<TokenModel>> RefreshToken(long userId, string token, string ipAddress)
        {
            var user = await _systemUserRepository.FindByIdAsync(userId);

            // return null if no user found with token
            if (user == null) return null;

            var refreshToken = await _refreshTokenRepository.GetByToken(token, userId);

            // return null if token is no longer active
            if (!refreshToken.IsActive) return null;

            // replace old refresh token with a new one and save
            var newRefreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            //user.RefreshTokens.Add(newRefreshToken);

            var revokedModel = _refreshTokenFactory.Revoke(newRefreshToken);
            await _refreshTokenRepository.RevokeAsync(revokedModel);

            var tokenModel = _refreshTokenFactory.Create(newRefreshToken);
            await _refreshTokenRepository.SaveAsync(tokenModel, true);

            await _unitOfWork.SaveChangesAsync();

            // generate new jwt
            var jwtToken = CreateToken(user);
            jwtToken.RefreshToken = newRefreshToken.Token;

            return Result<TokenModel>.Success(jwtToken);
        }

        //public bool RevokeToken(string token, string ipAddress)
        //{
        //    var user = await _refreshTokenRepository.GetByToken(token, 0);

        //    // return false if no user found with token
        //    if (user == null) return false;

        //    var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        //    // return false if token is not active
        //    if (!refreshToken.IsActive) return false;

        //    // revoke token and save
        //    refreshToken.Revoked = DateTime.UtcNow;
        //    refreshToken.RevokedByIp = ipAddress;
        //    _context.Update(user);
        //    _context.SaveChanges();

        //    return true;
        //}

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

        private RefreshTokenModel GenerateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshTokenModel
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }
    }
}
