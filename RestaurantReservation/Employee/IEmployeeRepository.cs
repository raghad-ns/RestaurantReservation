namespace RestaurantReservation.Db.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployee(Models.Employee employee);
        Task DeleteEmployee(Models.Employee employee);
        Task<Models.Employee> UpdateEmployee(Models.Employee newEmployee);
    }
}
