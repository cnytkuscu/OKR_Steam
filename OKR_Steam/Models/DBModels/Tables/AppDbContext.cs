using Microsoft.EntityFrameworkCore;
using OKR_Steam.Models.DBModels;

namespace OKR_Steam.Models.DBModels.Tables
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


    }
}
