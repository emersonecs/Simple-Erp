using ERP.Domain.Models;

namespace ERP.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);
        Task Insert(Client obj);
        void Update(Client obj);
        void Delete(Client obj);
    }
}
