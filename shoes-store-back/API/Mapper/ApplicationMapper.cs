using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
        
            CreateMap<RegisterDTO, Account>();
            
            CreateMap<Account, RegisterDTO>();
            CreateMap<Account, ProfileDTO>();
            CreateMap<Account, ChangePasswordDTO>();

        }
    }

}
