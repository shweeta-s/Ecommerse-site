using AutoMapper;
using POC.DTOs;
using POC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            
            CreateMap<Categories, CategoriesDTO>().ReverseMap();

            CreateMap<Cart, CartCreationDTO>().ReverseMap();
        }

       
    }
}
