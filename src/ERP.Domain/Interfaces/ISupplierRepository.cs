using ERP.Domain.Models;

namespace ERP.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task Insert(Supplier obj);
        void Update(Supplier obj);
        void Delete(Supplier obj);
    }
}
