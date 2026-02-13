using ThreeTierArchitecture.Domain.Entities;

namespace BusinessLogicLayer.Interface;
public interface ITokenService
{
    string GenerateJwtToken(ApplicationUser user);
}
