using Microsoft.EntityFrameworkCore;
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

    public Task<double> CalculateAverageOrderAmountForEmployee(int employeeId)
    {
        return _db.Order
            .Where(order => order.EmployeeId == employeeId)
            .AverageAsync(order => order.TotalAmount);
    } 

    public async Task<List<Db.Models.MenuItem>> ListOrderedMenuItemsForReservation(int reservationId)
    {
        var orders = await _db.Order
            .Where(order => order.ReservationId == reservationId)
            .Include(order => order.Items)
            .ThenInclude(orderItem => orderItem.Item)
            .ToListAsync();

        var items = new List<Db.Models.MenuItem>();

        foreach (var order in orders)
        {
            items.AddRange(order.Items.Select(orderItem => orderItem.Item));
        }

        return items;
    }
}