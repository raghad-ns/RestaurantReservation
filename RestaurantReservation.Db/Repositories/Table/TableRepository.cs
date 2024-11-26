using RestaurantReservation.Db;

namespace RestaurantReservation.Db.Repositories.Table;

public class TableRepository
{
    private readonly RestaurantReservationDbContext _db;

    public TableRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddTable(Models.Table table)
    {
        _db.Table.Add(table);
        await _db.SaveChangesAsync();
        return table.Id;
    }

    public async Task DeleteTable(Models.Table table)
    {
        _db.Table.Remove(table);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.Table> UpdateTable(Models.Table newTable)
    {
        _db.Table.Update(newTable);
        await _db.SaveChangesAsync();
        return newTable;
    }
}