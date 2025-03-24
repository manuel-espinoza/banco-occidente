using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BancoOccidente.DataAccess.Models;

namespace BancoOccidente.DataAccess.DataBase
{
    public partial class BancoOccidenteContext : DbContext
    {
        public BancoOccidenteContext()
        {
        }

        public BancoOccidenteContext(DbContextOptions<BancoOccidenteContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<EstadosCuenta> EstadosCuenta { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;

        public virtual DbSet<TarjetasCredito> TarjetasCreditos { get; set; } = null!;
        public DbSet<EstadoCuentaCabecera> EstadoCuentaCabecera { get; set; } = null!;
        public DbSet<EstadoCuentaCompras> EstadoCuentaCompras { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.HasIndex(e => e.Documento, "UQ__clientes__A25B3E6131955DCA")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__clientes__AB6E6164984E2D93")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("documento");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<EstadosCuenta>(entity =>
            {
                entity.ToTable("estados_cuenta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuotaMinima)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cuota_minima");

                entity.Property(e => e.FechaCorte)
                    .HasColumnType("date")
                    .HasColumnName("fecha_corte");

                entity.Property(e => e.InteresBonificable)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("interes_bonificable");

                entity.Property(e => e.PagoContado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pago_contado");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.SaldoAnterior)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldo_anterior");

                entity.Property(e => e.TarjetaCreditoId).HasColumnName("tarjeta_credito_id");

                entity.Property(e => e.TotalAbonos)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_abonos");

                entity.Property(e => e.TotalCargos)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_cargos");

                entity.HasOne(d => d.TarjetaCredito)
                    .WithMany(p => p.EstadosCuenta)
                    .HasForeignKey(d => d.TarjetaCreditoId)
                    .HasConstraintName("FK__estados_c__tarje__48CFD27E");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("movimientos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("monto");

                entity.Property(e => e.TarjetaCreditoId).HasColumnName("tarjeta_credito_id");

                entity.Property(e => e.TipoMovimiento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipo_movimiento");

                entity.HasOne(d => d.TarjetaCredito)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.TarjetaCreditoId)
                    .HasConstraintName("FK__movimient__tarje__45F365D3");
            });

            modelBuilder.Entity<TarjetasCredito>(entity =>
            {
                entity.ToTable("tarjetas_credito");

                entity.HasIndex(e => e.NumeroTarjeta, "UQ__tmp_ms_x__90FF5A61E11262B7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cvv");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('activa')");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.InteresBonificablePct)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("interes_bonificable_pct");

                entity.Property(e => e.LimiteCredito)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("limite_credito");

                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("numero_tarjeta");

                entity.Property(e => e.SaldoMinimoPct)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("saldo_minimo_pct");

                entity.Property(e => e.SaldoUtilizado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldo_utilizado")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<EstadoCuentaCabecera>().HasNoKey();
            modelBuilder.Entity<EstadoCuentaCompras>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
