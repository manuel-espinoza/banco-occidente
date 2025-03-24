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
    /// <summary>
    /// Esta es mi forma de ver la implementacion del patron CQRS, separar las acciones de escritura de las de lectura. Faltaria agregarle una capa mas como por ejemplo la implementacion
    /// del patron mediador para que en el controller se pueda llamar a los metodos de escritura y lectura de manera independiente.
    /// </summary>
    public class TransactionsReadRepository : ITransactionsReadRepository
    {
        private readonly BancoOccidenteContext _context;
        public TransactionsReadRepository(BancoOccidenteContext context)
        {
            _context = context;
        }
        public async Task<List<Movimiento>> GetTransactionsByCreditCardAndMonth(int creditCardId, int month)
        {
            return await _context.Movimientos.OrderBy(x=> x.Fecha).Where(x => x.TarjetaCreditoId == creditCardId && x.Fecha!.Value.Month == month).ToListAsync();
        }
    }
}
