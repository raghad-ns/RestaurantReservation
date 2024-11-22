using RestaurantReservation.Db;

namespace RestaurantReservation.Table;

public class TableRepository
{
    private readonly RestaurantReservationDbContext _db;

    public TableRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddTable(Db.Models.Table table)
    {
        _db.Table.AddAsync(table);
        _db.SaveChangesAsync();
        return table.Id;
    }

    public async Task DeleteTable(Db.Models.Table table)
    {
        _db.Table.Remove(table);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Table> UpdateTable(int tableId,Db.Models.Table newTable)
    {
        var Table = await _db.Table.FindAsync(tableId);
        Table = newTable;
        _db.SaveChangesAsync();
        return Table;
    }
}