using ERP.Domain.Models;

namespace ERP.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task Insert(Order obj);
    }
}
