using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScalingLamp.Models.DomainModels;

namespace ScalingLamp.Persistence;

public partial class ScalingLampContext : DbContext
{
    public ScalingLampContext()
    {
    }

    public ScalingLampContext(DbContextOptions<ScalingLampContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Variable> Variables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=ScalingLamp;Encrypt=False;Password=P@ssword1234;User Id=sa");

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
