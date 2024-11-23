using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Customer;
using RestaurantReservation.Db;
using RestaurantReservation.OrderItem;

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

        var customerRepo = new CustomerRepository(new RestaurantReservationDbContext());
        var customers = await customerRepo.GetCustomersHaveReservationWithPartySizeGreaterThan(1);
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.FirstName);
        }
    }
}