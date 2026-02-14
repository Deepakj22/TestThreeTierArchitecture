
namespace ThreeTierArchitecture.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public Guid ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
}
