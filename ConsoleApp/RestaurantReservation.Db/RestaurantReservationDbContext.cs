using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    private readonly string _connectionString;

    public RestaurantReservationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    //public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options)
    //    : base(options)
    //{
    //}

    public DbSet<Customer.Models.Customer> Customer { get; set; }
    public DbSet<Employee.Models.Employee> Employee { get; set; }
    public DbSet<MenuItem.Models.MenuItem> MenuItem { get; set; }
    public DbSet<Order.Models.Order> Order { get; set; }
    public DbSet<OrderItem.Models.OrderItem> OrderItem { get; set; }
    public DbSet<Reservation.Models.Reservation> Reservation { get; set; }
    public DbSet<Restaurant.Models.Restaurant> Restaurant { get; set; }
    public DbSet<Table.Models.Table> Table { get; set; }
    public DbSet<EmployeeRestaurantDetails.Models.EmployeeRestaurantDetails> EmployeeRestaurantDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDbFunction(
            typeof(RestaurantReservationDbContext)
            .GetMethod(nameof(RestaurantRevenue), new[] { typeof(int) })
            )
        .HasName("RestaurantRevenue")
        .HasSchema("dbo");

        modelBuilder.Entity<EmployeeRestaurantDetails.Models.EmployeeRestaurantDetails>(entity =>
        {
            entity.ToView("EmployeeRestaurantDetails");
            entity.HasNoKey();
        });

        modelBuilder.Entity<Customer.Models.Customer>(entity =>
        {
            entity
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);
        });

        modelBuilder.Entity<Employee.Models.Employee>(entity =>
        {
            entity
                .HasMany(e => e.Orders)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();
        });

        modelBuilder.Entity<MenuItem.Models.MenuItem>(entity =>
        {
            entity
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.MenuItem)
                .HasForeignKey(e => e.MenuItemId)
                .IsRequired();
        });

        modelBuilder.Entity<Order.Models.Order>(entity =>
        {
            entity
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .IsRequired();
        });

        modelBuilder.Entity<Reservation.Models.Reservation>(entity =>
        {
            entity
                .HasMany(e => e.Orders)
                .WithOne(e => e.Reservation)
                .HasForeignKey(e => e.ReservationId)
                .IsRequired();
        });

        modelBuilder.Entity<Restaurant.Models.Restaurant>(entity =>
        {
            entity
                .HasMany(e => e.Tables)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .IsRequired();

            entity
                .HasMany(e => e.Employees)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .IsRequired();

            entity
                .HasMany(e => e.MenuItems)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .IsRequired();
        });

        modelBuilder.Entity<Table.Models.Table>(entity =>
        {
            entity
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Table)
                .HasForeignKey(e => e.TableId)
                .IsRequired();
        });
    }

    public static double RestaurantRevenue(int restaurantId) => throw new System.NotImplementedException();
}