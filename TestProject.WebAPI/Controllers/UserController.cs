using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZipService.Data;
using ZipService.Dto;
using ZipService.Models;

namespace ZipService.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        
        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {

            var users = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        } 

         [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserDto> GetUserById(int id)
        {

            var user = _repository.GetUserById(id);
            if(user!=null)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }
            else{
                return NotFound();
            }
            
        } 

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserCreateDto user)
        {
             var userModel = _mapper.Map<User>(user);
             _repository.CreateUser(userModel);
             _repository.SaveChanges();

             var userReadDto = _mapper.Map<UserDto>(userModel);
             return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto); 
        }
    }

}