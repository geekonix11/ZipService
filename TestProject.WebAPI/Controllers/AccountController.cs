using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZipService.Business;
using ZipService.Data;
using ZipService.Dto;
using ZipService.Models;
namespace ZipService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        private readonly AccountBusiness _business;

        public AccountController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _business = new AccountBusiness(_repository, _mapper);
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {

            var accounts = _repository.GetAllAccounts();
            return Ok(accounts);
            //return Ok(_mapper.Map<IEnumerable<AccountReadDto>>(accounts));
        } 
         [HttpGet("{id}", Name = "GetAccountById")]
        public ActionResult<AccountReadDto> GetAccountById(int id)
        {

            var account = _repository.GetAccountById(id);
            if(account!=null)
            {
                return Ok(_mapper.Map<AccountReadDto>(account));
            }
            else{
                return NotFound();
            }
            
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount(AccountCreateDTO acct)
        {
            try{
                var account = _business.CreateAccount(acct);
                if(account.Contains("Success")){
                    return Ok();    
                }
                else{
                    return BadRequest(account);
                }
                
            //     var user = _business.GetUserById(acct.UserId);

            //     if((user.Salary - user.Expense) < 1000){
            //         return BadRequest("Salary - Expense should be more than 1000");
            //     }

            //     var accountModel = _mapper.Map<Account>(acct);
            //  _repository.CreateAccount(accountModel);
            //  _repository.SaveChanges();

            //  var acctReadDto = _mapper.Map<AccountReadDto>(accountModel);
            
            //  //return CreatedAtRoute("nameof(GetAccountById)", new {Id = acctReadDto.Id}, acctReadDto); 
            // return Ok();
            }
            catch(Exception ex){
                return BadRequest(ex.InnerException.Message);
            }
             
        }
    }

}