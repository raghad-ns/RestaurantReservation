namespace RestaurantReservation.Db.OrderItem.Repositories;

public interface IOrderItemItemRepository
{
    Task<int> AddOrderItem(Models.OrderItem orderItem);

    Task DeleteOrderItem(Models.OrderItem orderItem);

    Task<Models.OrderItem> UpdateOrderItem(Models.OrderItem newOrderItem);
}