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
    public class CustomerProfile : Profile
    {
        public CustomerProfile() {
            CreateMap<Cliente, CustomerDTO>()
                .ForMember(d => d.CustomerID, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.CustomerName, o => o.MapFrom(src => src.Nombre))
                .ForMember(d => d.CustomerDocument, o => o.MapFrom(src => src.Documento))
                .ForMember(d => d.CustomerEmail, o => o.MapFrom(src => src.Email))
                .ForMember(d => d.CustomerPhone, o => o.MapFrom(src => src.Telefono));
        }
    }
}
