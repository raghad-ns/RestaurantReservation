using Microsoft.EntityFrameworkCore;
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
        _db.Order.Add(order);
        await _db.SaveChangesAsync();
        return order.Id;
    }

    public async Task DeleteOrder(Db.Models.Order order)
    {
        _db.Order.Remove(order);
        await _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Order> UpdateOrder(Db.Models.Order newOrder)
    {
        _db.Order.Update(newOrder);
        await _db.SaveChangesAsync();
        return newOrder;
    }

    public Task<List<Db.Models.Order>> ListOrdersAndMenuItems(int reservationId)
    {
        return _db.Order
            .Include(order => order.Items)
                .ThenInclude(orderItem => orderItem.Item)
            .Where(order => order.ReservationId == reservationId).ToListAsync();
    }
}