using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBTest.Conext
{
    public partial class DbTestDatabaseContext : DbContext
    {
        public DbTestDatabaseContext()
        {
        }

        public DbTestDatabaseContext(DbContextOptions<DbTestDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=D:\\CODE\\TestingForPettime\\DBTest\\bin\\Debug\\net6.0\\DbTestDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Customers_Id")
                    .IsUnique();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
