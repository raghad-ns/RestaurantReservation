namespace RestaurantReservation.Db.Models;

public class Employee
{
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
}