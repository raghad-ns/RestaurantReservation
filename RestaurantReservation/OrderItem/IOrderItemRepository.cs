namespace RestaurantReservation.OrderItem;

public interface IOrderItemItemRepository
{
    Task<int> AddOrderItem(Db.Models.OrderItem orderItem);

    Task DeleteOrderItem(Db.Models.OrderItem orderItem);

    Task<Db.Models.OrderItem> UpdateOrderItem(Db.Models.OrderItem newOrderItem);
}