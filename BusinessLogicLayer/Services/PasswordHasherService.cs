
using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Identity;
using ThreeTierArchitecture.Domain.Entities;

namespace BusinessLogicLayer.Services;

public class PasswordHasherService : IPasswordHasher
{
    private readonly PasswordHasher<ApplicationUser> _hasher = new();
    public string HashPassword(string password)
    {
        return _hasher.HashPassword(null!,password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var result = _hasher.VerifyHashedPassword(null!,hashedPassword,password);
        return result == PasswordVerificationResult.Success;
    }
}
