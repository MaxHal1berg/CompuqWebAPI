using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompuqWebAPI.Models
{
    public class CompuqDBContext : DbContext
    {
        public CompuqDBContext(DbContextOptions<CompuqDBContext> options) 
            : base(options) 
        {
        }

        public virtual DbSet<Compuq> Compuqs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compuq>(entity =>
            {
                entity.Property(e => e.customer_id)
                .HasColumnType("int")
                .IsUnicode(false);

                entity.Property(e => e.customer_name)
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.phone_number)
                .HasColumnType("int")
                .IsUnicode(false);

                entity.Property(e => e.phone_make)
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.phone_monthlypay)
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.phone_plan_monthlypay)
                .HasMaxLength(255)
                .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
