using System;
using System.Collections.Generic;
using AutoMapper;
using ZipService.Data;
using ZipService.Dto;
using ZipService.Models;

namespace ZipService.Business
{
    public class AccountBusiness
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        public AccountBusiness(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }

        public String CreateAccount(AccountCreateDTO acct)
        {
                if(acct.Balance >10000 || acct.Balance <=0){
                    return("Credit of 0-10000 allowed");
                    //return BadRequest("Salary - Expense should be more than 1000");
                }
                var user = _repository.GetUserById(acct.UserId);

                if((user.Salary - user.Expense) < 1000){
                    return("Salary - Expense should be more than 10000");
                    //return BadRequest("Salary - Expense should be more than 1000");
                }

                var accountModel = _mapper.Map<Account>(acct);
             _repository.CreateAccount(accountModel);
             _repository.SaveChanges();

             var acctReadDto = _mapper.Map<AccountReadDto>(accountModel);
            
             //return CreatedAtRoute("nameof(GetAccountById)", new {Id = acctReadDto.Id}, acctReadDto); 
            return "Success";                         
        }

    }
    
}