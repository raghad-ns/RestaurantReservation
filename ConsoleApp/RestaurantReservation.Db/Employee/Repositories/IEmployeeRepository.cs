namespace RestaurantReservation.Db.Employee.Repositories;

public interface IEmployeeRepository
{
    Task<int> AddEmployee(Models.Employee employee);
    Task DeleteEmployee(Models.Employee employee);
    Task<Models.Employee> UpdateEmployee(Models.Employee newEmployee);
}