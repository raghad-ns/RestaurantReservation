using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}