using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Seeds;

public static class DBSeedExtentions
{
    public static ModelBuilder SeedRestaurants( this ModelBuilder modelBuilder)
    {
        var restaurants = new Restaurant[]
        {
            new Restaurant{Id = 1, Address = "Palestine", Name = "Restaurant1", OpeningHours = 5, PhoneNumber = "0596325478"},
            new Restaurant{Id = 2, Address = "Palestine", Name = "Restaurant2", OpeningHours = 5, PhoneNumber = "0596325472"},
            new Restaurant{Id = 3, Address = "Palestine", Name = "Restaurant3", OpeningHours = 5, PhoneNumber = "0596325473"},
            new Restaurant{Id = 4, Address = "Palestine", Name = "Restaurant4", OpeningHours = 5, PhoneNumber = "0596325474"},
            new Restaurant{Id = 5, Address = "Palestine", Name = "Restaurant5", OpeningHours = 5, PhoneNumber = "0596325475"}
        };
        modelBuilder.Entity<Restaurant>().Property(restaurant => restaurant.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Restaurant>().HasData(restaurants);
        return modelBuilder;
    }

    public static ModelBuilder SeedCustomers(this ModelBuilder modelBuilder)
    {
        var customers = new Customer[]
        {
            new Customer{Id = 1, FirstName = "Customer1", LastName = "Last1",Email = "customer1@gmail.com"},
            new Customer{Id = 2, FirstName = "Customer2", LastName = "Last2",Email = "customer2@gmail.com"},
            new Customer{Id = 3, FirstName = "Customer3", LastName = "Last3",Email = "customer3@gmail.com"},
            new Customer{Id = 4, FirstName = "Customer4", LastName = "Last4",Email = "customer4@gmail.com"},
            new Customer{Id = 5, FirstName = "Customer5", LastName = "Last5",Email = "customer5@gmail.com"}
        };
        modelBuilder.Entity<Customer>().Property(customer => customer.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Customer>().HasData(customers);
        return modelBuilder;
    }

    public static ModelBuilder SeedEmployees(this ModelBuilder modelBuilder)
    {
        var employees = new Employee[]
        {
            new Employee{Id = 1, FirstName = "Employee1", LastName = "Last6", Position = "cashier", RestaurantId = 1},
            new Employee{Id = 2, FirstName = "Employee2", LastName = "Last7", Position = "cashier", RestaurantId = 2},
            new Employee{Id = 3, FirstName = "Employee3", LastName = "Last8", Position = "cashier", RestaurantId = 3},
            new Employee{Id = 4, FirstName = "Employee4", LastName = "Last9", Position = "cashier", RestaurantId = 4},
            new Employee{Id = 5, FirstName = "Employee5", LastName = "Last10", Position = "cashier", RestaurantId = 5},
        };
        modelBuilder.Entity<Employee>().Property(employee => employee.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Employee>().HasData(employees);
        return modelBuilder;
    }

    public static ModelBuilder SeedMenuItems(this ModelBuilder modelBuilder)
    {
        var menuItems = new MenuItem[]
        {
            new MenuItem{Id = 1, Name = "Item1", Description = "Best item ever1", price = 20, RestaurantID = 1},
            new MenuItem{Id = 2, Name = "Item2", Description = "Best item ever2", price = 10, RestaurantID = 2},
            new MenuItem{Id = 3, Name = "Item3", Description = "Best item ever3", price = 40, RestaurantID = 3},
            new MenuItem{Id = 4, Name = "Item4", Description = "Best item ever4", price = 120, RestaurantID = 4},
            new MenuItem{Id = 5, Name = "Item5", Description = "Best item ever5", price = 50, RestaurantID = 5},
        };
        modelBuilder.Entity<MenuItem>().Property(menuItem => menuItem.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<MenuItem>().HasData(menuItems);
        return modelBuilder;
    }

    public static ModelBuilder SeedTables(this ModelBuilder modelBuilder)
    {
        var tables
            = new Table[]
        {
            new Table{Id = 1, RestaurantId = 1, Capacity = 4},
            new Table{Id = 2, RestaurantId = 2, Capacity = 6},
            new Table{Id = 3, RestaurantId = 3, Capacity = 4},
            new Table{Id = 4, RestaurantId = 4, Capacity = 6},
            new Table{Id = 5, RestaurantId = 5, Capacity = 4},
        };
        modelBuilder.Entity<Table>().Property(table => table.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Table>().HasData(tables);
        return modelBuilder;
    }

    public static ModelBuilder SeedReservations(this ModelBuilder modelBuilder)
    {
        var reservations
            = new Reservation[]
        {
            new Reservation{Id = 1, CustomerId = 1, TableId = 1, RestaurantId = 1},
            new Reservation{Id = 2, CustomerId = 2, TableId = 2, RestaurantId = 2},
            new Reservation{Id = 3, CustomerId = 3, TableId = 3, RestaurantId = 3},
            new Reservation{Id = 4, CustomerId = 4, TableId = 4, RestaurantId = 4},
            new Reservation{Id = 5, CustomerId = 5, TableId = 5, RestaurantId = 5},
        };
        modelBuilder.Entity<Reservation>().Property(reservation => reservation.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Reservation>().HasData(reservations);
        return modelBuilder;
    }

    public static ModelBuilder SeedOrders(this ModelBuilder modelBuilder)
    {
        var orders
            = new Order[]
        {
            new Order{Id = 1, EmployeeId = 1, OrderDate = new DateTime(), ReservationId = 1, TotalAmount = 100},
            new Order{Id = 2, EmployeeId = 2, OrderDate = new DateTime(), ReservationId = 2, TotalAmount = 50},
            new Order{Id = 3, EmployeeId = 3, OrderDate = new DateTime(), ReservationId = 3, TotalAmount = 80},
            new Order{Id = 4, EmployeeId = 4, OrderDate = new DateTime(), ReservationId = 4, TotalAmount = 240},
            new Order{Id = 5, EmployeeId = 5, OrderDate = new DateTime(), ReservationId = 5, TotalAmount = 100},
        };
        modelBuilder.Entity<Order>().Property(order => order.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Order>().HasData(orders);
        return modelBuilder;
    }

    public static ModelBuilder SeedOrderItems(this ModelBuilder modelBuilder)
    {
        var orderItems
            = new OrderItem[]
        {
            new OrderItem{Id = 1, ItemId = 1, OrderId = 1, Quantity = 5},
            new OrderItem{Id = 2, ItemId = 2, OrderId = 2, Quantity = 5},
            new OrderItem{Id = 3, ItemId = 3, OrderId = 3, Quantity = 2},
            new OrderItem{Id = 4, ItemId = 4, OrderId = 4, Quantity = 2},
            new OrderItem{Id = 5, ItemId = 5, OrderId = 5, Quantity = 2},
        };
        modelBuilder.Entity<OrderItem>().Property(orderItem => orderItem.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
        return modelBuilder;
    }
}
