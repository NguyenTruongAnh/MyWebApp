using Microsoft.EntityFrameworkCore;
using MyAppService.Domain.Common;
using MyAppService.Domain.Entities;
using System.Reflection;

namespace MyAppService.Infrastructure.Data
{
    public  class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.CreatedDate))
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
