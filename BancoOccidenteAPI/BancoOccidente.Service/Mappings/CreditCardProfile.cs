using AutoMapper;
using BancoOccidente.DataAccess.Models;
using BancoOccidente.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoOccidente.Service.Mappings
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile() {
            CreateMap<TarjetasCredito, CreditCardDTO>()
                .ForMember(d => d.CreditCardId, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.CardNumber, o => o.MapFrom(src => src.NumeroTarjeta))
                .ForMember(d => d.ExpirationDate, o => o.MapFrom(src => src.FechaExpiracion))
                .ForMember(d => d.Cvc, o => o.MapFrom(src => src.Cvv))
                .ForMember(d => d.CreditLimit, o => o.MapFrom(src => src.LimiteCredito))
                .ForMember(d => d.Status, o => o.MapFrom(src => src.Estado));
        }
    }
}
