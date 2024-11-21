using WebApplication2.Domain.TokenServer;

namespace WebApplication2.Domain.Interfaces
{
    public interface ITokenManager
    {
        public Token  NewToken();
        bool Authenticate(string username, string password);
        string GetToken(int Userid,string role);
        bool VerifyToken(string Token);
        
    }
}
