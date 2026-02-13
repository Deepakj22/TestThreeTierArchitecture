
using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Interface;
using ThreeTierArchitecture.Domain.Entities;
using ThreeTierArchitecture.Domain.Interface;

namespace BusinessLogicLayer.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUserRepository repository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService
        )
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }
    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _repository.GetApplicationUserByUserNameAsync(dto.Email);
        if (user == null||_passwordHasher.VerifyPassword(dto.Password,user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }
        return _tokenService.GenerateJwtToken(user);
    }

    public async Task<string> ResgisterAsync(RegisterUserDto dto)
    {
        var user = new ApplicationUser
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Role = dto.Role,
            PasswordHash = _passwordHasher.HashPassword(dto.Password)

        };
        await _repository.AddApplicationUserAsync(user);
        return _tokenService.GenerateJwtToken(user);
    }
}
