using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.DataAccess.Models
{
    public class EstadoCuentaCabecera
    {
        [Column("nombre_cliente")]
        public string NombreCliente { get; set; } = null!;
        [Column("numero_tarjeta_credito")]
        public string NumeroTarjetaCredito { get; set; } = null!;
        [Column("limite_credito")]
        public decimal LimiteCredito { get; set; }
        [Column("total_compras")]
        public decimal TotalCompras {  get; set; }
        [Column("total_abonos")]
        public decimal TotalAbonos { get; set; }
        [Column("porcentaje_saldo_minimo")]
        public decimal PorcentajeSaldoMinimo {  get; set; }
        [Column("porcentaje_interes_bonificable")]
        public decimal PorcentajeInteresBonificable {  get; set; }
    }
}
