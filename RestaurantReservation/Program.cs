using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
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

        // Calling the DB Function
        var revenue = await (new RestaurantReservationDbContext()).Order
            .Where(o => o.Reservation.RestaurantId == 1)
            .Select(o => RestaurantReservationDbContext.RestaurantRevenue(1))
            .FirstOrDefaultAsync();
        Console.WriteLine(revenue);
    }
}