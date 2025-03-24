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
    public class CreditCardStatementPurchasesProfile : Profile
    {
        public CreditCardStatementPurchasesProfile()
        {
            CreateMap<EstadoCuentaCompras, CreditCardStatementPurchasesDTO>()
                .ForMember(d => d.Date, o => o.MapFrom(src => src.Fecha))
                .ForMember(d => d.Description, o => o.MapFrom(src => src.Descripcion))
                .ForMember(d => d.Amount, o => o.MapFrom(src => src.Monto));
        }
    }
}
