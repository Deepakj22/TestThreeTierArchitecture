
using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Entities;
using ThreeTierArchitecture.Domain.Entities;
using ThreeTierArchitecture.Domain.Interface;

namespace BusinessLogicLayer.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task AddEmployeeAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FullName = dto.FullName,
            City = dto.City
        };
        await _repository.AddEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
       await _repository.DeleteEmployeeAsync(id);
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
       var employees = await _repository.GetAllEmployeesAsync();
        return employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FullName = e.FullName,
            City = e.City,
        });
    }

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
    {
       var employee = await _repository.GetEmployeeByIdAsync(id);
        if (employee == null)
            throw new Exception($"Employee not found for the given {id}");
        return new EmployeeDto
        {
            Id = employee.Id,
            FullName = employee.FullName,
            City = employee.City,
        };
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeDto dto)
    {
       var employee = await _repository.GetEmployeeByIdAsync(dto.Id);

        if (employee == null)
              throw new Exception($"{dto.Id} was not found");

        employee.FullName = dto.FullName;
        employee.City = dto.City;

        await _repository.UpdateEmployeeAsync(employee);
    }
}
