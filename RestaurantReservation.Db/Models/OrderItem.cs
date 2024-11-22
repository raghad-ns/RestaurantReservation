using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class OrderItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public MenuItem Item { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}