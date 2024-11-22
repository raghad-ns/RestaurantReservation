﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Migrations;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Seeds;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    private readonly string connString = @"Server=DESKTOP-33KIDRJ\SQLEXPRESS;Database=RestaurantReservationCore;Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<MenuItem> MenuItem { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<Table> Table { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDbFunction(
            typeof(RestaurantReservationDbContext)
            .GetMethod(nameof(RestaurantRevenue), new[] { typeof(int) })
            )
        .HasName("RestaurantRevenue")
        .HasSchema("dbo");

        modelBuilder
            .SeedRestaurants()
            .SeedCustomers()
            .SeedEmployees()
            .SeedMenuItems()
            .SeedTables()
            .SeedReservations()
            .SeedOrders()
            .SeedOrderItems();
    }

    public static double RestaurantRevenue(int restaurantId) => throw new System.NotImplementedException();
}