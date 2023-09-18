﻿using Microsoft.EntityFrameworkCore;
using ScalingLamp.Domain.Models.DomainModels;

namespace ScalingLamp.Infrastructure.Persistence;

public partial class ScalingLampContext : DbContext
{
    public ScalingLampContext(DbContextOptions<ScalingLampContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Variable> Variables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.CityName).HasMaxLength(255);
        });

        modelBuilder.Entity<Variable>(entity =>
        {
            entity.ToTable("Variable");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Unit).HasMaxLength(255);
            entity.Property(e => e.Value).HasMaxLength(255);

            entity.HasOne(d => d.City).WithMany(p => p.Variables)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Variable_City");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
