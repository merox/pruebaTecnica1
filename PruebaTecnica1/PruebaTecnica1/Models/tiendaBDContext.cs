using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaTecnica1.Models.DTO;

namespace PruebaTecnica1.Models
{
    public partial class tiendaBDContext : DbContext
    {
        public tiendaBDContext()
        {
        }

        public tiendaBDContext(DbContextOptions<tiendaBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Fechacreado).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fechacreado).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallesPedido>(entity =>
            {
                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Valortotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.Idpedido)
                    .HasConstraintName("FK_DetallesPedidos_Pedidos");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallesPedidos_Productos");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_Clientes");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Fechaactuailizacion).HasColumnType("date");

                entity.Property(e => e.Fechacreacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precioventa).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_Categorias");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<PruebaTecnica1.Models.DTO.ProductosXPedidoDTO>? ProductosDTO { get; set; }

        public DbSet<PruebaTecnica1.Models.DTO.ProductosDTO>? ProductosDTO_1 { get; set; }
    }
}
