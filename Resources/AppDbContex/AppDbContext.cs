using Microsoft.EntityFrameworkCore;
using Resources.DBModels.Tables;

namespace Resources.AppDbContex
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<SteamProfileDatabaseModel> SteamProfile { get; set; }

        public DbSet<InventoryDatabaseModel> Inventory { get; set; }

        public DbSet<ItemDatabaseModel> Item { get; set; }
        public DbSet<ErrorLogDatabaseModel> ErrorLog { get; set; }

        public DbSet<ServiceLogDatabaseModel> ServiceLog { get; set; }


    }
}
