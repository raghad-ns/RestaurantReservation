using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Reservation.Models;

public class Reservation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public int CustomerId { get; set; } // Foreign key
    public Customer.Models.Customer Customer { get; set; } // Navigation property
    public int TableId { get; set; } // Foreign key
    public Table.Models.Table Table { get; set; } // Navigation property

    public int RestaurantId { get; set; } // Foreign key
    public Restaurant.Models.Restaurant Restaurant { get; set; } // Navigation property
    public int? PartySize { get; set; }
    public ICollection<Order.Models.Order> Orders { get; set; }
}