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
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public CreditCardService(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }
        public async Task<CreditCardDTO?> GetCreditCardByNumber(string creditCardNumber)
        {
            var result = await _creditCardRepository.GetCreditCardByNumber(creditCardNumber);

            return result != null ? _mapper.Map<CreditCardDTO>(result) : null;
        }
    }
}
