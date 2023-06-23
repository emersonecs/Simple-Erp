using ERP.Domain.Models;

namespace ERP.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task Insert(Category obj);
        void Update(Category obj);
        void Delete(Category obj);
    }
}
