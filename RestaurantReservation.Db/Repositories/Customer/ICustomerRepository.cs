namespace RestaurantReservation.Db.Repositories.Customer
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomer(Models.Customer customer);
        Task DeleteCustomer(Models.Customer customer);
        Task<Models.Customer> UpdateCustomer(Models.Customer newCustomer);
        Task<List<Models.Customer>> GetCustomersHaveReservationWithPartySizeGreaterThan(int partySize);
    }
}
