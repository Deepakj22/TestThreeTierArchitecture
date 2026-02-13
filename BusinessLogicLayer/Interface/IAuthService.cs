using BusinessLogicLayer.Dto;

namespace BusinessLogicLayer.Interface;

public interface IAuthService
{
    Task<string> ResgisterAsync(RegisterUserDto dto);
    Task<string> LoginAsync(LoginDto dto);
}
