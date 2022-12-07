using System.ComponentModel.DataAnnotations;

namespace BlazorECommerce.Shared;

public class UserChangePassword
{
    [Required,StringLength(10,MinimumLength = 3)]
    public string Password { get; set; }=String.Empty;
    [Compare("Password",ErrorMessage = "The password do not match.")]
    public string ConfirmPassword { get; set; } = String.Empty;
}