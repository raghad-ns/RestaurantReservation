namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantID { get; set; } // Foreign key
    public string Name { get; set; }
    public string Description { get; set; }
    public double price { get; set; }
}