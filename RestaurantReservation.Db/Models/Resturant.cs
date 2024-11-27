﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public int OpeningHours { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Table> Tables { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; }
}