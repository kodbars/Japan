using Microsoft.EntityFrameworkCore;
using Models_DB_and_Request.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CityMenu> CityMenus { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityMenu>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => new { e.City, e.OrganizationId, e.ExternalMenuId }).IsUnique().HasDatabaseName("IX_CityMenus_Unique");

                entity.Property(e => e.City).HasColumnType("NVARCHAR(40)").IsRequired().HasMaxLength(40);

                entity.Property(e => e.ExternalMenu).HasColumnType("NVARCHAR(MAX)").IsRequired();

                entity.Property(e => e.CacheDayExternalMenu).HasColumnType("DATETIME2(7)").IsRequired();

                entity.HasIndex(e => new { e.City, e.OrganizationId, e.ExternalMenuId, e.CacheDayExternalMenu }).HasDatabaseName("IX_CityMenus_Lookup");
            });
        }
    }
}
