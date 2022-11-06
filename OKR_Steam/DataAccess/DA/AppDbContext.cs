using Microsoft.EntityFrameworkCore;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.DBModels.Tables;

namespace OKR_Steam.DataAccess.DA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<SteamProfileDatabaseModel> SteamProfile { get; set; }

        public DbSet<InventoryDatabaseModel> Inventory { get; set; }

        public DbSet<ItemDatabaseModel> Item { get; set; }
    }
}
