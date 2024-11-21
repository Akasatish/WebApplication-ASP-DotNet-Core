using WebApplication2.Domain.Models;

namespace WebApplication2.Infrastructure
{
    public class DB
    {
        public static List<produite> produites = new List<produite>() {
            new produite
            {
                Id = 1,
                Name = "T-shirt",
                Price = 20.5,
                Quantite =  20,
            },
            new produite
            {
                Id = 2,
                Name = "Pants",
                Price = 75.95,
                Quantite =  10,
            },
            new produite
            {
                Id = 3,
                Name = "Hat",
                Price = 10.5,
                Quantite =  5,
            }
        };
    }
}
