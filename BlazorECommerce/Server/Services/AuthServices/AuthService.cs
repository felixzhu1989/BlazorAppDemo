using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BlazorECommerce.Server.Services.AuthServices;

public class AuthService:IAuthService
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(DataContext context,IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<int> { Success = false, Message = "User already exists." };
        }
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        _context.Users.Add(user);
       await _context.SaveChangesAsync();
       return new ServiceResponse<int>{Data = user.Id,Message = "Registration successful!"};
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
    public Task<bool> UserExists(string email)
    {
        return _context.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var response = new ServiceResponse<string>();
        var user=await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found.";
        }
        else if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password.";
        }
        else
        {
            response.Data = CreateToken(user);
        }
        return response;
    }

    

    /// <summary>
    /// 核验密码是否正确
    /// </summary>
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
       var computedHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
       return computedHash.SequenceEqual(passwordHash);//无需使用foreach去对比数组
    }
    /// <summary>
    /// 生成JwtToken
    /// </summary>
    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Email)
        };
        var secKey = _configuration.GetSection("AppSettings:Token").Value;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims:claims,
            expires:DateTime.Now.AddDays(1),
            signingCredentials:creds);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            return new ServiceResponse<bool> { Success = false, Message = "User not found." };
        }
        CreatePasswordHash(newPassword,out byte[] passwordHash,out byte[] passwordSalt);
        user.PasswordHash=passwordHash;
        user.PasswordSalt = passwordSalt;
        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
    }
}