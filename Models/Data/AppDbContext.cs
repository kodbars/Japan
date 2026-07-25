using Microsoft.EntityFrameworkCore;
using Models_DB_and_Request.DB;

namespace Models_DB_and_Request.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CityMenu> CityMenus { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityMenu>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .UseIdentityColumn();

                entity.HasIndex(e => new { e.City, e.OrganizationId, e.ExternalMenuId, e.CacheDayExternalMenu })
                      .HasDatabaseName("IX_CityMenus_Lookup");

                entity.Property(e => e.City)
                      .HasColumnType("NVARCHAR(40)")
                      .HasMaxLength(40)
                      .IsRequired();

                entity.Property(e => e.ExternalMenu)
                      .HasColumnType("NVARCHAR(MAX)")
                      .IsRequired();

                entity.Property(e => e.CacheDayExternalMenu)
                      .HasColumnType("DATETIME2(7)")
                      .IsRequired();
            });
        }
    }
}