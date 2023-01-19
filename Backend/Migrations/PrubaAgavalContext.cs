using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Migrations;

public partial class PrubaAgavalContext : DbContext
{
    public PrubaAgavalContext()
    {
    }

    public PrubaAgavalContext(DbContextOptions<PrubaAgavalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GAU7660\\SQLEXPRESS;Database=PrubaAgaval;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__3214EC071E50F70F");

            entity.ToTable("clientes");

            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__compras__3214EC07F0F8ED6F");

            entity.ToTable("compras");

            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("fechaCompra");
            entity.Property(e => e.MedioPago)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("medioPago");
            entity.Property(e => e.OrdenCompra)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ordenCompra");
            entity.Property(e => e.ValorCompra).HasColumnName("valorCompra");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__inventar__3214EC07D1FCCCEE");

            entity.ToTable("inventario");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item__3214EC0728E08A99");

            entity.ToTable("Item");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Items)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Item__ClienteId__5AB9788F");

            entity.HasOne(d => d.Compra).WithMany(p => p.Items)
                .HasForeignKey(d => d.CompraId)
                .HasConstraintName("FK__Item__ClienteId__59C55456");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3214EC0773899667");

            entity.ToTable("usuarios");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Salt)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("salt");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
