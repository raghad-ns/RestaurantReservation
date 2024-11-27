namespace RestaurantReservation.Order;

public interface IOrderRepository
{
    Task<int> AddOrder(Db.Models.Order Order);

    Task DeleteOrder(Db.Models.Order Order);

    Task<Db.Models.Order> UpdateOrder(Db.Models.Order newOrder);
}