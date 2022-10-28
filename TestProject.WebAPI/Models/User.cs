using System.ComponentModel.DataAnnotations;

namespace ZipService.Models{

    public class User{
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        public int Salary { get; set; }
        public int Expense { get; set; }

    }

}