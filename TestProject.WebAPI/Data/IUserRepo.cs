using System.Collections.Generic;
using ZipService.Models;

namespace ZipService.Data{
    public interface IUserRepo{

        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User plat);
    }

}