
namespace BusinessLogicLayer.Dto;

public class UpdateEmployeeDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
