using RestaurantReservation.Db;

namespace RestaurantReservation.Order;

public class OrderRepository
{
    private readonly RestaurantReservationDbContext _db;

    public OrderRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddOrder(Db.Models.Order order)
    {
        _db.Order.AddAsync(order);
        _db.SaveChangesAsync();
        return order.Id;
    }

    public async Task DeleteOrder(Db.Models.Order order)
    {
        _db.Order.Remove(order);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Order> UpdateOrder(int orderId,Db.Models.Order newOrder)
    {
        var Order = await _db.Order.FindAsync(orderId);
        Order = newOrder;
        _db.SaveChangesAsync();
        return Order;
    }
}