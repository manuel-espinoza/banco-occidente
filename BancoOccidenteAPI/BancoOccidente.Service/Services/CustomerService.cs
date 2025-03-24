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
    public class CustomerService : ICustomerService
    {   
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) { 
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDTO?> GetCustomerByDocument(string documentId)
        {
            var result = await _customerRepository.GetCustomerByDocument(documentId);
            return result != null ? _mapper.Map<CustomerDTO>(result) : null;
        }
    }
}
