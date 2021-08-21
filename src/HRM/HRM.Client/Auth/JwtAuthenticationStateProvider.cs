using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HRM.Constant;
using HRM.Infrastructure.Extension;
using HRM.Model.System;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.Text.Json;
using HRM.Client.Services;

namespace HRM.Client.Auth
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IClientStorageService _clientStorage;
        private readonly HttpClient _httpClient;

        public JwtAuthenticationStateProvider(
            HttpClient httpClient, 
            IClientStorageService clientStorage)
        {
            _httpClient = httpClient;
            _clientStorage = clientStorage;
        }

        private AuthenticationState Anonymous =>
            new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenInfo = await _clientStorage.GetItem(Constant.ConstantKey.TOKEN_STORAGE_KEY);

            if (tokenInfo == null) {
                return Anonymous;
            }


            var expirationTimeString = await _clientStorage.GetItem(Constant.ConstantKey.USER_SESSION_TIMEOUT);
            DateTime expirationTime;

            if (DateTime.TryParse(expirationTimeString, out expirationTime))
            {
                if (IsTokenExpired(expirationTime))
                {
                    await CleanUp();
                    return Anonymous;
                }

                if (ShouldRenewToken(expirationTime))
                {
                    //tokenInfo = await RenewToken(tokenInfo);
                }
            }

            return BuildAuthenticationState(tokenInfo);
        }

        private async Task<TokenModel> RenewToken(TokenModel token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Token);
            //var newToken = await accountsRepository.RenewToken(); TODO
            var newToken = "123";//TODO
            //await _clientStorage.SetItem<TokenModel>(ConstantKey.USER_SESSION_STORAGE_KEY, token);
            //await _clientStorage.SetItem<string>(ConstantKey.USER_SESSION_TIMEOUT, newToken);
            return token;
        }

        private bool IsTokenExpired(DateTime expirationTime)
        {
            return expirationTime <= DateTime.UtcNow;
        }

        private bool ShouldRenewToken(DateTime expirationTime)
        {
            return expirationTime.Subtract(DateTime.UtcNow) < TimeSpan.FromMinutes(5);
        }

        public AuthenticationState BuildAuthenticationState(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        private async Task CleanUp()
        {
            //await _clientStorage.RemoveItem(ConstantKey.USER_SESSION_STORAGE_KEY);
            //await _clientStorage.RemoveItem(ConstantKey.USER_SESSION_TIMEOUT);
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
