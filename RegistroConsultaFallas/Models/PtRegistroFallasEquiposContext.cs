using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RegistroConsultaFallas.Models;

public partial class PtRegistroFallasEquiposContext : DbContext
{
    public PtRegistroFallasEquiposContext()
    {
    }

    public PtRegistroFallasEquiposContext(DbContextOptions<PtRegistroFallasEquiposContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Falla> Fallas { get; set; }

    public virtual DbSet<Propietario> Propietarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipo).HasName("PK__Equipos__D8052408C44A7094");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.NombreEquipo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPropietarioNavigation).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.IdPropietario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipos__IdPropi__3A81B327");
        });

        modelBuilder.Entity<Falla>(entity =>
        {
            entity.HasKey(e => e.IdFalla).HasName("PK__Fallas__43E2C93B2F9E2A30");

            entity.Property(e => e.DescripcionFalla).HasColumnType("text");
            entity.Property(e => e.FechaFalla).HasColumnType("datetime");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Fallas)
                .HasForeignKey(d => d.IdEquipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fallas__IdEquipo__3D5E1FD2");
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.HasKey(e => e.IdPropietario).HasName("PK__Propieta__4D581B50E480819F");

            entity.HasIndex(e => e.Email, "UQ__Propieta__A9D1053442E9C840").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
