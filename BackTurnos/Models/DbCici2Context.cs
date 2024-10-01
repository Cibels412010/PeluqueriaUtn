using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiTurnos.Models;

public partial class DbCici2Context : DbContext
{
    public DbCici2Context()
    {
    }

    public DbCici2Context(DbContextOptions<DbCici2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TDetallesTurno> TDetallesTurnos { get; set; }

    public virtual DbSet<TServicio> TServicios { get; set; }

    public virtual DbSet<TTurno> TTurnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E045RR5\\SQLEXPRESS;Initial Catalog=db_cici2;Integrated Security=True;Trust Server Certificate=True\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TDetallesTurno>(entity =>
        {
            entity.HasKey(e => new { e.IdTurno, e.IdServicio });

            entity.ToTable("T_DETALLES_TURNO");

            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("observaciones");
        });

        modelBuilder.Entity<TServicio>(entity =>
        {
            entity.ToTable("T_SERVICIOS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.EnPromocion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("enPromocion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TTurno>(entity =>
        {
            entity.ToTable("T_TURNOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente");
            entity.Property(e => e.Fecha)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("hora");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
