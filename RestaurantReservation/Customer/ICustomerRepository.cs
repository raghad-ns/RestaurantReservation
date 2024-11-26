namespace RestaurantReservation.Customer
{
    public interface IEmployeeRepository
    {
        Task<int> AddCustomer(Db.Models.Customer customer);
        Task DeleteCustomer(Db.Models.Customer customer);
        Task<Db.Models.Customer> UpdateCustomer(Db.Models.Customer newCustomer);
        Task<List<Db.Models.Customer>> GetCustomersHaveReservationWithPartySizeGreaterThan(int partySize);
    }
}
