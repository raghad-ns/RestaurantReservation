namespace RestaurantReservation.Db.Order.Repositories;

public interface IOrderRepository
{
    Task<int> AddOrder(Models.Order Order);

    Task DeleteOrder(Models.Order Order);

    Task<Models.Order> UpdateOrder(Models.Order newOrder);
}