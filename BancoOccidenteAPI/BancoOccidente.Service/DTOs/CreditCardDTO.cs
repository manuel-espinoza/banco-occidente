using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.DTOs
{
    public class CreditCardDTO
    {
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public string Cvc { get; set; } = null!;
        public decimal CreditLimit { get; set; }
        public string Status { get; set; } = null!;
    }
}
