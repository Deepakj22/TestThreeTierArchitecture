using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using ThreeTierArchitecture.Domain.Entities;
using ThreeTierArchitecture.Domain.Interface;

namespace DataAccessLayer.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser> AddApplicationUserAsync(ApplicationUser applicationUser)
    {
        await _dbContext.Users.AddAsync(applicationUser);
        await _dbContext.SaveChangesAsync();
        return applicationUser;
    }

    public async Task<bool> DeleteApplicationUserAsync(Guid id)
    {
        var employee = await _dbContext.Users.FindAsync(id);
        if (employee != null)
        {
            _dbContext.Users.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<ApplicationUser?> GetApplicationUserByEmailAsync(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Email.ToLower() == email);
    }

    public async Task<ApplicationUser?> GetApplicationUserByIdAsync(Guid id)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<ApplicationUser?> GetApplicationUserByUserNameAsync(string username)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ApplicationUser?> UpdateApplicationUserAsync(ApplicationUser applicationUser)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == applicationUser.Id);
        if (user == null)
              throw new ArgumentNullException(nameof(user));
        user.Email = applicationUser.Email;
        user.UserName = applicationUser.UserName;
        if (!string.IsNullOrWhiteSpace(applicationUser.PasswordHash))
        {
            user.PasswordHash = applicationUser.PasswordHash;
        }
        user.Role = applicationUser.Role;
        await _dbContext.SaveChangesAsync();
        return user;
    }
}
