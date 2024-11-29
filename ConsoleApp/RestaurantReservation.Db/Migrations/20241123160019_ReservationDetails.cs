using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" CREATE VIEW ReservationDetails
                                    AS
                                    SELECT 
                                        Reservation.Id, 
                                        CustomerId, 
                                        RestaurantId, 
                                        TableId, 
                                        PartySize, 
                                        Customer.FirstName AS CustomerFirstName, 
                                        Customer.LastName AS CustomerLastName,
                                        Customer.Email AS CustomerEmail,
                                        Customer.PhoneNumber AS CustomerPhoneNumber,
                                        Restaurant.Name AS RestaurantName,
                                        Restaurant.Address AS RestaurantAddress, 
                                        Restaurant.PhoneNumber AS RestaurantPhoneNumber,
                                        OpeningHours AS RestaurantOpeningHours 
                                    FROM 
                                        dbo.Customer 
                                    JOIN 
                                        dbo.Reservation ON dbo.Customer.Id = dbo.Reservation.CustomerId
                                    JOIN 
                                        dbo.Restaurant ON dbo.Reservation.RestaurantId = dbo.Restaurant.Id;

                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservationDetails");
        }
    }
}
