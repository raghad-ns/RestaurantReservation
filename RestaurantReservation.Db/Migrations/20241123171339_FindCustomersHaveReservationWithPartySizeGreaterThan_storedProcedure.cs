using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class FindCustomersHaveReservationWithPartySizeGreaterThan_storedProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE FindCustomersHaveReservationWithPartySizeGreaterThan (@partySize INT)
                                    AS 
                                    BEGIN
	                                    SELECT Customer.Id, Customer.FirstName, Customer.LastName, Customer.Email, Customer.PhoneNumber 
	                                    FROM Customer JOIN Reservation ON Customer.Id = Reservation.CustomerId 
	                                    WHERE PartySize > @partySize
                                    END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE FindCustomersHaveReservationWithPartySizeGreaterThan");
        }
    }
}
