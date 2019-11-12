using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile() 
        {
            CreateMap<Entities.Contact, Models.ContactDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name));
            CreateMap<Models.ContactDto, Entities.Contact>();
        }
    }
}

