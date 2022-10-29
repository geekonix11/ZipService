using System.Collections.Generic;
using ZipService.Models;

namespace ZipService.Data{
    public interface IUserRepo{

        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User plat);

        void CreateAccount(Account acct);
        Account GetAccountById(int id);
        IEnumerable<Account> GetAllAccounts();
    }

}