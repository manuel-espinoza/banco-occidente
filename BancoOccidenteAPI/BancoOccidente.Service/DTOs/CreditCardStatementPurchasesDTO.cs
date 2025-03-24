﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.DTOs
{
    public class CreditCardStatementPurchasesDTO
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
