
using AutoMapper;
using ZipService.Dto;
using ZipService.Models;

namespace ZipService.Profile{

    public class ZipProfile : AutoMapper.Profile
    {
        public ZipProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<AccountCreateDTO, Account>();
            CreateMap<Account, AccountReadDto>();
        }
    }
}