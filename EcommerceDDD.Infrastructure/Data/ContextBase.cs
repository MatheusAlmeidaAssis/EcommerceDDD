using EcommerceDDD.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcommerceDDD.Infrastructure.Data
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            System.Collections.Generic.IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> entrys = ChangeTracker.Entries();
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in entrys)
            {
                if (entry.Property("DataCadastro") == null && entry.Property("DataAlteracao") == null && entry.Property("DataExclusao") == null)
                {
                    continue;
                }

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                        entry.Property("DataAlteracao").IsModified = false;
                        entry.Property("DataExclusao").IsModified = false;
                        break;

                    case EntityState.Modified:
                        if (entry.Property("DataExclusao").CurrentValue == null)
                        {
                            entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                        }

                        entry.Property("DataCadastro").IsModified = false;
                        break;
                }
            }
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            System.Collections.Generic.IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableProperty> properties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties());
            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableProperty property in properties)
            {
                if (property.ClrType == typeof(string))
                {
                    property.SetColumnType("varchar(100)");
                }
                else if (property.ClrType == typeof(decimal))
                {
                    property.SetColumnType("decimal(12,2)");
                }
                else if (property.ClrType == typeof(DateTime))
                {
                    property.SetColumnType("datetime2(7)");
                }

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}