using Microsoft.EntityFrameworkCore;
using NinjaDomain.Data.Models;

namespace NinjaDomain.Data.Data
{
    public class NinjaDbContext : DbContext
    {
        public NinjaDbContext(DbContextOptions<NinjaDbContext> options) : base(options) { }

        public DbSet<Ninja>? NinjasTbl { get; set; }
        public DbSet<Clan>? ClansTbl { get; set; }
        public DbSet<NinjaEquipment>? NinjaEquipmentTbl { get; set; }
    }
}
