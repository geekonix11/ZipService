namespace ZipService.Dto
{
    public class AccountCreateDTO
    {
        public string AccountNo { get; set; }

        public string Type { get; set; }
        public int Balance { get; set; }

        
        public int UserId { get; set; }
    }
    
}