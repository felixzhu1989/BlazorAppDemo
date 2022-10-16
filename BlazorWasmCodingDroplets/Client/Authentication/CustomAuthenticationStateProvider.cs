using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using BlazorWasmCodingDroplets.Client.Extensions;
using BlazorWasmCodingDroplets.Shared.Authentication;

namespace BlazorWasmCodingDroplets.Client.Authentication
{
    public class CustomAuthenticationStateProvider: AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await _sessionStorage.ReadItemEncryptedAsync<UserSession>("UserSession");
                if(userSession==null) return await Task.FromResult(new AuthenticationState(_anonymous));
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(
                    new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,userSession.UserName),
                        new Claim(ClaimTypes.Role,userSession.Role),
                    }, "JwtAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }
        //当用户登录或者退出时调用
        public async Task UpdateAuthenticationState(UserSession? userSession)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)//登录时
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(
                    new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,userSession.UserName),
                        new Claim(ClaimTypes.Role,userSession.Role)
                    }));
                userSession.ExpiryTimeStamp=DateTime.Now.AddSeconds(userSession.ExpiresIn);
                await _sessionStorage.SaveItemEncryptedAsync("UserSession", userSession);
            }
            else//退出时
            {
                await _sessionStorage.RemoveItemAsync("UserSession");
                claimsPrincipal = _anonymous;
            }
            //通知状态更新
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        //供razor组件获取session中的token
        public async Task<string> GetToken()
        {
            var result=string.Empty;
            try
            {
                var userSession = await _sessionStorage.ReadItemEncryptedAsync<UserSession>("UserSession");
                //如果读到了UserSession，并且没有过期
                if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp)
                {
                    result=userSession.Token;
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }
    }
}
