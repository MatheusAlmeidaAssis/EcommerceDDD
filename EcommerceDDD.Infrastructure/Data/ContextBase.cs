using EcommerceDDD.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EcommerceDDD.Infrastructure.Data
{
    public class ContextBase : IdentityDbContext<IdentityUser>
    {
        public ContextBase(DbContextOptions<ContextBase> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Compra> Compras { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity == typeof(IdentityUser))
                    continue;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                        entry.Property("DataAlteracao").IsModified = false;
                        entry.Property("DataExclusao").IsModified = false;
                        break;

                    case EntityState.Modified:
                        if (entry.Property("DataExclusao").CurrentValue == null)
                            entry.Property("DataAlteracao").CurrentValue = DateTime.Now;

                        entry.Property("DataCriacao").IsModified = false;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
                .ToTable("dbo.AspNetUsers").HasKey(t => t.Id);
            var entities = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in entities)
            {
                var properties = entity.GetProperties();
                foreach (var property in properties)
                {
                    if (property.ClrType == typeof(string))
                        property.SetColumnType("varchar(100)");
                    else if (property.ClrType == typeof(decimal))
                        property.SetColumnType("decimal(12,2)");
                    else if (entity.ClrType == typeof(DateTime))
                        property.SetColumnType("datetime2(7)");
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}