﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    private readonly string _connectionString;

    public RestaurantReservationDbContext( string  connString)
    {
        _connectionString = connString;
    }

    public DbSet<Models.Customer> Customer { get; set; }
    public DbSet<Models.Employee> Employee { get; set; }
    public DbSet<Models.MenuItem> MenuItem { get; set; }
    public DbSet<Models.Order> Order { get; set; }
    public DbSet<Models.OrderItem> OrderItem { get; set; }
    public DbSet<Models.Reservation> Reservation { get; set; }
    public DbSet<Models.Restaurant> Restaurant { get; set; }
    public DbSet<Models.Table> Table { get; set; }
    public DbSet<Models.EmployeeRestaurantDetails> EmployeeRestaurantDetails { get; set; }

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
    }

    public static double RestaurantRevenue(int restaurantId) => throw new System.NotImplementedException();
}