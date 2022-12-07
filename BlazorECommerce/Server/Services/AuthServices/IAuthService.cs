namespace BlazorECommerce.Server.Services.AuthServices;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(User user,string password);//返回用户Id
    Task<bool> UserExists(string email);
    Task<ServiceResponse<string>> Login(string email,string password);//返回值为Token
    Task<ServiceResponse<bool>> ChangePassword(int userId,string newPassword);
}