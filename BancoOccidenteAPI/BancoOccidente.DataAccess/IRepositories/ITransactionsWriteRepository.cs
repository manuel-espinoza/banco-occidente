using BancoOccidente.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.DataAccess.IRepositories
{
    /// <summary>
    /// Esta es mi forma de ver la implementacion del patron CQRS, separar las acciones de escritura de las de lectura. Faltaria agregarle una capa mas como por ejemplo la implementacion
    /// del patron mediador para que en el controller se pueda llamar a los metodos de escritura y lectura de manera independiente.
    /// </summary>
    public interface ITransactionsWriteRepository
    {
        Task<bool> AddTransaction(Movimiento transaction);
    }
}
