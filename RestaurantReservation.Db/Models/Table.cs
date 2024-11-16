namespace RestaurantReservation.Db.Models;

public class Table
{
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public int Capacity { get; set; }
}