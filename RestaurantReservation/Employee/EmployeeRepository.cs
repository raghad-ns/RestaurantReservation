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
        _db.Employee.Add(employee);
        await _db.SaveChangesAsync();
        return employee.Id;
    }

    public async Task DeleteEmployee(Db.Models.Employee employee)
    {
        _db.Employee.Remove(employee);
        await _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Employee> UpdateEmployee(Db.Models.Employee newEmployee)
    {
        _db.Employee.Update(newEmployee);
        await _db.SaveChangesAsync();
        return newEmployee;
    }

    public Task<List<Db.Models.Employee>> ListManagers()
    {
        return _db.Employee
            .Where(emp => emp.Position.Equals("Manager"))
            .ToListAsync();
    }

    public Task<List<EmployeeRestaurantDetails>> GetEmployeeRestaurantDetails()
    {
        return _db.EmployeeRestaurantDetails.ToListAsync();
    }
}