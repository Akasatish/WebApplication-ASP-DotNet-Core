using WebApplication2.Domain.Interfaces;
using WebApplication2.Domain.Models;
using WebApplication2.Infrastructure;

namespace WebApplication2.Business
{
    public class ProduiteDAO : IProduiteDAO

    {
        public void Create(produite produite)
        {
            DB.produites.Add(produite);
        }

        public bool DeleteProduite(int Id)
        {
            var produite = GetById(Id);
            return DB.produites.Remove(produite);
        }

        public List<produite> GetAll()
        {
            return DB.produites;
        }

        public produite GetById(int Id)
        {
            return DB.produites.FirstOrDefault(x => x.Id == Id);
        }

        public produite UpdateProduite(int Id, produite produite)
        {
            var prod = GetById(Id);
            if (prod == null)
            {
                return null;
            }
            prod.Id = Id;
            prod.Name = produite.Name;
            prod.Price = produite.Price;
            prod.Quantite = +produite.Quantite;
            return prod;
        }
    }
}
