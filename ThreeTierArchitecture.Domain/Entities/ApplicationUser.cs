
namespace ThreeTierArchitecture.Domain.Entities;
public class ApplicationUser
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty; 
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Role { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}

//public string Role { get; set; } = string.Empty;