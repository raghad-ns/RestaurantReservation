using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Order.Models;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Reservation.Models.Reservation Reservation { get; set; } // Navigation property
    public int ReservationId { get; set; } // Foreign key
    public Employee.Models.Employee Employee { get; set; } // Navigation property
    public int EmployeeId { get; set; } // Foreign key
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
    public ICollection<OrderItem.Models.OrderItem> OrderItems { get; set; }
}