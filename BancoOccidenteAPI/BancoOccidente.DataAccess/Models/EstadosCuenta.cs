using System;
using System.Collections.Generic;

namespace BancoOccidente.DataAccess.Models
{
    public partial class EstadosCuenta
    {
        public int Id { get; set; }
        public int TarjetaCreditoId { get; set; }
        public DateTime FechaCorte { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal TotalCargos { get; set; }
        public decimal TotalAbonos { get; set; }
        public decimal Saldo { get; set; }
        public decimal CuotaMinima { get; set; }
        public decimal PagoContado { get; set; }
        public decimal InteresBonificable { get; set; }

        public virtual TarjetasCredito TarjetaCredito { get; set; } = null!;
    }
}
