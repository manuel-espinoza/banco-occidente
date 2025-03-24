using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.DTOs
{
    public class TransactionDTO
    {
        public int? TransactionId { get; set; }
        public int? CreditCardId { get; set; }
        public string? CreditCardNumber { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = null!;
    }
}
