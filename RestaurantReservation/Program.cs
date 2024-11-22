using RestaurantReservation.Db;
using RestaurantReservation.Order;
using RestaurantReservation.OrderItem;
using System.Xml;

namespace RestaurantReservation;

public class Program
{
    static async Task Main(string[] args)
    {
        var repo = new OrderItemRepository(new RestaurantReservationDbContext());
        var items = await repo.ListOrderedMenuItemsForReservation(1);
        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }
    }
}