using System.Collections.Generic;
using AutoMapper;
using ZipService.Data;
using ZipService.Dto;
using ZipService.Models;
using System;
namespace ZipService.Business
{

    public class UserBusiness
    {
       private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserBusiness(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }

        public IEnumerable<UserDto> GetUsers()
        {

            var users = _repository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        
        
    }
    
}