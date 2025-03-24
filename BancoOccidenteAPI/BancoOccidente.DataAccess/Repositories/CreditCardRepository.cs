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
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly BancoOccidenteContext _context;
        public CreditCardRepository(BancoOccidenteContext context)
        {
            _context = context;
        }
        public async Task<TarjetasCredito?> GetCreditCardByNumber(string creditCardNumber)
        {
            return await _context.TarjetasCreditos.Where(x => x.NumeroTarjeta == creditCardNumber).FirstOrDefaultAsync();
        }
    }
}
