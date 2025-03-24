using BancoOccidente.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.DataAccess.IRepositories
{
    public interface ICreditCardStatementRepository
    {
        Task<EstadoCuentaCabecera?> GetCreditCardStatementHeaderByCustomer(int customerId);
        Task<List<EstadoCuentaCompras>> GetCreditCardStatementPurchasesByCustomer(int month, int customerId);

    }
}
