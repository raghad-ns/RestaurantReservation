using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

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

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<MenuItem> MenuItem { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<Table> Table { get; set; }
    public DbSet<EmployeeRestaurantDetails> EmployeeRestaurantDetails { get; set; }

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

        modelBuilder.Entity<EmployeeRestaurantDetails>(entity =>
        {
            entity.ToView("EmployeeRestaurantDetails");
            entity.HasNoKey();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasMany(e => e.Orders)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.MenuItem)
                .HasForeignKey(e => e.MenuItemId)
                .IsRequired();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .IsRequired();
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity
                .HasMany(e => e.Orders)
                .WithOne(e => e.Reservation)
                .HasForeignKey(e => e.ReservationId)
                .IsRequired();
        });

        modelBuilder.Entity<Restaurant>(entity =>
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

        modelBuilder.Entity<Table>(entity =>
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