using ERP.Domain.Models;

namespace ERP.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Insert(Product obj);
        void Update(Product obj);
        void Delete(Product obj);
    }
}
