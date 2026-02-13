
namespace ThreeTierArchitecture.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public ApplicationUser? ApplicationUser { get; set; }
}
