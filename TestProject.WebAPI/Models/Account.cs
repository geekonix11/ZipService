using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZipService.Models{
    public class Account {
        [Key]
        public int Id { get; set; }
        public string AccountNo { get; set; }

        public string Type { get; set; }
        [Range(1,1000)]
        public int Balance { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

    }


}