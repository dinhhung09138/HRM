using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.Model;
using HRM.Model.System;
using System.Security.Claims;
using HRM.Constant;

namespace HRM.Client.Auth
{
    public class HrmAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public HrmAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                //TokenModel userInfo = new TokenModel("abc", 1);
                var userInfo = await _localStorageService.GetItemAsync<TokenModel>(ConstantKey.USER_SESSION_STORAGE_KEY);

                if (userInfo != null)
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userInfo.EmployeeId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userInfo.EmployeeId.ToString()),
                    new Claim(ClaimTypes.Email, userInfo.EmployeeId.ToString())
                }, "apiauth_type");

                    var user = new ClaimsPrincipal(identity);

                    return await Task.FromResult(new AuthenticationState(user));
                }
            }
            catch (Exception ex)
            {
            }
            var anonymous = new ClaimsIdentity();
            return new AuthenticationState(new ClaimsPrincipal(anonymous));
        }

        public void NotifyAuthenticationStateChanged()
        {
            var auth = GetAuthenticationStateAsync();
            NotifyAuthenticationStateChanged(auth);
        }

        public async Task Login(TokenModel model)
        {
            await _localStorageService.SetItemAsync<TokenModel>(ConstantKey.USER_SESSION_STORAGE_KEY, model);

            if (model != null)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, model.EmployeeId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, model.EmployeeId.ToString()),
                    new Claim(ClaimTypes.Email, model.EmployeeId.ToString())
                }, "apiauth_type");

                var claimsPrincipal = new ClaimsPrincipal(identity);

                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            }
        }

        public async Task DoLogout()
        {
            await _localStorageService.RemoveItemAsync(ConstantKey.USER_SESSION_STORAGE_KEY);

            var identity = new ClaimsIdentity();

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

    }
}
