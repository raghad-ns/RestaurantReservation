using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Table.Models;

public class Table
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Restaurant.Models.Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public int Capacity { get; set; }
    public ICollection<Reservation.Models.Reservation> Reservations { get; set; }
}