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
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Movimiento, TransactionDTO>()
                .ForMember(d => d.TransactionId, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.CreditCardId, o => o.MapFrom(src => src.TarjetaCreditoId))
                .ForMember(d => d.TransactionDate, o => o.MapFrom(src => src.Fecha))
                .ForMember(d => d.Amount, o => o.MapFrom(src => src.Monto))
                .ForMember(d => d.Description, o => o.MapFrom(src => src.Descripcion))
                .ForMember(d => d.TransactionType, o => o.MapFrom(src => src.TipoMovimiento))
                .ReverseMap();
        }
    }
}
