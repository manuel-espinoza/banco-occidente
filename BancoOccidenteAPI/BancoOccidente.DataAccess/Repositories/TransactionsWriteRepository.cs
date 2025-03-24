using BancoOccidente.DataAccess.DataBase;
using BancoOccidente.DataAccess.IRepositories;
using BancoOccidente.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.DataAccess.Repositories
{
    /// <summary>
    /// Esta es mi forma de ver la implementacion del patron CQRS, separar las acciones de escritura de las de lectura. 
    /// Faltaria agregarle una capa mas como por ejemplo la implementacion
    /// del patron mediador para que en el controller se pueda llamar a los metodos de escritura y lectura de manera independiente.
    /// </summary>
    public class TransactionsWriteRepository : ITransactionsWriteRepository
    {
        private readonly BancoOccidenteContext _context;
        public TransactionsWriteRepository(BancoOccidenteContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Aqui tambien se podria integrar el patron UnitOfWork, por ejemplo como en la tabla tarjeta de credito tengo un campo para guardar el saldo diponible, podria integrar
        /// para que funcione como una transaccion: guardar el movimiento y actualizar el saldo disponible en la misma transaccion.
        /// Por cuestion de tiempo no podré implementar esto.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> AddTransaction(Movimiento transaction)
        {
            _context.Movimientos.Add(transaction);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
