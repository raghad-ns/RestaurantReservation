using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeRestaurantDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" CREATE VIEW EmployeeRestaurantDetails
                                    AS
                                    SELECT 
                                        FirstName,
                                        LastName, 
                                        Position,
                                        Restaurant.Name as RestaurantName, 
                                        Restaurant.Address as RestaurantAddress,
                                        Restaurant.PhoneNumber as RestaurantPhoneNumber
                                    FROM 
                                        dbo.Employee 
                                    JOIN 
                                        dbo.Restaurant ON dbo.Employee.RestaurantId = dbo.Restaurant.Id;

                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EmployeeRestaurantDetails");
        }
    }
}
