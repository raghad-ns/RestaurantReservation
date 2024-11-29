using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Employee.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _db;

    public EmployeeRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddEmployee(Models.Employee employee)
    {
        _db.Employee.Add(employee);
        await _db.SaveChangesAsync();
        return employee.Id;
    }

    public async Task DeleteEmployee(Models.Employee employee)
    {
        _db.Employee.Remove(employee);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.Employee> UpdateEmployee(Models.Employee newEmployee)
    {
        _db.Employee.Update(newEmployee);
        await _db.SaveChangesAsync();
        return newEmployee;
    }

    public Task<List<Models.Employee>> ListManagers()
    {
        return _db.Employee
            .Where(emp => emp.Position.Equals("Manager"))
            .ToListAsync();
    }

    public Task<List<EmployeeRestaurantDetails.Models.EmployeeRestaurantDetails>> GetEmployeeRestaurantDetails()
    {
        return _db.EmployeeRestaurantDetails.ToListAsync();
    }
}