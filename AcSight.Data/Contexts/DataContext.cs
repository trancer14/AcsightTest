using AcSight.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {

                entity.Property(e => e.UserName).HasMaxLength(20).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            });
            modelBuilder.Entity<Customer>(entity =>
            {

                entity.Property(e => e.Name).HasMaxLength(20).IsRequired();

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(12);
                
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");



            });
        }
    }
}
