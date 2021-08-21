using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.Model;
using HRM.Model.System;
using System.Security.Claims;
using HRM.Client.Services;
using HRM.Constant;

namespace HRM.Client.Auth
{
    public class HrmAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IClientStorageService _localStorageService;

        public HrmAuthenticationStateProvider(IClientStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var token = await _localStorageService.GetItem(Constant.ConstantKey.TOKEN_STORAGE_KEY);

            if (string.IsNullOrEmpty(token))
            {
                var anonymous = new ClaimsIdentity();
                return new AuthenticationState(new ClaimsPrincipal(anonymous));
            }

            var employeeId = await _localStorageService.GetItem(Constant.ConstantKey.EMPLOYEE_ID_STORAGE_KEY);

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, employeeId),
                    new Claim(ClaimTypes.NameIdentifier, employeeId),
                    new Claim(ClaimTypes.Email, "abc@gmail.com"),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Role, "Account")
                }, "apiauth_type");

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void NotifyAuthenticationStateChanged()
        {
            var auth = GetAuthenticationStateAsync();
            NotifyAuthenticationStateChanged(auth);
        }

        public async Task DoLogin(TokenModel model)
        {

            if (model != null)
            {
                await _localStorageService.SetItem(ConstantKey.TOKEN_STORAGE_KEY, model.Token);
                await _localStorageService.SetItem(ConstantKey.EMPLOYEE_ID_STORAGE_KEY, model.EmployeeId.ToString());

                NotifyAuthenticationStateChanged();
            }
        }

        public async Task DoLogout()
        {
            await _localStorageService.RemoveItem(ConstantKey.TOKEN_STORAGE_KEY);
            await _localStorageService.RemoveItem(ConstantKey.EMPLOYEE_ID_STORAGE_KEY);
            await _localStorageService.RemoveItem(ConstantKey.USER_SESSION_TIMEOUT);

            NotifyAuthenticationStateChanged();
        }

    }
}
