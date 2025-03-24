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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BancoOccidenteContext _context;
        public CustomerRepository(BancoOccidenteContext context) {
            _context = context;
        }
        public async Task<Cliente?> GetCustomerByDocument(string documentId)
        {
            return await _context.Clientes.Where(c=> c.Documento == documentId && c.Status == true).FirstOrDefaultAsync();
        }
    }
}
