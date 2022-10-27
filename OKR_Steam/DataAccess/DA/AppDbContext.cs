using Microsoft.EntityFrameworkCore;
using OKR_Steam.Models.DBModels;

namespace OKR_Steam.DataAccess.DA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<SteamProfileDatabaseModel> SteamProfile { get; set; }
    }
}
