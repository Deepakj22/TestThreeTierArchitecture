
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using ThreeTierArchitecture.Domain.Entities;
using ThreeTierArchitecture.Domain.Interface;

namespace DataAccessLayer.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _dbContext;
    public EmployeeRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
       var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if(employee == null) 
            return false;
        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
       return await _dbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        if (employee == null)
             throw new ArgumentNullException(nameof(employee));

        var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);

        if (existingEmployee == null)
            throw new Exception("Employee not found");

        existingEmployee.FullName = employee.FullName;
        existingEmployee.City = employee.City;

        await _dbContext.SaveChangesAsync();
        return existingEmployee;
    }
}
