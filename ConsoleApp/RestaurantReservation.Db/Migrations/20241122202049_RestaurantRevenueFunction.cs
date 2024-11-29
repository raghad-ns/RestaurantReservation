using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION dbo.RestaurantRevenue(@restaurantId INT)
            RETURNS FLOAT
            AS
            BEGIN
                DECLARE @revenue FLOAT;

                SELECT @revenue = SUM(o.TotalAmount)
                FROM dbo.[Order] o
                JOIN dbo.Reservation r
                    ON o.ReservationId = r.Id
                WHERE r.RestaurantId = @restaurantId;

                RETURN @revenue;
            END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.RestaurantRevenue");
        }
    }
}
