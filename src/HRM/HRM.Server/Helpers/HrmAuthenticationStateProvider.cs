using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using HRM.Model.System;
using HRM.Constant;

namespace HRM.Server.Helpers
{
    public class HrmAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;


        public HrmAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(5000);

            //var identity = new ClaimsIdentity(new[] {
            //        new Claim(ClaimTypes.Name, "abc"),
            //        new Claim(ClaimTypes.Role, "admin")
            //    }, "apiauth_type");

            //var user = new ClaimsPrincipal(identity);

            //return await Task.FromResult(new AuthenticationState(user));

            try
            {
                TokenModel userInfo = new TokenModel("abc", 1);
                //var userInfo = await _sessionStorageService.GetItemAsync<TokenModel>(ConstantKey.USER_SESSION_STORAGE_KEY);

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
            catch(Exception ex)
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

        public void MarkUserAsAuthenticated(TokenModel model)
        {
            //await _sessionStorageService.SetItemAsync<TokenModel>(ConstantKey.USER_SESSION_STORAGE_KEY, model);

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
            //await _sessionStorageService.RemoveItemAsync(ConstantKey.USER_SESSION_STORAGE_KEY);

            var identity = new ClaimsIdentity();

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public void SetAuthenticationState(Task<AuthenticationState> authenticationStateTask)
        {
            NotifyAuthenticationStateChanged(authenticationStateTask);
        }
    }
}
