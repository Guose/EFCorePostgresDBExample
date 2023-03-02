using Microsoft.EntityFrameworkCore;
using NinjaDomain.Data.Models;

namespace NinjaDomain.Data.Data
{
    public class NinjaDbContext : DbContext
    {
        public NinjaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Ninja>? NinjasTbl { get; set; }
        public DbSet<Clan>? ClansTbl { get; set; }
        public DbSet<NinjaEquipment>? NinjaEquipmentTbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Ninja>()
                .HasMany(e => e.EquipmentOwned)
                .WithOne(n => n.Ninja!)
                .HasForeignKey(e => e.NinjaId);

            modelBuilder
                .Entity<NinjaEquipment>()
                .HasOne(n => n.Ninja)
                .WithMany(e => e.EquipmentOwned)
                .HasForeignKey(e => e.NinjaId);

            modelBuilder
                .Entity<Clan>()
                .HasMany(n => n.Ninjas)
                .WithOne(c => c.Clan!)
                .HasForeignKey(c => c.ClanId);
        }
    }
}
