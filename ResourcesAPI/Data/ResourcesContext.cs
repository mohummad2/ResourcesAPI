using Microsoft.EntityFrameworkCore;
using ResourcesAPI.Data.Models;

namespace ResourcesAPI.Data
{
    public class ResourcesContext : DbContext
    {
        public ResourcesContext()
        {
        }

        public ResourcesContext(DbContextOptions<ResourcesContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("Worker");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.FirstName).HasColumnName("FirstName");
                entity.Property(e => e.LastName).HasColumnName("LastName");
                entity.Property(e => e.Address1).HasColumnName("Address1");
                entity.Property(e => e.DesignationId).HasColumnName("DesignationId");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
                entity.Property(e => e.DateCreated).HasColumnName("DateCreated");
                entity.Property(e => e.DateModified).HasColumnName("DateModified");

                entity.HasOne(e => e.Designation);
                entity.HasOne(e => e.Compensation);
            });

            modelBuilder.Entity<WageType>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("WageType");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Designation");

                entity.ToTable("Designation");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.WageTypeId).HasColumnName("WageTypeId");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");

                entity.HasOne(e => e.WageType);
            });

            modelBuilder.Entity<Compensation>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("Compensation");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.WorkerId).HasColumnName("WorkerId");
                entity.Property(e => e.Amount).HasColumnName("Amount");
                entity.Property(e => e.MaxExpenseAllowed).HasColumnName("MaxExpenseAllowed");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
