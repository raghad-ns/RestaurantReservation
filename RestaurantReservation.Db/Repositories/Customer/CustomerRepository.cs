using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories.Customer;

public class CustomerRepository
{
    private readonly RestaurantReservationDbContext _db;

    public CustomerRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddCustomer(Db.Models.Customer customer)
    {
        _db.Customer.Add(customer);
        await _db.SaveChangesAsync();
        return customer.Id;
    }

    public async Task DeleteCustomer(Models.Customer customer)
    {
        _db.Customer.Remove(customer);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.Customer> UpdateCustomer(Models.Customer newCustomer)
    {
        _db.Customer.Update(newCustomer); // Will add new record if customer doesn't exist
        await _db.SaveChangesAsync();
        return newCustomer;
    }

    public Task<List<Models.Customer>> GetCustomersHaveReservationWithPartySizeGreaterThan(int partySize)
    {
        return _db.Customer.
            FromSqlInterpolated($"EXEC FindCustomersHaveReservationWithPartySizeGreaterThan {partySize}")
            .ToListAsync();
    }
}