using BancoOccidente.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.IServices
{
    public interface ICreditCardService
    {
        Task<CreditCardDTO?> GetCreditCardByNumber(string creditCardNumber);
    }
}
