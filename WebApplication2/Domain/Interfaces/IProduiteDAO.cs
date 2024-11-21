using WebApplication2.Domain.Models;

namespace WebApplication2.Domain.Interfaces
{
    public interface IProduiteDAO
    {
        public List<produite> GetAll();
        public produite GetById(int Id);
        public bool DeleteProduite(int Id);
        public produite UpdateProduite(int Id, produite produite);
        public void Create(produite produite);
    }
}
