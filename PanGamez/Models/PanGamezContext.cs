using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PanGamez.Models
{
    public partial class PanGamezContext : DbContext
    {
        public PanGamezContext()
        {
        }

        public PanGamezContext(DbContextOptions<PanGamezContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cpfijo> Cpfijos { get; set; } = null!;
        public virtual DbSet<Cpstock> Cpstocks { get; set; } = null!;
        public virtual DbSet<Eoq> Eoqs { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Ltc> Ltcs { get; set; } = null!;
        public virtual DbSet<Luc> Lucs { get; set; } = null!;
        public virtual DbSet<MantenimientoCorrectivo> MantenimientoCorrectivos { get; set; } = null!;
        public virtual DbSet<Maquina> Maquinas { get; set; } = null!;
        public virtual DbSet<Materiale> Materiales { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PanaderiaGamez.mssql.somee.com\n;Database=PanaderiaGamez;User Id=Rcairo09_SQLLogin_1;Password=42lbn2kydy;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK_IDCategoria");

                entity.ToTable("Categoria", "PuestoVenta");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cpfijo>(entity =>
            {
                entity.HasKey(e => e.Idcpfijo)
                    .HasName("PK_IDCPFijo");

                entity.ToTable("CPFijo");

                entity.Property(e => e.Idcpfijo).HasColumnName("IDCPFijo");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Cpfijos)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPFijo_IDProducto");
            });

            modelBuilder.Entity<Cpstock>(entity =>
            {
                entity.HasKey(e => e.Idcpstock)
                    .HasName("PK_IDCPStock");

                entity.ToTable("CPStock");

                entity.Property(e => e.Idcpstock).HasColumnName("IDCPStock");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Cpstocks)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPStock_IDProducto");
            });

            modelBuilder.Entity<Eoq>(entity =>
            {
                entity.HasKey(e => e.Ideoq)
                    .HasName("PK_IDEOQ");

                entity.ToTable("EOQ");

                entity.Property(e => e.Ideoq).HasColumnName("IDEOQ");

                entity.Property(e => e.CostoMantenimiento).HasColumnType("money");

                entity.Property(e => e.CostoPedido).HasColumnType("money");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Eoqs)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EOQProducto_IDProducto");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Idinventario)
                    .HasName("PK_IDInventario");

                entity.ToTable("Inventario");

                entity.Property(e => e.Idinventario).HasColumnName("IDInventario");

                entity.Property(e => e.Idmateriales).HasColumnName("IDMateriales");

                entity.HasOne(d => d.IdmaterialesNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Idmateriales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invetario_IDMateriales");
            });

            modelBuilder.Entity<Ltc>(entity =>
            {
                entity.HasKey(e => e.Idltc)
                    .HasName("PK_IDLTC");

                entity.ToTable("LTC");

                entity.Property(e => e.Idltc).HasColumnName("IDLTC");

                entity.Property(e => e.CostoMantenimiento).HasColumnType("money");

                entity.Property(e => e.CostoMantenimientoAcumulado).HasColumnType("money");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Ltcs)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LTC_IDProducto");
            });

            modelBuilder.Entity<Luc>(entity =>
            {
                entity.HasKey(e => e.Idluc)
                    .HasName("PK_IDLUC");

                entity.ToTable("LUC");

                entity.Property(e => e.Idluc).HasColumnName("IDLUC");

                entity.Property(e => e.CostoDeOrdenar).HasColumnType("money");

                entity.Property(e => e.CostoMantenimiento).HasColumnType("money");

                entity.Property(e => e.CostoTotal).HasColumnType("money");

                entity.Property(e => e.CostoTotalU).HasColumnType("money");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Lucs)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LUC_IDProducto");
            });

            modelBuilder.Entity<MantenimientoCorrectivo>(entity =>
            {
                entity.HasKey(e => e.Idmantenimiento)
                    .HasName("PK_IDMantenimiento");

                entity.ToTable("MantenimientoCorrectivo");

                entity.Property(e => e.Idmantenimiento).HasColumnName("IDMantenimiento");

                entity.Property(e => e.CostoFallaUnica).HasColumnType("money");

                entity.Property(e => e.CostoHoraTrabajo).HasColumnType("money");

                entity.Property(e => e.CostoUnitario).HasColumnType("money");

                entity.Property(e => e.Idequipo).HasColumnName("IDEquipo");

                entity.Property(e => e.Repuestos).HasColumnType("money");

                entity.Property(e => e.TareasAdicionales).HasColumnType("money");

                entity.HasOne(d => d.IdequipoNavigation)
                    .WithMany(p => p.MantenimientoCorrectivos)
                    .HasForeignKey(d => d.Idequipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDEquipo_Maquinas");
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.HasKey(e => e.Idequipo)
                    .HasName("PK_IDEquipo");

                entity.ToTable("Maquinas", "PuestoVenta");

                entity.Property(e => e.Idequipo).HasColumnName("IDEquipo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materiale>(entity =>
            {
                entity.HasKey(e => e.Idmateriales)
                    .HasName("PK_IDMateriales");

                entity.Property(e => e.Idmateriales).HasColumnName("IDMateriales");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Materiales)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materiales_IDProducto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK_IDProducto");

                entity.ToTable("Productos", "PuestoVenta");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDCategoria_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
