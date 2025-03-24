using AutoMapper;
using BancoOccidente.DataAccess.IRepositories;
using BancoOccidente.Service.DTOs;
using BancoOccidente.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.Services
{
    public class TransactionsReadService : ITransactionsReadService
    {
        private readonly ITransactionsReadRepository _transactionsReadRepository;
        private IMapper _mapper;
        public TransactionsReadService(ITransactionsReadRepository transactionsReadRepository, IMapper mapper)
        {
            _transactionsReadRepository = transactionsReadRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionDTO>> GetTransactionsByCreditCardAndMonth(int creditCardId, int month)
        {
            var result = await _transactionsReadRepository.GetTransactionsByCreditCardAndMonth(creditCardId, month);
            return _mapper.Map<List<TransactionDTO>>(result);
        }
    }
}
