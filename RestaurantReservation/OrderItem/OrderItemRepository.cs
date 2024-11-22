using RestaurantReservation.Db;

namespace RestaurantReservation.OrderItem;

public class OrderItemRepository
{
    private readonly RestaurantReservationDbContext _db;

    public OrderItemRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddOrderItem(Db.Models.OrderItem orderItem)
    {
        _db.OrderItem.AddAsync(orderItem);
        _db.SaveChangesAsync();
        return orderItem.Id;
    }

    public async Task DeleteOrderItem(Db.Models.OrderItem orderItem)
    {
        _db.OrderItem.Remove(orderItem);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.OrderItem> UpdateOrderItem(int orderItemId,Db.Models.OrderItem newOrderItem)
    {
        var OrderItem = await _db.OrderItem.FindAsync(orderItemId);
        OrderItem = newOrderItem;
        _db.SaveChangesAsync();
        return OrderItem;
    }
}