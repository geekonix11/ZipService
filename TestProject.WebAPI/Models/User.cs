using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZipService.Models{

    
    public class User{
        public User()
        {
            Accounts = new List<Account>();
        }
        [Key]
        [Required]
        public int UserId { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        public int Salary { get; set; }
        public int Expense { get; set; }
        public List<Account> Accounts { get; set; }


    }

}