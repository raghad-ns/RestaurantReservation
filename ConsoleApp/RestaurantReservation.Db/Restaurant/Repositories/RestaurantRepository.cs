namespace RestaurantReservation.Db.Restaurant.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _db;

    public RestaurantRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddRestaurant(Models.Restaurant restaurant)
    {
        _db.Restaurant.Add(restaurant);
        await _db.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task DeleteRestaurant(Models.Restaurant restaurant)
    {
        _db.Restaurant.Remove(restaurant);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.Restaurant> UpdateRestaurant(Models.Restaurant newRestaurant)
    {
        _db.Restaurant.Update(newRestaurant);
        await _db.SaveChangesAsync();
        return newRestaurant;
    }
}