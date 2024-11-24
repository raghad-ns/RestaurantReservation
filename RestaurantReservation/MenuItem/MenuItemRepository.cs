using RestaurantReservation.Db;

namespace RestaurantReservation.MenuItem;

public class MenuItemRepository
{
    private readonly RestaurantReservationDbContext _db;

    public MenuItemRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddMenuItem(Db.Models.MenuItem menuItem)
    {
        _db.MenuItem.Add(menuItem);
        await _db.SaveChangesAsync();
        return menuItem.Id;
    }

    public async Task DeleteMenuItem(Db.Models.MenuItem menuItem)
    {
        _db.MenuItem.Remove(menuItem);
        await _db.SaveChangesAsync();
    }

    public async Task<Db.Models.MenuItem> UpdateMenuItem(Db.Models.MenuItem newMenuItem)
    {
        _db.MenuItem.Update(newMenuItem);
        await _db.SaveChangesAsync();
        return newMenuItem;
    }
}