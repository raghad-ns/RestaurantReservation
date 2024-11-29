using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Order.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _db;

    public OrderRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddOrder(Models.Order order)
    {
        _db.Order.Add(order);
        await _db.SaveChangesAsync();
        return order.Id;
    }

    public async Task DeleteOrder(Models.Order order)
    {
        _db.Order.Remove(order);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.Order> UpdateOrder(Models.Order newOrder)
    {
        _db.Order.Update(newOrder);
        await _db.SaveChangesAsync();
        return newOrder;
    }

    public Task<List<Models.Order>> ListOrdersAndMenuItems(int reservationId)
    {
        return _db.Order
            .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.MenuItem)
            .Where(order => order.ReservationId == reservationId).ToListAsync();
    }
}