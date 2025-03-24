using System;
using System.Collections.Generic;

namespace BancoOccidente.DataAccess.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            TarjetasCreditos = new HashSet<TarjetasCredito>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<TarjetasCredito> TarjetasCreditos { get; set; }
    }
}
