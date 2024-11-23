using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

namespace RestaurantReservation.Customer;

public class CustomerRepository
{
    private readonly RestaurantReservationDbContext _db;

    public CustomerRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddCustomer(Db.Models.Customer customer)
    {
        _db.Customer.AddAsync(customer);
        _db.SaveChangesAsync();
        return customer.Id;
    }

    public async Task DeleteCustomer(Db.Models.Customer customer)
    {
        _db.Customer.Remove(customer);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Customer> UpdateCustomer(int customerId,Db.Models.Customer newCustomer)
    {
        var customer = await _db.Customer.FindAsync(customerId);
        customer = newCustomer;
        _db.SaveChangesAsync();
        return customer;
    }

    public Task<List<Db.Models.Customer>> GetCustomersHaveReservationWithPartySizeGreaterThan(int partySize)
    {
        return _db.Customer.FromSqlInterpolated($"EXEC FindCustomersHaveReservationWithPartySizeGreaterThan {partySize}").ToListAsync();
    }
}