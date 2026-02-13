using ThreeTierArchitecture.Domain.Entities;

namespace ThreeTierArchitecture.Domain.Interface;
public interface IUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync();
    Task<ApplicationUser?> GetApplicationUserByEmailAsync(string email);
    Task<ApplicationUser?> GetApplicationUserByUserNameAsync(string username);
    Task<ApplicationUser?> GetApplicationUserByIdAsync(Guid id);
    Task<ApplicationUser> AddApplicationUserAsync(ApplicationUser applicationUser);
    Task<ApplicationUser?> UpdateApplicationUserAsync(ApplicationUser applicationUser);
    Task<bool> DeleteApplicationUserAsync(Guid id);
}
