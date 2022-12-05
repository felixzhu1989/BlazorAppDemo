using System.ComponentModel.DataAnnotations;

namespace BlazorECommerce.Shared;

public class UserRegister
{
    [Required,EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required,StringLength(10,MinimumLength = 3)]
    public string Password { get; set; } = string.Empty;
    [Compare("Password",ErrorMessage = "The password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}