using WebApplication2.Domain.Interfaces;
using WebApplication2.Domain.TokenServer;

namespace WebApplication2.Infrastructure
{
    public class TokenManager : ITokenManager
    {
        private List<Token> _tokens;

        public TokenManager()
        {
            _tokens = new List<Token>();
        }
        public bool Authenticate(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                return true;
            }
            return false;
        }

        public string GetToken(int Userid, string role)
        {
            throw new NotImplementedException();
        }

        public Token NewToken()
        {
            var token = new Token()
            {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMinutes(60)

            };
            _tokens.Add(token);
            return token;
        }



        public bool VerifyToken(string Token, int Userid)
        {
            if (_tokens.Any(x => x.Value == Token && x.ExpiryDate > DateTime.Now))
            {
                return true;
            }
                
            return false;

        }


    }
}
