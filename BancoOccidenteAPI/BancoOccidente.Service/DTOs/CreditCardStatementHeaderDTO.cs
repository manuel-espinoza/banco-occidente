using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.DTOs
{
    public class CreditCardStatementHeaderDTO
    {
        public string CustomerName { get; set; } = null!;
        public string CreditCard { get; set; } = null!;
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AvailableCredit { get; set; }
        public decimal TotalPuchasesAmount {  get; set; }
        public decimal WaivableInterestAmount {  get; set; }
        public decimal MinimumPaymentAmount {  get; set; }
        public decimal LumpSumPaymentAmount { get; set; }
    }
}
