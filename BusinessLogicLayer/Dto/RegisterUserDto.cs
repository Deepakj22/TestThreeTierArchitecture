
using System.ComponentModel.DataAnnotations;
//using ThreeTierArchitecture.Domain.Entities;

namespace BusinessLogicLayer.Dto;

public class RegisterUserDto
{
    [Required]
    [MinLength(3)]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [Compare("Password",
        ErrorMessage = "Password do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
    //[Required]
    //public UserRole Role { get; set; } 
}
