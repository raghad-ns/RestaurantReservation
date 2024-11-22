using RestaurantReservation.Db;

namespace RestaurantReservation.Customer;

public class RestaurantRepository
{
    private readonly RestaurantReservationDbContext _db;

    public RestaurantRepository(RestaurantReservationDbContext db)
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
}