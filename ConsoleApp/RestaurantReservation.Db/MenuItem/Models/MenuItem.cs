using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.MenuItem.Models;

public class MenuItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Restaurant.Models.Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public string Name { get; set; }
    public string? Description { get; set; }
    public double price { get; set; }
    public ICollection<OrderItem.Models.OrderItem> OrderItems { get; set; }
}