using BancoOccidente.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.IServices
{
    public interface ITransactionsReadService
    {
        Task<List<TransactionDTO>> GetTransactionsByCreditCardAndMonth(int creditCardId, int month);
    }
}
