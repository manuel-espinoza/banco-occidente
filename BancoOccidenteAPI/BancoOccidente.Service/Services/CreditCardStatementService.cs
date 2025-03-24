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
    public class CreditCardStatementService : ICreditCardStatementService
    {
        private readonly ICreditCardStatementRepository _creditCardStatementRepository;
        private readonly IMapper _mapper;
        public CreditCardStatementService(ICreditCardStatementRepository creditCardStatementRepository, IMapper mapper)
        {
            _creditCardStatementRepository = creditCardStatementRepository;
            _mapper = mapper;
        }
        public async Task<CreditCardStatementHeaderDTO?> GetHeaderByCustomer(int customerId)
        {
            var dbResult = await _creditCardStatementRepository.GetCreditCardStatementHeaderByCustomer(customerId);
            var ccStatementHeader = new CreditCardStatementHeaderDTO();
            if (dbResult != null)
            {
                ccStatementHeader.CustomerName = dbResult.NombreCliente;
                ccStatementHeader.CreditCard = dbResult.NumeroTarjetaCredito;
                ccStatementHeader.CreditLimit = dbResult.LimiteCredito;
                ccStatementHeader.CurrentBalance = CalculateCurrentBalance(dbResult.TotalCompras, dbResult.TotalAbonos);
                ccStatementHeader.AvailableCredit = CalculateAvailableCredit(ccStatementHeader.CreditLimit, ccStatementHeader.CurrentBalance);
                ccStatementHeader.TotalPuchasesAmount = dbResult.TotalCompras;
                ccStatementHeader.WaivableInterestAmount = CalculateWaivableInterest(ccStatementHeader.CurrentBalance, dbResult.PorcentajeInteresBonificable);
                ccStatementHeader.MinimumPaymentAmount = CalculateMinimumPayment(ccStatementHeader.CurrentBalance, dbResult.PorcentajeSaldoMinimo);
                ccStatementHeader.LumpSumPaymentAmount = CalculateLumpSumPayment(ccStatementHeader.CurrentBalance, ccStatementHeader.WaivableInterestAmount);

                return ccStatementHeader;
            }
            return null;

        }

        public async Task<List<CreditCardStatementPurchasesDTO>> GetPurchasesByCustomerAndMonth(int month, int customerId)
        {
            var result = await _creditCardStatementRepository.GetCreditCardStatementPurchasesByCustomer(month, customerId);
            return _mapper.Map<List<CreditCardStatementPurchasesDTO>>(result);
        }

        private static decimal CalculateAvailableCredit(decimal creditLimit, decimal currentBalance)
        {
            return creditLimit - currentBalance;
        }

        private static decimal CalculateMinimumPayment(decimal currentBalance, decimal minimumPaymentPercentage)
        {
            return currentBalance * minimumPaymentPercentage;
        }

        private static decimal CalculateWaivableInterest(decimal currentBalance, decimal waivableInterestPercentage)
        {
            return currentBalance * waivableInterestPercentage;
        }

        private static decimal CalculateCurrentBalance(decimal totalPurchases, decimal totalPayments)
        {
            return totalPurchases - totalPayments;
        }
        private static decimal CalculateLumpSumPayment(decimal currentBalance, decimal waivableInterestAmount)
        {
            return currentBalance + waivableInterestAmount;
        }

    }
}
