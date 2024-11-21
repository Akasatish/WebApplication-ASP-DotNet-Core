namespace WebApplication2.Domain.TokenServer
{
    public class Token
    {
        public string Value {  get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
