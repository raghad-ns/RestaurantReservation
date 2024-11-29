using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantReservation.Db;

public class RestaurantReservationContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        //var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        //optionsBuilder.UseSqlServer(args[0]);

        return new RestaurantReservationDbContext(args[0]);
    }
}