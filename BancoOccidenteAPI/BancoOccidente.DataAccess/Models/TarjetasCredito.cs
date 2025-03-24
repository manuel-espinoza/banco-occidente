using System;
using System.Collections.Generic;

namespace BancoOccidente.DataAccess.Models
{
    public partial class TarjetasCredito
    {
        public TarjetasCredito()
        {
            EstadosCuenta = new HashSet<EstadosCuenta>();
            Movimientos = new HashSet<Movimiento>();
        }
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string NumeroTarjeta { get; set; } = null!;
        public DateTime FechaExpiracion { get; set; }
        public string Cvv { get; set; } = null!;
        public decimal LimiteCredito { get; set; }
        public decimal? SaldoUtilizado { get; set; }
        public decimal? SaldoMinimoPct { get; set; }
        public decimal? InteresBonificablePct { get; set; }
        public string? Estado { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual ICollection<EstadosCuenta> EstadosCuenta { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
