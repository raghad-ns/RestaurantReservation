using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Employee;

public class EmployeeRepository
{
    private readonly RestaurantReservationDbContext _db;

    public EmployeeRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddEmployee(Db.Models.Employee employee)
    {
        _db.Employee.AddAsync(employee);
        _db.SaveChangesAsync();
        return employee.Id;
    }

    public async Task DeleteEmployee(Db.Models.Employee employee)
    {
        _db.Employee.Remove(employee);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Employee> UpdateEmployee(int employeeId, Db.Models.Employee newEmployee)
    {
        var Employee = await _db.Employee.FindAsync(employeeId);
        Employee = newEmployee;
        _db.SaveChangesAsync();
        return Employee;
    }

    public Task<List<Db.Models.Employee>> ListManagers()
    {
        return _db.Employee.Where(emp => emp.Position.Equals("Manager")).ToListAsync();
    }

    public Task<List<EmployeeRestaurantDetails>> GetEmployeeRestaurantDetails()
    {
        return _db.Set<EmployeeRestaurantDetails>().ToListAsync();
    }
}