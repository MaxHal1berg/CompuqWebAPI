using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CompuqWebAPI.Models;

public partial class CompuqContext : DbContext
{
    public CompuqContext(DbContextOptions<CompuqContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB852EBEACB6");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.PhoneMake)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone_make");
            entity.Property(e => e.PhoneMonthlypay)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone_monthlypay");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.PhonePlanMonthlypay)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone_plan_monthlypay");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
