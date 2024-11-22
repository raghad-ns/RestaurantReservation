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
        _db.MenuItem.AddAsync(menuItem);
        _db.SaveChangesAsync();
        return menuItem.Id;
    }

    public async Task DeleteMenuItem(Db.Models.MenuItem menuItem)
    {
        _db.MenuItem.Remove(menuItem);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.MenuItem> UpdateMenuItem(int menuItemId,Db.Models.MenuItem newMenuItem)
    {
        var MenuItem = await _db.MenuItem.FindAsync(menuItemId);
        MenuItem = newMenuItem;
        _db.SaveChangesAsync();
        return MenuItem;
    }
}