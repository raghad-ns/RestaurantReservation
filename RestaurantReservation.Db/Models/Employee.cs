using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity columns
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public ICollection<Order> Orders { get; set; }
}