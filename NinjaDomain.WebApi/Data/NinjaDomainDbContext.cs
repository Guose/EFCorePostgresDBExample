using Microsoft.EntityFrameworkCore;
using NinjaDomain.WebApi.Models;

namespace NinjaDomain.WebApi.Data
{
    public class NinjaDomainDbContext : DbContext
    {
        public NinjaDomainDbContext(DbContextOptions<NinjaDomainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NinjaModel>(entity => 
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

        public virtual DbSet<NinjaModel>? NinjasTbl { get; set; }
        public virtual DbSet<ClanModel>? ClansTbl { get; set; }
        public virtual DbSet<NinjaEquipmentModel>? NinjaEquipmentTbl { get; set; }
    }
}