using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories.OrderItem;

public class OrderItemRepository: IOrderItemItemRepository
{
    private readonly RestaurantReservationDbContext _db;

    public OrderItemRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddOrderItem(Models.OrderItem orderItem)
    {
        _db.OrderItem.Add(orderItem);
        await _db.SaveChangesAsync();
        return orderItem.Id;
    }

    public async Task DeleteOrderItem(Models.OrderItem orderItem)
    {
        _db.OrderItem.Remove(orderItem);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.OrderItem> UpdateOrderItem(Models.OrderItem newOrderItem)
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

    public Task<List<Models.MenuItem>> ListOrderedMenuItemsForReservation(int reservationId)
    {
        return _db.MenuItem.ToListAsync();
        return _db.OrderItem
            .Include(orderItem => orderItem.Order)
            .Where(orderItem => orderItem.Order.ReservationId == reservationId)
            .Include(orderItem => orderItem.MenuItem).Select(orderItem => orderItem.MenuItem)
            .ToListAsync();
    }
}