using System;
using System.Collections.Generic;
using System.Linq;
using ZipService.Models;

namespace ZipService.Data{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAccount(Account acct)
        {
            if(acct == null){
                throw new ArgumentNullException(nameof(acct));
            }
            _context.Accounts.Add(acct);
            
        }

        public void CreateUser(User user)
        {
            
            _context.Users.Add(user);
        }

        public Account GetAccountById(int id)
        {
             return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
             return _context.Accounts.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0); 
        }
    }

}