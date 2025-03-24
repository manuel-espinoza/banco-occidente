using AutoMapper;
using BancoOccidente.DataAccess.IRepositories;
using BancoOccidente.DataAccess.Models;
using BancoOccidente.Service.DTOs;
using BancoOccidente.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.Services
{
    public class TransactionsWriteService : ITransactionsWriteService
    {
        private readonly ITransactionsWriteRepository _transactionsWriteRepository;
        private readonly IMapper _mapper;

        public TransactionsWriteService(ITransactionsWriteRepository transactionsWriteRepository, IMapper mapper)
        {
            _transactionsWriteRepository = transactionsWriteRepository;
            _mapper = mapper;
        }

        public Task<bool> AddTransaction(TransactionDTO transaction)
        {
            var transactionAdded = _mapper.Map<Movimiento>(transaction);
            return _transactionsWriteRepository.AddTransaction(transactionAdded);
        }
    }
}
