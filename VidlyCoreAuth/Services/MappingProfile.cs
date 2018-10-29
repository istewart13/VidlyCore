using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidlyCoreAuth.Models;

namespace VidlyCoreAuth.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingProfile.CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
