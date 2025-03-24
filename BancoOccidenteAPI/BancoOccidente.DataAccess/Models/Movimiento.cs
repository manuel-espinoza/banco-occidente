using System;
using System.Collections.Generic;

namespace BancoOccidente.DataAccess.Models
{
    public partial class Movimiento
    {
        public int Id { get; set; }
        public int TarjetaCreditoId { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public string TipoMovimiento { get; set; } = null!;

        public virtual TarjetasCredito TarjetaCredito { get; set; } = null!;
    }
}
