using BancoOccidente.DataAccess.DataBase;
using BancoOccidente.DataAccess.IRepositories;
using BancoOccidente.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.DataAccess.Repositories
{
    public class CreditCardStatementRepository : ICreditCardStatementRepository
    {
        private readonly BancoOccidenteContext _context;

        public CreditCardStatementRepository(BancoOccidenteContext context)
        {
            _context = context;
        }

        public async Task<EstadoCuentaCabecera?> GetCreditCardStatementHeaderByCustomer(int customerId)
        {
            var result = await _context.EstadoCuentaCabecera.FromSqlRaw($"EXEC EstadoCuentaCabeceraCliente @id_cliente = {customerId}").ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<List<EstadoCuentaCompras>> GetCreditCardStatementPurchasesByCustomer(int month, int customerId)
        {
            var result = await _context.EstadoCuentaCompras.FromSqlRaw($"EXEC EstadoCuentaComprasMesCliente @mes = {month}, @id_cliente = {customerId}").ToListAsync();
            return result;
        }
    }
}
