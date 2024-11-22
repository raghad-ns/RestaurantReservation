using RestaurantReservation.Db;

namespace RestaurantReservation.Restaurant;

public class RestaurantRepository
{
    private readonly RestaurantReservationDbContext _db;

    public RestaurantRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddRestaurant(Db.Models.Restaurant restaurant)
    {
        _db.Restaurant.AddAsync(restaurant);
        _db.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task DeleteRestaurant(Db.Models.Restaurant restaurant)
    {
        _db.Restaurant.Remove(restaurant);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Restaurant> UpdateRestaurant(int restaurantId,Db.Models.Restaurant newRestaurant)
    {
        var Restaurant = await _db.Restaurant.FindAsync(restaurantId);
        Restaurant = newRestaurant;
        _db.SaveChangesAsync();
        return Restaurant;
    }
}