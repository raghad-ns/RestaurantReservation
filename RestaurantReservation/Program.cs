using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestaurantReservation.Configuration;
using RestaurantReservation.Db.Repositories.OrderItem;
using RestaurantReservation.Db.Repositories.Customer;

namespace RestaurantReservation;

public class Program
{
    static async Task Main(string[] args)
    {
        var databaseOptions = ConfigureApp(args);

        var repo = new OrderItemRepository(new RestaurantReservationDbContext(databaseOptions.ConnectionString));
        var items = await repo.ListOrderedMenuItemsForReservation(1);
        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }

        // Calling the DB Function
        var revenue = await (new RestaurantReservationDbContext(databaseOptions.ConnectionString)).Order
            .Where(o => o.Reservation.RestaurantId == 1)
            .Select(o => RestaurantReservationDbContext.RestaurantRevenue(1))
            .FirstOrDefaultAsync();
        Console.WriteLine(revenue);

        var customerRepo = new CustomerRepository(new RestaurantReservationDbContext(databaseOptions.ConnectionString));
        var customers = await customerRepo.GetCustomersHaveReservationWithPartySizeGreaterThan(1);
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.FirstName);
        }
    }

    private static DatabaseOptions ConfigureApp (string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Configuration.Sources.Clear();

        // Load configuration file
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();
        services.LodConfiguration(builder);

        // Build the service provider
        using var serviceProvider = services.BuildServiceProvider();

        // Create a scope and resolve the configured options
        using var scope = serviceProvider.CreateScope();
        var databaseOptions = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

        return databaseOptions;
    }
}