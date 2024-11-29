using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.OrderItem.Models;

public class OrderItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Order.Models.Order Order { get; set; }
    public int OrderId { get; set; }
    public MenuItem.Models.MenuItem MenuItem { get; set; } // Navigation property
    public int MenuItemId { get; set; } // Foreign key
    public int Quantity { get; set; }
}