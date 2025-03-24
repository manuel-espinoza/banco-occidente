using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.DataAccess.Models
{
    public class EstadoCuentaCompras
    {
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; } = null!;
        [Column("monto")]
        public decimal Monto { get; set; }
    }
}
