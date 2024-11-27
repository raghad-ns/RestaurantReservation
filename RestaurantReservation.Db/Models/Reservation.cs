using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Reservation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public int CustomerId { get; set; } // Foreign key
    public Customer Customer { get; set; } // Navigation property
    public int TableId { get; set; } // Foreign key
    public Table Table { get; set; } // Navigation property

    public int RestaurantId { get; set; } // Foreign key
    public Restaurant Restaurant { get; set; } // Navigation property
    public int? PartySize { get; set; }
    public ICollection<Order> Orders { get; set; }
}