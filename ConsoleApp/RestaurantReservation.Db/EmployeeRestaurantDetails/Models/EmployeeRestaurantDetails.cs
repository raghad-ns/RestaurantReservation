namespace RestaurantReservation.Db.EmployeeRestaurantDetails.Models;

public class EmployeeRestaurantDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public string? RestaurantPhoneNumber { get; set; }
}