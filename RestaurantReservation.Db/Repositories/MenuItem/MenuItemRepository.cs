namespace RestaurantReservation.Db.Repositories.MenuItem;

public class MenuItemRepository: IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _db;

    public MenuItemRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddMenuItem(Models.MenuItem menuItem)
    {
        _db.MenuItem.Add(menuItem);
        await _db.SaveChangesAsync();
        return menuItem.Id;
    }

    public async Task DeleteMenuItem(Models.MenuItem menuItem)
    {
        _db.MenuItem.Remove(menuItem);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.MenuItem> UpdateMenuItem(Models.MenuItem newMenuItem)
    {
        _db.MenuItem.Update(newMenuItem);
        await _db.SaveChangesAsync();
        return newMenuItem;
    }
}