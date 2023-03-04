using Microsoft.EntityFrameworkCore;
using NinjaDomain.Data.Models;

namespace NinjaDomain.Data.Data
{
    public class NinjaDbContext : DbContext
    {
        public NinjaDbContext(DbContextOptions<NinjaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ninja>(entity => 
            {
               entity.HasOne(c => c.Clan) 
                    .WithMany(n => n.Ninjas!)
                    .HasForeignKey(nc => nc.ClanId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ninja_Clan");

                entity.HasMany(ne => ne.EquipmentOwned!)
                    .WithOne(n => n.Ninja)
                    .HasForeignKey(en => en.NinjaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EquipmentOwned_Ninja");
            });
        }

        public virtual DbSet<Ninja>? NinjasTbl { get; set; }
        public virtual DbSet<Clan>? ClansTbl { get; set; }
        public virtual DbSet<NinjaEquipment>? NinjaEquipmentTbl { get; set; }
    }
}
