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
        _db.OrderItem.Add(orderItem);
        await _db.SaveChangesAsync();
        return orderItem.Id;
    }

    public async Task DeleteOrderItem(Db.Models.OrderItem orderItem)
    {
        _db.OrderItem.Remove(orderItem);
        await _db.SaveChangesAsync();
    }

    public async Task<Db.Models.OrderItem> UpdateOrderItem(Db.Models.OrderItem newOrderItem)
    {
        _db.OrderItem.Update(newOrderItem);
        await _db.SaveChangesAsync();
        return newOrderItem;
    }

    public Task<double> CalculateAverageOrderAmountForEmployee(int employeeId)
    {
        return _db.Order
            .Where(order => order.EmployeeId == employeeId)
            .AverageAsync(order => order.TotalAmount);
    } 

    public Task<List<Db.Models.MenuItem>> ListOrderedMenuItemsForReservation(int reservationId)
    {
        return _db.OrderItem
            .Include(orderItem => orderItem.Order)
            .Where(orderItem => orderItem.Order.ReservationId == reservationId)
            .Include(orderItem => orderItem.Item).Select(orderItem => orderItem.Item).ToListAsync();
    }
}